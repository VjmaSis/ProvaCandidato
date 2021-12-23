using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente : EntidadeBase
    {

        [StringLength(50)]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [Column("nome")]
        [MinLength(3, ErrorMessage = "O Nome deve conter mais que 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [DataNascimento]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

    }
}