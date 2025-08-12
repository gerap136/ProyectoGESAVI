<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="ProyectoGESAVI.CapaVistas.Asignaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Control de Asignaciones</title>
 <link href="/css/estilo.css" rel="stylesheet" />
 <link href="/css/tabla.css" rel="stylesheet" />
 <link href="/css/formulario.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
     
     
     <h1>Control de Asignaciones </h1>
 </div>

 <div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="tabla-moderna">
         <Columns>
             <asp:BoundField DataField="AsignacionID" HeaderText="AsignacionID" />
             <asp:BoundField DataField="ReparacionID" HeaderText="ReparacionID" />
             <asp:BoundField DataField="TecnicoID" HeaderText="TecnicoID" />
             <asp:BoundField DataField="Fecha Asignacion" HeaderText="Fecha Asignacion" />
         </Columns>
     </asp:GridView>
 </div>

 <div class="campo-formulario">
     <label for="tAsignacionID">AsignacionID</label>
     <asp:TextBox ID="tAsignacionID" CssClass="form-input" runat="server" placeholder="Ingrese el código de Asignacion..." />
 </div>

 <div class="campo-formulario">
     <label for="tReparacionID">ReparacionID</label>
     <asp:TextBox ID="tReparacionID" CssClass="form-input" runat="server" placeholder="Ingrese el código de Reparacion..." />
 </div>

 <div class="campo-formulario">
     <label for="tTecnicoID">TecnicoID</label>
     <asp:TextBox ID="tTecnicoID" CssClass="form-input" runat="server"  placeholder="Ingrese el codigo del Tecnico..." />
 </div>

 <div class="campo-formulario">
     <label for="tFechaAsignacion">FechaAsignacion</label>
     <asp:TextBox ID="tFechaAsignacion" CssClass="form-input" runat="server" TextMode="Date" placeholder="Ingrese la Fecha de Asignacion..." />
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
