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
            </div>
            <div>
                <p>Seleccione un ID_TIPO</p>
                <asp:DropDownList ID="dropIdTipo" runat="server" OnSelectedIndexChanged="dropIdTipo_SelectedIndexChanged"></asp:DropDownList>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</body>
</html>