using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Interfaces;

namespace EPlayersMVC.Models
{
    public class Jogador : EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        // Login
        public string Email { get; set; }
        public string Senha { get; set; }
        // Login
        
        private const string CAMINHO = "Database/jogador.csv";
        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }
        public string Preparar(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

        public void Atualizar(Jogador j)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(Preparar(j));
            ReescrevaCSV(CAMINHO, linhas);
        }

        public void Criar(Jogador j)
        {
            string[] linha = { Preparar(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescrevaCSV(CAMINHO, linhas);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();

                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdEquipe = Int32.Parse(linha[2]);
                jogador.Email = linha[3];
                jogador.Senha = linha[4];

                jogadores.Add(jogador);
            }
            return jogadores;
        }
    }
}