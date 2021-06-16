using System.Collections.Generic;
using EPlayersMVC.Models;

namespace EPlayersMVC.Interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe e);
        List<Equipe> LerTodas();
        void Atualizar(Equipe e);
        void Deletar(int id);
    }
}