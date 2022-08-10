using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trabajador
    {
        public int Id_Trabajador { set; get; }
        public string Nombre_Tab { set; get; }
        public double Sueldo { set; get; }
        public string fecha_pago { set; get; }
        public int Id_Encargado { set; get; }
        public int Id_Tipo_Trabajador { set; get; }
    }
}
