using System;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploEplayersMVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.idEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Criar(novaEquipe);

            ViewBag.Equipes = equipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}