<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CapaPresentacion.Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE EMPLEADOS</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Tipo documento</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dpTipoDocumento" runat="server" CssClass="form-control" DataSourceID="DTipoDocumento" DataTextField="Descripcion" DataValueField="IdTipoDocumento"></asp:DropDownList>
                            <asp:SqlDataSource ID="DTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarTiposDeDocumento" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <div class="form-group">
                            <label>Documento</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNumeroDocumento" ControlToValidate="txtNumeroDocumento" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupEmpleado" />
                        </div>
                        <div class="form-group">
                            <label>Nómbres</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNombres" ControlToValidate="txtNombres" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupEmpleado" />
                        </div>
                        <div class="form-group">
                            <label>Apellidos</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqApellidos" ControlToValidate="txtApellidos" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupEmpleado" />
                        </div>
                        <div class="form-group">
                            <label>Edad</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Genero</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddLSexo" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                                <asp:ListItem Value="Femenino">Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Teléfono</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqTelefono" ControlToValidate="txtTelefono" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupEmpleado" />
                        </div>
                        <div class="form-group">
                            <label>Dirección</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDireccion" ControlToValidate="txtDireccion" ErrorMessage="Campo requerido." ValidationGroup="ValidationGroupEmpleado" />
                        </div>
                        <div class="form-group">
                            <label>Correo electrónico</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-group">
                            <label>Estado</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dpEstadoEmpleado" runat="server" CssClass="form-control" DataSourceID="DSEstadoEmpleados" DataTextField="Descripcion" DataValueField="IdEstado"></asp:DropDownList>
                            <asp:SqlDataSource ID="DSEstadoEmpleados" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarEstadosEmpleados" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>Usuario </label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Clave</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Tipo usuario</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DdlTipoUsuario" runat="server" CssClass="form-control" DataSourceID="DSTiposUsuarios" DataTextField="Descripcion" DataValueField="IdTipoUsuario"></asp:DropDownList>
                            <asp:SqlDataSource ID="DSTiposUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarTiposUsuarios" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValidationGroupEmpleado" />
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


