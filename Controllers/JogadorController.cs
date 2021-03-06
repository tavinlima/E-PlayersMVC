using System;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.LerTodos();
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome = form["NomeJogador"];
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Email = form["EmailJogador"];
            novoJogador.Senha = form["SenhaJogador"];

            jogadorModel.Criar(novoJogador);
            ViewBag.Jogadores = jogadorModel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }
        [Route ("Jogador/{id}")]
        public IActionResult Excluir(int id){
            jogadorModel.Deletar(id);
            ViewBag.Jogadores = jogadorModel.LerTodos();
            HttpContext.Session.Remove("_UserName");

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}