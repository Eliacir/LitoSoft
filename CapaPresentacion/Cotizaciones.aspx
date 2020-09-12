<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Cotizaciones.aspx.cs" Inherits="CapaPresentacion.Cotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE COTIZACIONES</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Código Cotización</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCodigoCotizacion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCotizacion" ControlToValidate="txtCodigoCotizacion" ErrorMessage="Campo requerido." ValidationGroup="ValidationCotizacion" />
                        </div>
                        <div class="form-group">
                            <label>Proyecto</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dpProyecto" runat="server" CssClass="form-control" DataSourceID="DProyecto" DataTextField="Nombre" DataValueField="IdProyecto"></asp:DropDownList>
                            <asp:SqlDataSource ID="DProyecto" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarProyectos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <div class="form-group">
                            <label>Alcance de la propuesta</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtAlcance" runat="server" CssClass="form-control" TextMode="MultiLine" Height="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqAlcance" ControlToValidate="txtAlcance" ErrorMessage="Campo requerido." ValidationGroup="ValidationCotizacion" />
                        </div>
                         <div class="form-group">
                            <label>Validez de la oferta</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValidezOferta" runat="server" CssClass="form-control" TextMode="MultiLine" Height="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqValidezOferta" ControlToValidate="txtValidezOferta" ErrorMessage="Campo requerido." ValidationGroup="ValidationCotizacion" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary" style="left: 0px; top: 0px">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Tiempo de entrega</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTiempoEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqTiempoEntrega" ControlToValidate="txtTiempoEntrega" ErrorMessage="Campo requerido." ValidationGroup="ValidationCotizacion" />
                        </div>
                        <div class="form-group">
                            <label>Lugar de entrega</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtLugarEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqLugarEntrega" ControlToValidate="txtLugarEntrega" ErrorMessage="Campo requerido." ValidationGroup="ValidationCotizacion" />
                        </div>
                        <div class="form-group">
                            <label>Garantía</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtGarantia" runat="server" CssClass="form-control" TextMode="MultiLine" Height="90px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Nota</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNota" runat="server" CssClass="form-control" TextMode="MultiLine" Height="90px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValidationCotizacion" />
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


