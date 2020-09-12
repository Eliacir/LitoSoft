<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarInsumos.aspx.cs" Inherits="CapaPresentacion.GestionarInsumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE INSUMOS</h1>
    </section>--%>
    <section class="content">
         <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregarInsumo" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar insumo" OnClick="btnAgregarInsumo_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Proyectos</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlProyectos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProyectos_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="box-header">
                            <h3 class="box-title">Lista de insumos</h3>
                        </div>
                        <div class="box-body table-responsive">
                            <asp:GridView ID="GvInsumos" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdDetalleProyecto" OnRowCreated="GvInsumos_RowCreated" OnRowCommand="GvInsumos_RowCommand" AllowSorting="True">
                                <Columns>
                                    <asp:BoundField DataField="IdDetalleProyecto" HeaderText="Código" SortExpression="IdDetalleProyecto"/>
                                    <asp:BoundField DataField="IdProyecto" HeaderText="Código proyecto" SortExpression="IdProyecto" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitario" SortExpression="ValorUnitario"/>
                                    <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" SortExpression="ValorTotal" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observación" SortExpression="Observacion" />
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgActualizar" runat="server" ImageUrl="~/Img/Editar.png"
                                                ToolTip="Editar" CausesValidation="true" CommandName="Actualizar"></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEliminar" runat="server" OnClientClick="return confirm('Realmente desea eliminar el cliente?')" ImageUrl="~/img/Eliminar.png"
                                                ToolTip="Eliminar" CommandName="Eliminar"></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>


