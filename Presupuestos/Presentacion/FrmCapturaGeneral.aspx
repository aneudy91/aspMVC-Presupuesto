<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCapturaGeneral.aspx.cs" Inherits="Presupuestos.Presentacion.FrmCapturaGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div>
        Seleccione un proyecto:<br />
        <asp:DropDownList ID="DDLProyectos" runat="server" Height="52px" Width="469px" OnSelectedIndexChanged="DDLProyectos_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

        <br />
        <br />
        <div>
            <span class="inicio">  <%--mGrid--%>
                <asp:GridView ID="GridData" runat="server" AllowPaging="true" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="White" 
                    BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" CssClass="table table-hover table-striped" 
                    Font-Size="Medium" GridLines="Both" 
                    OnPageIndexChanging="Griddata_PageIndexChanging" OnRowCancelingEdit="GridData_RowCancelingEdit" 
                    OnRowDataBound="GridData_RowDataBound1" OnRowEditing="GridData_RowEditing" OnRowUpdating="GridData_RowUpdating" PageSize="15" Width="204px">
                    <EditRowStyle Width="10px" />
<%--                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" Wrap="False" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />--%>
                </asp:GridView>
            </span>
        </div>
    </div>


    <br />
    <br />

    <asp:Button ID="btCalcular" runat="server" Text="Calcular Proyecto" Height="52px" Width="190px" OnClick="btCalcular_Click" />
<%--    <br />
    <br />
    <h3>
        <asp:Label ID="LDetalleProecto" runat="server" Text="Detalle del proyecto"></asp:Label></h3>

        <asp:GridView ID="gvDetalleProyecto" runat="server" CssClass="table table-hover table-striped"></asp:GridView>--%>

    <br />
    <br />
    <h3>
       <asp:Label ID="Label1" runat="server" Text="Totales Generales"></asp:Label></h3>
    <asp:GridView ID="gvTotalesGenerales" runat="server" CssClass="table table-hover table-striped"></asp:GridView>

    <br />
    <br />
    <h3>
       <asp:Label ID="Label2" runat="server" Text="Catálogo de Conceptos"></asp:Label></h3>
    <asp:GridView ID="gvConceptos" runat="server" CssClass="table table-hover table-striped"></asp:GridView>

</asp:Content>
