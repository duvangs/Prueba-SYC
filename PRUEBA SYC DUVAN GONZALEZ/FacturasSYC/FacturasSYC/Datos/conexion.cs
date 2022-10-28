using System.Data.SqlClient;

namespace FacturasSYC.Datos
{
    public class conexion
    {
        private String cadenaSQL = String.Empty;

        public conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:FacturasSYC").Value;

        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
