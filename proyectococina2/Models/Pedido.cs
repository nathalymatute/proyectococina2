using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace proyectococina2.Models
{
    public class Pedido
    {
        [Key]
        public int Id_pedido { get; set; }

        public string Nombre_platillo { get; set; }
        public string fecha { get; set; }
        public string  Tipo_de_orden { get; set; }
        public string  nombre_del_cliente { get; set; }
        public int  Numero_mesa { get; set; }
        public int  cantidad { get; set; }
        public string comentarios { get; set; }
        public string estado { get; set;}
        public double Total { get; set; }


        
        
    }
}
