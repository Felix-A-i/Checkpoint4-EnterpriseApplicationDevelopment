using Checkpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Controllers
{
    public class IntegrantesController : Controller
    {
        private List<Integrantes> _integrantes = new List<Integrantes>();
        private void CarregarIntegrantes()
        {
            _integrantes.Add(new Integrantes("João Paulo Pereira Macêdo", 86353));
            _integrantes.Add(new Integrantes("Karen Martins Silveira", 85282));
            _integrantes.Add(new Integrantes("Lucas Pelosi de Almeida", 85987));
            _integrantes.Add(new Integrantes("Mariana Alves de Oliveira Ribeiro", 86125));
            _integrantes.Add(new Integrantes("Tiago de Brito Ferreira", 84267));
            _integrantes.Add(new Integrantes("Vitor Mendes Olivério", 84609));
        }
        public IActionResult Index()
        {
            CarregarIntegrantes();
            return View(_integrantes);
        }
    }
}
