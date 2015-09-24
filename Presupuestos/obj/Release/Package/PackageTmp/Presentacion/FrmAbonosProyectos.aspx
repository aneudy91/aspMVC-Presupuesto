<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAbonosProyectos.aspx.cs" Inherits="Presupuestos.Presentacion.FrmAbonosProyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <link type="text/css" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" />
<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

      <br />
    <br />
    <h1>Agrega abonos a tus proyectos!</h1>
    <br />

    <h3>Selecciona un proyecto:</h3>
    <asp:DropDownList ID="DDLProyectos" runat="server"  Height="52px" Width="469px"  CssClass="form-control" AutoPostBack="true"></asp:DropDownList>

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-6">
                Descripción
                <br />
                <asp:TextBox ID="txt_Descripcion" runat="server" Height="113px" Width="664px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="LCosto" runat="server" Text="$0.00"></asp:Label>
            </div>
        </div>
    </div>
    <div class="jumbotron">
        <div class="row">
            
            <table class="nav-justified">
                <tr>
                    <td style="width: 222px">Abono</td>
                    <td style="width: 213px">Fecha</td>
                    <td> Recibí De:</td>
                </tr>
                <tr>
                    <td style="width: 222px">
                        <asp:TextBox ID="txt_cantidadAbono" runat="server" CssClass="form-control" Width="226px"></asp:TextBox></td>
                    <td style="width: 213px">
                        <asp:TextBox ID="txt_FechaAbono" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </td>
                    <td style="width: 379px">
                        <asp:TextBox ID="txt_RecibiDe" runat="server" Width="355px" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="BtGuardar" runat="server" Text="Agrega Abono" CssClass="form-control" Width="158px" OnClick="BtGuardar_Click"/>
                    </td>
                </tr>          
            </table>
            <br />                          
        </div>         
    </div>

    <br />
    Lista de abonos a proyecto: <br />
    <asp:GridView ID="GvAbonos" runat="server"   CssClass="table table-hover table-striped" ></asp:GridView>      


<%--<script type="text/javascript">
    $(function () {
        $("#FechaAbono").datepicker({ dateFormat: "dd-mm-yy" }).val();      
    });
</script>--%>
</asp:Content>

