using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        InstituicaoDomain BuscarPorId(int id); //Retorna o objeto do tipop InstituicaoDomain

        void Gravar(InstituicaoDomain instituicao);

        void Editar(InstituicaoDomain instituicao);

        void Excluir(int id);
    }
}
