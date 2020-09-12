<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="CapaPresentacion.Proyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE PROYECTOS</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Cliente</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DDLClientes" runat="server" CssClass="form-control" DataSourceID="DSClientes" DataTextField="Nombre" DataValueField="IdCliente"></asp:DropDownList>
                            <asp:SqlDataSource ID="DSClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>

                        <div class="form-group">
                            <label>Nómbre</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNombre" ControlToValidate="txtNombre" ErrorMessage="Campo requerido." ValidationGroup="ValidationProyectos" />
                        </div>
                        <div class="form-group">
                            <label>Descripción</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <%--                <div class="box-header">
                    <h3 class="box-title">Registrar proyecto</h3>
                </div>--%>
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>Area solicitante</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtArea" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Estado</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dpEstadoProyecto" runat="server" CssClass="form-control" DataSourceID="DSEstadoProyecto" DataTextField="Descripcion" DataValueField="IdEstado"></asp:DropDownList>
                            <asp:SqlDataSource ID="DSEstadoProyecto" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarEstadosProyecto" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <br />
                        <div class="form-group">
                            <label>Empleado</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEmpleados" runat="server" CssClass="form-control" DataSourceID="SqlDSEmpleados" DataTextField="Nombre" DataValueField="IdEmpleado">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDSEmpleados" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarEmpleados" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValidationProyectos" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        </div>

    </section>
</asp:Content>


