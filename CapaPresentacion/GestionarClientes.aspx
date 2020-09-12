<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarClientes.aspx.cs" Inherits="CapaPresentacion.GestionarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE CLIENTES</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregarCliente" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar Cliente" OnClick="btnAgregarCliente_Click" />
            </div>
        </div>

        <br />
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Clientes</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <asp:DropDownList ID="DDFiltro" runat="server" Width="18%" Height="30px" AutoPostBack="False">
                            <asp:ListItem>Buscar por...</asp:ListItem>
                            <asp:ListItem>Número Documento</asp:ListItem>
                            <asp:ListItem>Nombre</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtfiltro" runat="server" Width="50%" Height="30px" OnTextChanged="txtfiltro_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarRepresentante" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarRepresentante_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvCliente" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdCliente" OnRowCommand="GvCliente_RowCommand" AllowSorting="True" OnPageIndexChanging="GvCliente_PageIndexChanging" OnSorting="GvCliente_Sorting">
                            <Columns>
                                <asp:BoundField DataField="IdCliente" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="IdCliente" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nómbre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Ruc" HeaderText="Documento" SortExpression="Ruc" />
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
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


