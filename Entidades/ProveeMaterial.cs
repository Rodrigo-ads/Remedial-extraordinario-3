using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProveeMaterial
    {
        public string Recibido { set; get; }
        public string Entrega { set; get; }
        public int Cantidad { set; get; }
        public string Fecha_Entre { set; get; }
        public double precio { set; get; }
        public int ID_Obra { set; get; }
        public int ID_Materia { set; get; }
        public int ID_Proveedor { set; get; }
    }
}
