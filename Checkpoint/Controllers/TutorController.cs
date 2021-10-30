using Checkpoint.Models;
using Checkpoint.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Controllers
{
    public class TutorController : Controller
    {
        private PetShopContext _context;
        public TutorController(PetShopContext context)
        {
            _context = context;
        }
        public IActionResult Index(string nomeBusca, GeneroTutor? generoBusca)
        {
            var lista = _context.Tutores.Include(t => t.Endereco).Where(t =>
                (t.Nome.Contains(nomeBusca) || nomeBusca == null) &&
                (t.GeneroTutor.Equals(generoBusca)) || (generoBusca == null)).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Tutor tutor)
        {
            _context.Tutores.Add(tutor);
            _context.SaveChanges();
            TempData["msg"] = $"Tutor: {tutor.Nome} cadastrado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var tutor = _context.Tutores.Find(id);
            _context.Tutores.Remove(tutor);
            _context.SaveChanges();
            TempData["msg"] = $"Tutor {tutor.Nome} removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var tutor = _context.Tutores.Find(id);
            return View(tutor);
        }

        [HttpPost]
        public IActionResult Editar(Tutor tutor)
        {
            _context.Tutores.Update(tutor);
            _context.SaveChanges();
            TempData["msg"] = $"Tutor {tutor.Nome} atualizado!";
            return RedirectToAction("Index");
        }
    }
}
