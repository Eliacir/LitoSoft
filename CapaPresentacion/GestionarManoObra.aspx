<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarManoObra.aspx.cs" Inherits="CapaPresentacion.GestionarManoObra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION MANO DE OBRA</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregaManoObra" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar Mano de Obra" OnClick="btnAgregarManoObra_Click" />
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
                            <h3 class="box-title">Lista mano de obra</h3>
                        </div>
                        <div class="box-body table-responsive">
                            <asp:GridView ID="GvManoObra" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdManoObra" OnRowCreated="GvManoObra_RowCreated" OnRowCommand="GvManoObra_RowCommand" AllowSorting="True" OnPageIndexChanging="GvManoObra_PageIndexChanging" OnSorting="GvManoObra_Sorting">
                                <Columns>
                                    <asp:BoundField DataField="IdManoObra" HeaderText="Código mano de obra" SortExpression="IdManoObra" />
                                    <asp:BoundField DataField="IdProyecto" HeaderText="Código Proyecto" SortExpression="IdManoObra" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="CantidadPersonas" HeaderText="Número de Personas" SortExpression="Tiempo" />
                                    <asp:BoundField DataField="Tiempo" HeaderText="Tiempo" SortExpression="CantidadPersonas" />
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


