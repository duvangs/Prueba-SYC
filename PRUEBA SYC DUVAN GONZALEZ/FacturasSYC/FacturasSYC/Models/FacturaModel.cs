//using Microsoft.Build.Framework;
//using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace FacturasSYC.Models
{
    public class FacturaModel
    {
        [Required(ErrorMessage = "El campo ID factura es obligatorio")]
        public int? ID_FACTURA { get; set; }

        [Required(ErrorMessage = "El campo numero de documento es obligatorio")]
        public decimal? NUME_DOC { get; set; }
        [Required(ErrorMessage = "El campo  Codigo de estado es obligatorio")]
        public decimal? CODI_ESTADO { get; set; }
        [Required(ErrorMessage  = "El campo del valor de la factura es obligatorio")]
        public decimal? VALOR_FAC { get; set; }
        [Required(ErrorMessage  = "El campo fecha de factura es obligatorio")]
        public DateTime? FECHA_FAC { get; set; }
    }
}
