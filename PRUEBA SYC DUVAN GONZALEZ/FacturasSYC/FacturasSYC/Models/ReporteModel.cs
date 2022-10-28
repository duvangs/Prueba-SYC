using System.ComponentModel.DataAnnotations;

namespace FacturasSYC.Models
{
    public class ReporteModel
    {
        public DateTime? FECHA_FAC { get; set;}
        public String? NOMBRE { get; set;}
        public int? VALOR_FAC { get; set;}
        public String? DESCRIPCION { get; set;}
    }
}
