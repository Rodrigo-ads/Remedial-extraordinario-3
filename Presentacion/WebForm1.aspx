<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Presentacion.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <p>INSERTAR MATERIAL</p>
                
                <div class="mb-3">
                    <label class="form-label">Descripcion Material</label>
                    <asp:TextBox ID="TextBoxMaterialDesc" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Marca</label>
                    <asp:TextBox ID="TextBoxMarca" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Presentacion</label>
                    <asp:TextBox ID="TextBoxPresentacion" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Id_tipo</label>
                    <asp:TextBox ID="TextBoxIdTipo" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="LabelRespuesta1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="btnInsertarMaterial" class="btn btn-primary" runat="server" Text="Inserta Material" OnClick="btnInsertarMaterial_Click" />
                <div>
                    <p>Seleccione un ID_TIPO</p>
                    <asp:DropDownList ID="dropIdTipo" runat="server" OnSelectedIndexChanged="dropIdTipo_SelectedIndexChanged"></asp:DropDownList>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </div>
            </div>
            <div>
                <p>INSERTA OBRA</p>
                <div class="mb-3">
                    <label class="form-label">Nombre de la obra</label>
                    <asp:TextBox ID="TextBoxNombreObra" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Direccion</label>
                    <asp:TextBox ID="TextBoxObraDireccion" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha Inicio</label>
                    <asp:TextBox ID="TextBoxObraInicio" type="date" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha Final</label>
                    <asp:TextBox ID="TextBoxObraFinal" type="date" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Dueño</label>
                    <asp:DropDownList ID="DropDownListDueno" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Encargado</label>
                    <asp:DropDownList ID="DropDownListEncargado" runat="server"></asp:DropDownList>
                </div>
                <asp:Label ID="LabelRespuesta2" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="btnInsertaObra" runat="server" class="btn btn-primary" Text="Insertar obra" OnClick="btnInsertaObra_Click" />
                <asp:Button ID="btnMostrarObra" runat="server" Text="Mostrar Obras" OnClick="btnMostrarObra_Click" class="btn btn-primary"/>
                <p>ELIMINAR OBRA</p>
                <div class="mb-3">
                    <asp:Label ID="Respuesta3" runat="server" Text="Mensaje" CssClass="mb-3"></asp:Label>
                    <label class="form-label">Seleccione la Obra</label>
                    <asp:DropDownList ID="DropDownListObra" runat="server" OnSelectedIndexChanged="DropDownListObra_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            <div>
             <p>INSERTA PROVEEDOR DE MATERIAL OBRA</p>
                <div class="mb-3">
                    <label class="form-label">Recibido</label>
                    <asp:TextBox ID="TextBoxProveRecibido" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Entrega</label>
                    <asp:TextBox ID="TextBoxProveEntrega" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Cantidad</label>
                    <asp:TextBox ID="TextBoxProveCantidad" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha Entre</label>
                    <asp:TextBox ID="TextBoxProveFechaEntre" type="date" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Precio</label>
                    <asp:TextBox ID="TextBoxProvePrecio" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Obra</label>
                    <asp:DropDownList ID="DropDownListProveObra" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Material</label>
                    <asp:DropDownList ID="DropDownListProveMaterial" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Proveedor</label>
                    <asp:DropDownList ID="DropDownListProveProveedor" runat="server"></asp:DropDownList>
                </div>
                <asp:Label ID="LabelRespueta4" CssClass="mb-3" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="btnInsertaProveeDeMateria" runat="server" class="btn btn-primary" Text="Insertar Proveedor de Materiales Obras" OnClick="btnInsertaProveeDeMateria_Click" />
        </div>
        </div>
        
    </form>
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</body>
</html>