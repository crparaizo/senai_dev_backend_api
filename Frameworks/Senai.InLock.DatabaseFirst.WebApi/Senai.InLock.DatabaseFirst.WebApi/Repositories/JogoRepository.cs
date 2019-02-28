using Senai.InLock.DatabaseFirst.WebApi.Domains;
using Senai.InLock.DatabaseFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.InLock.DatabaseFirst.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public void Adicionar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogoProcurado = ctx.Jogos.Find(jogo.JogoId);

                jogoProcurado.NomeJogo = jogo.NomeJogo;

                ctx.Jogos.Update(jogoProcurado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }
    }
}