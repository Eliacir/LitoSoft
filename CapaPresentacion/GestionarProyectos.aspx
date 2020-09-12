<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarProyectos.aspx.cs" Inherits="CapaPresentacion.GestionarProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE PROYECTOS</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarProyecto" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar nuevo proyecto" OnClick="btnAgregarProyecto_Click" />
                &nbsp;&nbsp;                     
                  <asp:Button ID="btnCargarImagenes" runat="server" CssClass="btn btn-primary" Width="200px" Text="Cargar Imagenes" OnClick="btnCargarImagenes_Click" />
            </div>
        </div>
        <br />
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header" style="left: 0px; top: 0px">
                        <h3 class="box-title">Lista de proyectos</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <asp:TextBox ID="txtBuscar" runat="server" Width="50%" Height="30px" Placeholder="Nombre Proyecto..."></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBuscar" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscar_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvProyecto"
                            runat="server" class="table table-bordered" AutoGenerateColumns="False" OnRowCreated="GvProyecto_RowCreated" OnRowCommand="GvProyecto_RowCommand"  AllowSorting="True" OnPageIndexChanging="GvProyecto_PageIndexChanging" OnSorting="GvProyecto_Sorting">
                            <Columns>
                                <asp:BoundField DataField="IdProyecto" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="IdProyecto" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nómbre Proyecto" SortExpression="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                                <asp:BoundField DataField="IdEmpleado" HeaderText="IdEmpleado" SortExpression="IdEmpleado"/>
                                <asp:BoundField DataField="NombreEmpleado" HeaderText="Empleado" SortExpression="NombreEmpleado" />
                                <asp:BoundField DataField="IdCliente" HeaderText="IdCliente"   SortExpression="IdCliente"/>
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" SortExpression="NombreCliente" />
                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" SortExpression="ValorTotal" />

                                <asp:TemplateField HeaderText="Detalle Insumo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDetalleInsumo" runat="server" ImageUrl="~/img/Producto.png"
                                            ToolTip="Insumos" CausesValidation="true" CommandName="DetalleInsumo"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle Mano Obra">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDetalleManoObra" runat="server" ImageUrl="~/img/ManodeObra.png"
                                            ToolTip="Mano de obra" CausesValidation="true" CommandName="DetalleManoObra"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgActualizar" runat="server" ImageUrl="~/img/Editar.png"
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
          <%--              <asp:SqlDataSource ID="dsGVProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarProyectos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


