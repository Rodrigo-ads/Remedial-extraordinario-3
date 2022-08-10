using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Obra
    {
        public int Id_Obra { set; get; }
        public string Nom_Obra { set; get; }
        public string Direccion { set; get; }
        public string FechaInicio { set; get; }
        public string FechaFin { set; get; }
        public int Id_Dueno { set; get; }
        public int Id_Encargado { set; get; }
    }
}
