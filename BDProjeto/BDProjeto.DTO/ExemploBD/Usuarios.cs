using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDProjeto.DTO.ExemploBD
{
    public class Usuarios
    {
        [Key]
        public int USUARIO_ID { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preencha o nome!")]
        public string NOME { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Preencha o cargo!")]
        public string CARGO { get; set; }

        [DisplayName("Data de admissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DATAINSERCAO { get; set; }
    }
}
