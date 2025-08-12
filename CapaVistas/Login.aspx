<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoGESAVI.CapaVistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Técnicos</title>
    <link href="/css/estilo.css" rel="stylesheet" />
    <link href="/css/login.css" rel="stylesheet" />
    <link href="/css/formulario.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- ENCABEZADO -->
        <div class="header">
            <h1>Reparación GESAVI</h1>
        </div>

        <!-- FORMULARIO LOGIN -->
        <div class="login-container">
            <h2>Iniciar Sesión</h2>

            <label for="txtTecnicoUsuario">Usuario</label>
            <asp:TextBox ID="txtTecnicoUsuario" runat="server" CssClass="form-control"
                placeholder="Usuario"></asp:TextBox>

            <label for="txtTecnicoContraseña">Contraseña</label>
            <asp:TextBox ID="txtTecnicoContraseña" runat="server" CssClass="form-control"
                TextMode="Password" placeholder="Contraseña"></asp:TextBox>

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn" OnClick="btnIngresar_Click" />

        </div>
    </form>
</body>
</html>
