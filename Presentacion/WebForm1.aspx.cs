using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entidades;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Negocios objNeg = new Negocios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertarMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                LabelRespuesta1.Text = objNeg.crear_Material(new Material()
                {
                    Descripcion_Mat = TextBoxMaterialDesc.Text,
                    Marca = TextBoxMarca.Text,
                    Presentacion = TextBoxPresentacion.Text,
                    Id_Tipo = Convert.ToInt32(TextBoxIdTipo.Text)
                });
            }
            catch(Exception ex)
            {
                LabelRespuesta1.Text = ex.Message;
            }
        }
    }
}