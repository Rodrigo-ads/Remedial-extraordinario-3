using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Material
    {
        public int ID_Material { set; get; }
        public string Descripcion_Mat { set; get; }
        public string Marca { set; get; }
        public string Presentacion { set; get; }
        public int Id_Tipo { set; get; }
    }
}
