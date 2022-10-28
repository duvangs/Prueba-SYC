using Microsoft.AspNetCore.Mvc;

using FacturasSYC.Datos;
using FacturasSYC.Models;

namespace FacturasSYC.Controllers
{
    public class MantenedorController : Controller
    {
        FacturaDatos _FacturaDatos = new FacturaDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de facturas
            var oLista = _FacturaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Reportar()
        {
            //La vista mostrará una lista de facturas
            var oLista = _FacturaDatos.Reportar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(FacturaModel oFactura)
        {
            //Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();


            var respuesta  = _FacturaDatos.Guardar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
