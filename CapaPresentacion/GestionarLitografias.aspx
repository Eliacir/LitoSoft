<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarLitografias.aspx.cs" Inherits="CapaPresentacion.GestionarLitografias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE LITOGRAFIA</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregarCliente" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar Litografia" OnClick="btnAgregarLitografia_Click" />
            </div>
        </div>

        <br /> 
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Litografias</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <asp:TextBox ID="txtfiltro" runat="server" Width="35%" Height="30px" OnTextChanged="txtfiltro_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarLitografia" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarLitografias_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvLitografia" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdLitografia" OnRowCommand="GvLitografia_RowCommand" AllowSorting="True" OnPageIndexChanging="GvCliente_PageIndexChanging" OnSorting="GvCliente_Sorting">
                            <Columns>
                                <asp:BoundField DataField="IdLitografia" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="IdLitografia" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nómbre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgActualizar" runat="server" ImageUrl="~/img/Editar.png"
                                            ToolTip="Editar" CausesValidation="true" CommandName="Actualizar"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgEliminar" runat="server" OnClientClick="return confirm('Realmente desea eliminar litografia?')" ImageUrl="~/img/Eliminar.png"
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


