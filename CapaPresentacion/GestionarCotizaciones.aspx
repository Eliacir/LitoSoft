<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarCotizaciones.aspx.cs" Inherits="CapaPresentacion.GestionarCotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE COTIZACIONES</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregarCotizacion" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar Cotización" OnClick="btnAgregarCotizacion_Click" />
            </div>
        </div>

        <br />
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Cotizaciones</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <asp:DropDownList ID="DDFiltro" runat="server" Width="18%" Height="30px" AutoPostBack="False">
                            <asp:ListItem>Buscar por...</asp:ListItem>
                            <asp:ListItem>Código</asp:ListItem>
                            <asp:ListItem>Proyecto</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtfiltro" runat="server" Width="50%" Height="30px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarRepresentante" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarCotizaciones_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvCotizacion" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdCotizacion" OnRowCommand="GvCotizacion_RowCommand" OnRowCreated="GvCotizacion_RowCreated" AllowSorting="True" OnPageIndexChanging="GvCotizacion_PageIndexChanging" OnSorting="GvCotizacion_Sorting">
                            <Columns>
                                <asp:BoundField DataField="IdCotizacion" HeaderText="IdCotizacion" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="CodigoCotizacion" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="CodigoCotizacion" />
                                <asp:BoundField DataField="NombreProyecto" HeaderText="Proyecto" SortExpression="NombreProyecto" />
                                <asp:BoundField DataField="AlcancePropuesta" HeaderText="Alcance Propuesta" SortExpression="AlcancePropuesta" />
                                <asp:BoundField DataField="ValidezOferta" HeaderText="Validez Oferta" SortExpression="ValidezOferta" />
                                <asp:BoundField DataField="TiempoEntrega" HeaderText="Tiempo Entrega" SortExpression="TiempoEntrega" />
                                <asp:BoundField DataField="LugarEntrega" HeaderText="Lugar Entrega" SortExpression="LugarEntrega" />
                                <asp:BoundField DataField="Garantia" HeaderText="Garantía" SortExpression="Garantia" />
                                <asp:BoundField DataField="Nota" HeaderText="Nota" SortExpression="NombreProyecto" />

                                <asp:TemplateField HeaderText="Detalle Cotización">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDetalleC" runat="server" ImageUrl="~/img/DetalleCotizacion.png"
                                            ToolTip="Detalle Cotización" CausesValidation="true" CommandName="DetalleCotizacion"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Generar Pdf">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgPdf" runat="server" ImageUrl="~/img/pdf.png"
                                            ToolTip="GenerarPdf" CausesValidation="true" CommandName="GenerarPdf"></asp:ImageButton>
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
    </section>
</asp:Content>


