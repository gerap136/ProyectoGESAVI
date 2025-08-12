<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="ProyectoGESAVI.CapaVistas.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
     <link href="/css/estilo.css" rel="stylesheet"/>
     <link href="/css/tabla.css" rel="stylesheet"/>
     <link href="/css/formulario.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <h1></h1>
         <h1>Reparación GESAVI</h1>
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

 <div></div>

 <div class="header">
     
    
     <h1>Control de Equipos</h1>
 </div>

 <div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="tabla-moderna">
         <Columns>
             <asp:BoundField DataField="EquipoID" HeaderText="EquipoID" />
             <asp:BoundField DataField="TipodeEquipo" HeaderText="Tipo de Equipo" />
             <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
             <asp:BoundField DataField="UsuarioID" HeaderText="UsuarioID" />
         </Columns>
     </asp:GridView>
 </div>

 <div class="campo-formulario">
     <label for="tEquipoID">EquipoID</label>
     <asp:TextBox ID="tEquipoID" CssClass="form-input" runat="server" placeholder="Ingrese el código de Equipo..." />
 </div>

 <div class="campo-formulario">
     <label for="tTipoEquipo">Tipo de Equipo</label>
     <asp:TextBox ID="tTipoEquipo" CssClass="form-input" runat="server" placeholder="Ingrese el Tipo de Equipo..." />
 </div>

 <div class="campo-formulario">
     <label for="tmodelo">Modelo</label>
     <asp:TextBox ID="tmodelo" CssClass="form-input" runat="server" placeholder="Ingrese el modelo de Equipo..." />
 </div>

 <div class="campo-formulario">
     <label for="tUsuarioID">UsuarioID</label>
     <asp:TextBox ID="tUsuarioID" CssClass="form-input" runat="server" placeholder="Ingrese el UsuarioID..." />
 </div>

 <div class="botones-horizontal">
     <asp:Button ID="btnGuardar" runat="server" Text="Agregar" CssClass="form-button" OnClick="btnGuardar_Click" />
     <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="form-button" OnClick="btnEliminar_Click" />
     <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="form-button" OnClick="btnModificar_Click" />
     <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="form-button" OnClick="btnConsultar_Click" />
 </div>
    </form>
</body>
</html>
