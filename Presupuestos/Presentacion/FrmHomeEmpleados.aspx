<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeEmpleados.aspx.cs" Inherits="Presupuestos.Presentacion.FrmHomeEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; border: solid 1px #E4E4E4; width: 100%; margin: 0 auto;">
        <div style="height: 90px; background: #000; color: #fff; padding: 10px;">
            <p style="margin-bottom: -30px;">Total obtenido hasta la fecha</p>
            <h1 style="font-size: 4em; margin-bottom: 10px;">
                <asp:Label ID="LTotalPagado" runat="server" Text="$0,00"></asp:Label></h1>
        </div>
        <div>
            <asp:GridView ID="gvProyectos" CssClass="table table-hover table-striped" runat="server"></asp:GridView>
           
        </div>
    </div>
</asp:Content>
