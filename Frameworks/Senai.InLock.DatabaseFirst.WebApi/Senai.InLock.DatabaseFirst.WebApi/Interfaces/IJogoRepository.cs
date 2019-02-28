using Senai.InLock.DatabaseFirst.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.InLock.DatabaseFirst.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List <Jogos> Listar();

        void Adicionar(Jogos jogo);

        void Atualizar(Jogos jogo);

        void Deletar(int id);
    }
}