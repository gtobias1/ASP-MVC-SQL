using BDprojeto.Repositorio;
using BDProjeto.DTO.Contrato;
using BDProjeto.DTO.ExemploBD;
using BDProjeto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BDProjeto.Aplicacao
{
    public class UsuarioContextBS
    {
        private readonly IRepositorio<Usuarios> repositorio;

        public UsuarioContextBS(IRepositorio<Usuarios> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Usuarios user)
        {
            try
            {
                repositorio.Salvar(user);
            }
            catch (Exception exSalvar)
            {
                throw new Exception("Erro na tentativa de salvar dados na tabela! ", exSalvar);
            }
        }

        public void ExcluirDados(Usuarios user)
        {
            try
            {
                repositorio.Excluir(user);
            }
            catch (Exception exExcluirDados)
            {
                throw new Exception("Erro ao excluir usuario! ", exExcluirDados);
            }
        }

        public IEnumerable<Usuarios> ListarTodos()
        {
            try
            {
                return repositorio.GetAll();
            }
            catch (Exception exListarTodos)
            {
                throw new Exception("Erro ao recuperar os registros da tabela! ", exListarTodos);
            }
        }

        public Usuarios GetUsuarioById(string id)
        {
            try
            {
                return repositorio.GetByID(id);
            }
            catch (Exception exGetUsuarioById)
            {
                throw new Exception("Erro ao recuperar usuário! ", exGetUsuarioById);
            }
        }


    }
}
