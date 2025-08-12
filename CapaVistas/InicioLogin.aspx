<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioLogin.aspx.cs" Inherits="ProyectoGESAVI.CapaVistas.InicioLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link href="/css/estilo.css" rel="stylesheet"/>
<link href="/css/tabla.css" rel="stylesheet"/>
 <link href="/css/formulario.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
                    <h1>Reparaciones GESAVI</h1>
            <p>Bienvenido a la pagina de inicio Reparación GESAVI</p>
        </div>


        <div class="menu">
            <ul>
                <li><a class="active" href="InicioLogin.aspx">Inicio</a></li>
                <li style="float: right"><a href="Login.aspx">login</a></li>
            </ul>
        </div>
        
        <div class="campo-formulario">
    <h1></h1>
    <h1>Consulte el estado de su repacion</h1>
    <label for="tConsulta">Consulta</label>
    <asp:TextBox ID="TextBox1" CssClass="form-input" runat="server" placeholder="Ingrese el ID de Usuario..." />
</div>


<div class="botones-horizontal">
    <asp:Button ID="Button1" runat="server" Text="Consultar" CssClass="form-button" OnClick="btnConsultar_Click" />
</div>
<div class="campo-formulario">
    <label>Reparación ID:</label>
    <asp:Label ID="lblReparacionID" runat="server" CssClass="form-label"></asp:Label>
</div>

<div class="campo-formulario">
    <label>Equipo ID:</label>
    <asp:Label ID="lblEquipoID" runat="server" CssClass="form-label"></asp:Label>
</div>

<div class="campo-formulario">
    <label>Fecha de Solicitud:</label>
    <asp:Label ID="lblFechaSolicitud" runat="server" CssClass="form-label"></asp:Label>
</div>

<div class="campo-formulario">
    <label>Estado:</label>
    <asp:Label ID="lblEstado" runat="server" CssClass="form-label"></asp:Label>
</div>
<!-- Label para mensajes de error o confirmacion -->
<asp:Label ID="lblResultado" runat="server" CssClass="mensaje-error" Text=""></asp:Label>
    </form>
</body>
</html>
