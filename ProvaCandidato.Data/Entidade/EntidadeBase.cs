using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Entidade
{
    public class EntidadeBase
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
    }
}
