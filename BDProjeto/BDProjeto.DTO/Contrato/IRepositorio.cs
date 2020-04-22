using System.Collections.Generic;

namespace BDProjeto.DTO.Contrato
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);

        void Excluir(T entidade);

        IEnumerable <T> GetAll();

        T GetByID(string id);
    }
}
