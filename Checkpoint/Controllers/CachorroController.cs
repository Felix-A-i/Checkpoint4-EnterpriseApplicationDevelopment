using Checkpoint.Models;
using Checkpoint.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Controllers
{
    public class CachorroController : Controller
    {
        private PetShopContext _context;
        public CachorroController(PetShopContext context)
        {
            _context = context;
        }

        private void CarregarTutores()
        {
            var lista = _context.Tutores.OrderBy(t => t.Nome).ToList();
            ViewBag.tutores = new SelectList(lista, "TutorId", "Nome");
        }

        private void CarregarDados()
        {
            var listaRacas = new List<string>(new string[] { "São Bernardo", "SRD", "Samoieda", "Bulldog", "Labrador"});
            ViewBag.racas = new SelectList(listaRacas);
        }

        [HttpGet]
        public IActionResult Index(string nomeBusca, Sexo? sexoBusca)
        {
            var lista = _context.Cachorros.Where(c =>
            (c.Nome.Contains(nomeBusca) || (nomeBusca == null) &&
            (c.Sexo.Equals(sexoBusca) || sexoBusca == null))).Include(c => c.Tutor).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarTutores();
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cachorro cachorro)
        {
            _context.Cachorros.Add(cachorro);
            _context.SaveChanges();
            TempData["msg"] = $"{cachorro.Nome} cadastrado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var cachorro = _context.Cachorros.Find(id);
            _context.Cachorros.Remove(cachorro);
            _context.SaveChanges();
            TempData["msg"] = $"Cachorro {cachorro} removido!";
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            CarregarDados();
            var cachorro = _context.Cachorros.Find(id);
            return View(cachorro);
        }

        [HttpPost]
        public IActionResult Editar(Cachorro cachorro)
        {
            _context.Cachorros.Update(cachorro);
            _context.SaveChanges();
            TempData["msg"] = $"{cachorro.Nome} atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            var cachorro = _context.Cachorros.Include(c => c.Tutor).Where(c => c.CachorroId == id).FirstOrDefault();
            return View(cachorro);
        }
    }
}