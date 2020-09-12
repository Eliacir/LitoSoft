<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="CapaPresentacion.Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE CLIENTES</h1>
    </section>--%>
    <section class="content">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="form-group">
                        <label>Nómbre </label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNombre" ControlToValidate="txtNombre" ErrorMessage="Campo requerido." ValidationGroup="ValidationConfiguracion" />
                    </div>
                    <div class="form-group">
                        <label>Documento</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDocumento" ControlToValidate="txtDocumento" ErrorMessage="Campo requerido." ValidationGroup="ValidationConfiguracion" />
                    </div>
                    <div class="form-group">
                        <label>Dirección</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Teléfono</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Correo electronico</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click"  ValidationGroup="ValidationConfiguracion"/>
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


