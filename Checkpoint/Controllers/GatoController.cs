using Checkpoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Controllers
{
    public class GatoController : Controller
    {
        private static int _index = 0;
        private static List<Gato> _gatos = new List<Gato>();

        private void CarregarDados()
        {
            var listaRacas = new List<string>(new string[] { "Siamês", "SRD", "Persa", "Sphynx", "American Shorthair"});
            ViewBag.racas = new SelectList(listaRacas);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_gatos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Gato gato)
        {
            gato.Id = ++_index;
            _gatos.Add(gato);
            TempData["msg"] = $"{gato.Nome} cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _gatos.RemoveAll(g => g.Id == id);
            TempData["msg"] = "Gato removido!";
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarDados();
            var gato = _gatos.Find(g => g.Id == id);
            return View(gato);
        }

        [HttpPost]
        public IActionResult Editar(Gato gato)
        {
            _gatos[_gatos.FindIndex(g => g.Id == g.Id)] = gato;
            TempData["msg"] = $"{gato.Nome} atualizado!";
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Filtrar(string cor)
        {
            List<Gato> gatos = new List<Gato>();
            foreach (var item in _gatos)
            {
                if(item.Cor.Equals(cor))
                {
                    gatos.Add(item);
                }
            }
            TempData["msg"] = $"Gatos {cor} filtrados";
            //gatos = _gatos[_gatos.FindIndex(g => g.Cor == cor)];
            return View(gatos);
        }
    }
}