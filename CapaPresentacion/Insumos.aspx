<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Insumos.aspx.cs" Inherits="CapaPresentacion.Insumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE INSUMOS</h1>
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
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDescripcion" ControlToValidate="txtDescripcion" ErrorMessage="Campo requerido." ValidationGroup="ValidationInsumos" />
                        </div>
                        <div class="form-group">
                            <label>Cantidad</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCantidad" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="ValidationInsumos" />
                        </div>

                        <div class="form-group">
                            <label>Valor unitario</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqValor" ControlToValidate="txtValor" ErrorMessage="Campo requerido." ValidationGroup="ValidationInsumos" />
                        </div>
                        <div class="form-group">
                            <label>Valor total</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorTotal" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqValorTotal" ControlToValidate="txtValorTotal" ErrorMessage="Campo requerido." ValidationGroup="ValidationInsumos" />
                        </div>
                        <div class="form-group">
                            <label>Observacion</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>
         <div align="center">
                                <table>
                                    <tr>
                                         <td>
                                            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValidationInsumos"  />
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


