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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDados();
            return View();
        }
    }
}
