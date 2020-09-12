<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Litografia.aspx.cs" Inherits="CapaPresentacion.Litografia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE LITOGRAFIA</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary" style="left: 0px; top: 0px; height: 580px">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nómbre </label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNombre" ControlToValidate="txtNombre" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupLitografia" />
                        </div>
                        <div class="form-group">
                            <label>Dirección</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDireccion" ControlToValidate="txtDireccion" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupLitografia" />
                        </div>
                        <div class="form-group">
                            <label>Teléfono</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="Rqtelefono" ControlToValidate="txtTelefono" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupLitografia" />
                        </div>

                        <div class="form-group">
                            <label>Usuario</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombreusuario" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNombreUsurio" ControlToValidate="txtNombreusuario" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupLitografia" />
                        </div>
                        <div class="form-group">
                            <label>Clave</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqClave" ControlToValidate="txtClave" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupLitografia" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary"  style="left: 0px; top: 0px; height: 580px">
                    <div class="box-body">

                        <div class="form-group">
                            <label>Estado</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dpEstado" runat="server" CssClass="form-control" DataTextField="Descripcion" DataValueField="IdEstado">
                                <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div id="labelLogoAgregarlitografia" class="form-group" runat="server">
                            <label>Logo</label>
                        </div>
                        <div id="LogoAgregarlitografia" class="form-group" runat="server">
                            <asp:FileUpload ID="fuploadImagen" runat="server" CssClass="form-control" />
                            <asp:Button ID="btnSubir" runat="server" Text="Cargar" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnSubir_Click" ValidationGroup="ValidationImagen" />
                        </div>
                        <br />
                        <div class="form-group" runat="server">
                            <asp:Image ID="Imglitografia" Width="200" Height="200" ImageUrl="https://image.freepik.com/iconos-gratis/cargar-documento_318-8461.jpg" runat="server" />
                        </div>
                    </div>

              
                </div>

            </div>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" ValidationGroup="ValidationGroupLitografia" OnClick="btnRegistrar_Click" />
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


