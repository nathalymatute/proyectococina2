using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyectococina2.Models;

namespace proyectococina2.Controllers
{
    public class modulocomidaController : Controller
    {
        private readonly cocinadbContext _cocinadbContext;
        public modulocomidaController(cocinadbContext cocinadbContext)
        {
            _cocinadbContext = cocinadbContext;
        }
        public IActionResult Index()
        {
            var pedidos = _cocinadbContext.pedido.Select(p => new
            {
                p.Id_pedido,
                p.Nombre_platillo,
                p.fecha,
                p.Tipo_de_orden,
                p.nombre_del_cliente,
                p.Numero_mesa,
                p.cantidad,
                p.comentarios,
                p.estado,
                Total = (double)p.Total
            }).ToList();

            ViewData["Pedidos"] = pedidos;
            
            return View();
        }
        [HttpPost]
        public IActionResult ActualizarEstado(int pedidoId)
        {
            var pedido = _cocinadbContext.pedido.FirstOrDefault(p => p.Id_pedido == pedidoId);

            if (pedido != null)
            {
                pedido.estado = "Finalizado";
                _cocinadbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
