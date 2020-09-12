<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManoObras.aspx.cs" Inherits="CapaPresentacion.ManoObras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO MANO DE OBRA</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Descripción</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDescripcion" ControlToValidate="txtDescripcion" ErrorMessage="Campo requerido." ValidationGroup="ValidationManoObra" />
                        </div>
                        <div class="form-group">
                            <label>Cantidad de empleados</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCantidad" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="ValidationManoObra" />
                        </div>

                        <div class="form-group">
                            <label>Tiempo</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTiempo" runat="server" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqTiempo" ControlToValidate="txtTiempo" ErrorMessage="Campo requerido." ValidationGroup="ValidationManoObra" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValidationManoObra"/>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </section>
</asp:Content>


