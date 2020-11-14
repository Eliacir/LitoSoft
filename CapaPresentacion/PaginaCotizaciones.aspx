<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PaginaCotizaciones.aspx.cs" Inherits="CapaPresentacion.PaginaCotizaciones" %>

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
                        <asp:DropDownList ID="DDFiltro" runat="server" Width="18%" Height="30px" AutoPostBack="False">
                            <asp:ListItem>Buscar por...</asp:ListItem>
                            <asp:ListItem>Código</asp:ListItem>
                            <asp:ListItem>Nómbre</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtfiltro" runat="server" Width="30%" Height="30px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarRepresentante" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarCotizaciones_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvCotizacion" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdCotizacion" OnRowCommand="GvCotizacion_RowCommand" OnRowCreated="GvCotizacion_RowCreated" AllowSorting="True" OnPageIndexChanging="GvCotizacion_PageIndexChanging" OnSorting="GvCotizacion_Sorting">
                            <Columns>
                                <asp:BoundField DataField="IdCotizacion" HeaderText="IdCotizacion" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="CodigoCotizacion" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="CodigoCotizacion" />
                                <asp:BoundField DataField="Decripcion" HeaderText="Decripcion" SortExpression="Decripcion" />         
                                <asp:TemplateField HeaderText="Imprimir">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgPdf" runat="server" ImageUrl="~/img/pdf.png"
                                            ToolTip="Imprimir" CausesValidation="true" CommandName="Imprimir"></asp:ImageButton>
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


