<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PaginaCotizaciones.aspx.cs" Inherits="CapaPresentacion.PaginaCotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE COTIZACIONES</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:ImageButton ID="btnAgregarCotizacion" runat="server" ImageUrl="~/img/Agregar.png" ToolTip="Agregar" OnClick="btnAgregarCotizacion_Click" />
            </div>
        </div>
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Cotizaciones</h3>
                    </div>

                    <div class="box-body table-responsive">
                        <table>
                            <tr>
                                <td >
                                    <asp:DropDownList ID="DDFiltro" runat="server" Width="150px" Height="30px" AutoPostBack="False">
                                        <asp:ListItem>Buscar por ...</asp:ListItem>
                                        <asp:ListItem>Producto</asp:ListItem>
                                        <asp:ListItem>Papel</asp:ListItem>
                                    </asp:DropDownList>
                                           
                                </td>
                               
                                <td>
                                    <asp:TextBox ID="txtfiltro" runat="server" CssClass="form-control" Width="300px" Height="30px"></asp:TextBox>                                                                           
                                </td>
                            
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary"  OnClick="btnBuscarCotizaciones_Click" />
                                </td>
                            </tr>
                        </table>         
                    </div>



                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvCotizacion" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdCotizacion" OnRowCommand="GvCotizacion_RowCommand" OnRowCreated="GvCotizacion_RowCreated" AllowSorting="True" OnPageIndexChanging="GvCotizacion_PageIndexChanging" OnSorting="GvCotizacion_Sorting"
                            EmptyDataText="No hay cotizaciones para mostrar">
                            <Columns>
                                <asp:BoundField DataField="IdCotizacion" HeaderText="IdCotizacion" InsertVisible="False" ReadOnly="True" Visible="false" />

                                <asp:BoundField DataField="Cliente" HeaderText="Cliente Cotización" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                <asp:BoundField DataField="Papel" HeaderText="Papel" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="CostoDiseno" HeaderText="Costo Diseño" />
                                <asp:BoundField DataField="TotalAcabados" HeaderText="Total Acabados" />
                                <asp:BoundField DataField="SubtotalFactura" HeaderText="Subtotal Factura" />
                                <asp:BoundField DataField="TotalFactura" HeaderText="Total Factura" />

                                <asp:TemplateField HeaderText="Imprimir">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgPdf" runat="server" ImageUrl="~/img/pdf.png"
                                            ToolTip="Imprimir" CausesValidation="true" CommandName="Imprimir"></asp:ImageButton>
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
    </section>
</asp:Content>


