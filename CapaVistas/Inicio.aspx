<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoGESAVI.CapaVistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/estilo.css" rel="stylesheet" />
    <link href="/css/tabla.css" rel="stylesheet" />
    <link href="/css/formulario.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Reparaciones GESAVI</h1>
            <p>Bienvenido a la pagina de inicio de Tecnicos y Administradores de Reparación GESAVI</p>
        </div>


        <div class="menu">
            <ul>
                <li><a class="active" href="Inicio.aspx">Inicio</a></li>
                <li><a href="Equipos.aspx">Equipos</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="Detalles.aspx">Detalles de Reparación</a></li>
                <li style="float: right"><a href="#login">login</a></li>
            </ul>
        </div>
        
    </form>
</body>
</html>
