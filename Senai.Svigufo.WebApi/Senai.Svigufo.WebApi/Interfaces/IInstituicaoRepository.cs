using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        InstituicaoDomain BuscarPorId(int id); //Retorna o objeto do tipo InstituicaoDomain

        void Gravar(InstituicaoDomain instituicao);

        void Editar(int id, InstituicaoDomain instituicao);

        void Excluir(int id);
    }
}