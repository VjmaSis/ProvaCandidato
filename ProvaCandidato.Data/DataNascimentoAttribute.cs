using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data
{
    public class DataNascimentoAttribute : ValidationAttribute
    {
        public DataNascimentoAttribute()
        {
            this.ErrorMessage = "A Data atríbuida é inválida.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value == null)
                {
                    return new ValidationResult("Data não informada");
                }
                else
                {
                    var data = Convert.ToDateTime(value);
                    if (data > DateTime.Now)
                    {
                        return new ValidationResult("A data informada tem que ser menor que a data atual");
                    }
                }

                return ValidationResult.Success;
            }
            catch (Exception ex)
            {

                return new ValidationResult(ex.Message.ToString());
            }
        }
    }
}
