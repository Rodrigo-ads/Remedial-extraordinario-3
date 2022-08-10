using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class Negocios
    {
        Acceso obj = new Acceso();

        public string crear_Material(Material material)
        {
            return obj.InsertaMaterial(material);
        }
    }
}
