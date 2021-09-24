using Checkpoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Controllers
{
    public class PetController : Controller
    {
        private static int _index = 0;
        private static List<Pet> _pets = new List<Pet>();

        private void CarregarDados()
        {
            var listaGatos = new List<string>(new string[] { "Siamês", "SRD", "Persa", "Sphynx", "American Shorthair"});
            var listaCachorros = new List<string>(new string[] { "Golden Retriever", "SRD", "Pastor Alemão", "Dalmata", "Samoieda"});
            ViewBag.gatos = new SelectList(listaGatos);
            ViewBag.cachorros = new SelectList(listaCachorros);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_pets);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pet pet)
        {
            pet.Id = ++_index;
            _pets.Add(pet);
            TempData["msg"] = "Pet cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _pets.RemoveAll(pet => pet.Id == id);
            TempData["msg"] = "Pet removido!";
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarDados();
            var pet = _pets.Find(pet => pet.Id == id);
            return View(pet);
        }

        [HttpPost]
        public IActionResult Editar(Pet pet)
        {
            _pets[_pets.FindIndex(obj => obj.Id == pet.Id)] = pet;
            TempData["msg"] = "Pet atualizado!";
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Filtrar(Sexo sexo)
        {
            var pet = _pets.Find(pet => pet.Sexo == sexo);
            return View(pet);
        }
    }
}
