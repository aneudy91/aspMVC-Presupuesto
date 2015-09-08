<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presupuestos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-8">
                <section id="loginForm">
                    <div class="form-horizontal">
                        <h4>Acceso al sistema</h4>
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <table>
                                <tr>
                                    <td style="width: 860px">
                                        <asp:Label runat="server" AssociatedControlID="UserName" Height="32px">Nombre de usuario:</asp:Label>
                                        <br />
                                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" Height="39px" Width="396px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 860px">
                                        <asp:Label runat="server" AssociatedControlID="Password" Height="31px">Contraseña:</asp:Label>
                                        <br />
                                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Height="40px" Width="397px" />
                                        <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />


                                        <br />
                                        <asp:Label ID="LLoginFail" runat="server" Visible="false" Text="..."></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

</asp:Content>
