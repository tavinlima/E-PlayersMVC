using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Interfaces;

namespace EPlayersMVC.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int idEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string CAMINHO = "Database/equipe.csv";
        public Equipe()
        {
            CriarPastaEArquivo(CAMINHO);
        }
        public string Preparar(Equipe e)
        {
            return $"{e.idEquipe};{e.Nome};{e.Imagem}";
        }

        public void Atualizar(Equipe e)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == e.idEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescrevaCSV(CAMINHO, linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linha = { Preparar(e) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescrevaCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();

                equipe.idEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}