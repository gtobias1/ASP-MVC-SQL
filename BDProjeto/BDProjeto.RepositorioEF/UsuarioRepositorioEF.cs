using BDProjeto.DTO.Contrato;
using BDProjeto.DTO.ExemploBD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuarios>
    {
        private readonly BD bs;

        public UsuarioRepositorioEF()
        {
            bs = new BD();
        }

        public void Excluir(Usuarios entidade)
        {
            var itemUser = bs.usuario.FirstOrDefault(t => t.USUARIO_ID == entidade.USUARIO_ID);
            bs.Set<Usuarios>().Remove(itemUser);
            bs.SaveChanges();
        }

        public IEnumerable<Usuarios> GetAll()
        {
            return bs.usuario;
        }

        public Usuarios GetByID(string id)
        {
            int auxId;
            Int32.TryParse(id, out auxId);

            return bs.usuario.FirstOrDefault(t => t.USUARIO_ID == auxId);
        }

        public void Salvar(Usuarios entidade)
        {
            if (entidade.USUARIO_ID > 0)
            {
                var userEditar = bs.usuario.First(t => t.USUARIO_ID == entidade.USUARIO_ID);
                userEditar.NOME = entidade.NOME;
                userEditar.CARGO = entidade.CARGO;
            }
            else
                bs.usuario.Add(entidade);

            bs.SaveChanges();
        }
    }
}
