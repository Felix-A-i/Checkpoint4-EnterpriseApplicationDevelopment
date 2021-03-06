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
    public class GatoController : Controller
    {
        private PetShopContext _context;
        public GatoController(PetShopContext context)
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
            var listaRacas = new List<string>(new string[] { "Siamês", "SRD", "Persa", "Sphynx", "American Shorthair"});
            ViewBag.racas = new SelectList(listaRacas);
        }

        [HttpGet]
        public IActionResult Index(string nomeBusca, Sexo? sexoBusca)
        {
            var lista = _context.Gatos.Where(g =>
            (g.Nome.Contains(nomeBusca) || (nomeBusca == null) &&
            (g.Sexo.Equals(sexoBusca) || sexoBusca == null))).Include(g => g.Tutor).ToList();
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
        public IActionResult Cadastrar(Gato gato)
        {
            _context.Gatos.Add(gato);
            _context.SaveChanges();
            TempData["msg"] = $"{gato.Nome} cadastrado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var gato = _context.Gatos.Find(id);
            _context.Gatos.Remove(gato);
            _context.SaveChanges();
            TempData["msg"] = $"Gato {gato} removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarDados();
            var gato = _context.Gatos.Find(id);
            return View(gato);
        }

        [HttpPost]
        public IActionResult Editar(Gato gato)
        {
            _context.Gatos.Update(gato);
            _context.SaveChanges();
            TempData["msg"] = $"{gato.Nome} atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            var gato = _context.Gatos.Include(g => g.Tutor).Where(g => g.GatoId == id).FirstOrDefault();
            return View(gato);
        }
    }
}