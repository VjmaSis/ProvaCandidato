using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cidade")]
    public class Cidade : EntidadeBase
    {
        [Column("nome")]
        [StringLength(50)]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Nome deve conter mais que 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo 50 caracteres.")]
        [Display(Name = "Cidade")]
        public string Nome { get; set; }
    }
}
