<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarClientes.aspx.cs" Inherits="CapaPresentacion.GestionarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">Registro de cliente</h1>
    </section>--%>
    <section class="content">

        <div class="row">
            <div class="col-md-3">
                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/img/Agregar.png" ToolTip="Agregar" OnClick="btnAgregar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
         
                    <asp:MultiView ID="MultiView" runat="server">
                        <asp:View ID="viewRegistro" runat="server">
                            <br />
                            <div class="col-md-3" id="vistaNuevo" runat="server">
                                <div class="form-group">
                                    <label id="lblNombre" runat="server">Nómbre</label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDescripcion" ControlToValidate="txtnombre" ErrorMessage="Campo requerido." ValidationGroup="VGcliente" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label id="lbldocumento" runat="server">Nro. Documento</label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtdocumento" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDocumento" ControlToValidate="txtdocumento" ErrorMessage="Campo requerido." ValidationGroup="VGcliente" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label id="lbltelefono" runat="server">Teléfono</label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqTelefono" ControlToValidate="txttelefono" ErrorMessage="Campo requerido." ValidationGroup="VGcliente" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label id="lbldireccion" runat="server">Dirección</label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDireccion" ControlToValidate="txtDireccion" ErrorMessage="Campo requerido." ValidationGroup="VGcliente" />
                                </div>
                            </div>
                            <div align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" ValidationGroup="VGcliente" OnClick="btnRegistrar_Click" />
                                        </td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>

                        </asp:View>
                        <asp:View ID="viewTabla" runat="server">
                        </asp:View>
                    </asp:MultiView>

                    <!--datatable -->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box box-primary">
                                <div class="box-header">
                                    <h3 class="box-title">Lista de Clientes</h3>
                                </div>
                                <div class="box-body table-responsive">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DDFiltro" runat="server" Width="150px" Height="30px" AutoPostBack="False">
                                                    <asp:ListItem>Buscar por...</asp:ListItem>
                                                    <asp:ListItem>Número Documento</asp:ListItem>
                                                    <asp:ListItem>Nómbre</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                                <asp:TextBox ID="txtfiltro" runat="server" CssClass="form-control"  Width="300px" Height="30px"></asp:TextBox>
                                            </td>
                                            <td>


                                                 <asp:Button ID="btnBuscarRepresentante" runat="server" Text="Buscar" CssClass="btn btn-primary"  OnClick="btnBuscar_Click" />

                                            </td>
                                        </tr>
                                    </table>
         

           
                                </div>
                                <div class="box-body table-responsive">
                                    <asp:GridView ID="GvCliente" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdCliente" OnRowCommand="GvCliente_RowCommand" AllowSorting="True" OnPageIndexChanging="GvCliente_PageIndexChanging" OnSorting="GvCliente_Sorting"
                                        EmptyDataText="No hay clientes para mostrar">
                                        <Columns>
                                            <asp:BoundField DataField="IdCliente" ReadOnly="True" InsertVisible="False" SortExpression="IdCliente" HeaderText="Id" ItemStyle-HorizontalAlign="Center" Visible="False" />
                                            <asp:BoundField DataField="Codigo" HeaderText="Número" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nómbre" />
                                            <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                            <asp:TemplateField HeaderText="Cotizaciones">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgDetalleC" runat="server" ImageUrl="~/img/DetalleCotizacion.png"
                                                        ToolTip="Cotizaciones" CausesValidation="true" CommandName="Cotizaciones"></asp:ImageButton>
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
                                </div>

                            </div>
                        </div>
                    </div>
      
            </div>
        </div>

    </section>



    <script type="text/javascript">
</script>
</asp:Content>


