using System;
using System.ComponentModel.DataAnnotations;

namespace BDProjeto.DTO.ExemploBD
{
    public class UsuariosDTO
    {
        public int USUARIO_ID { get; set; }

        public string NOME { get; set; }

        public string CARGO { get; set; }

        public string DATAINSERCAO { get; set; }
    }
}
