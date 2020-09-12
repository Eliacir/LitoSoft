<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarEmpleados.aspx.cs" Inherits="CapaPresentacion.GestionarEmpleados" %>

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
        <h1 style="text-align: center">GESTION DE EMPLEADOS</h1>
    </section>--%>
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAgregarEmpleado" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar Empleado" OnClick="btnAgregarEmpleado_Click" />
            </div>
        </div>

        <br />
        <!--datatable -->
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de empleados</h3>
                    </div>
                     <div class="box-body table-responsive">
                        <asp:DropDownList ID="DDFiltro" runat="server" Width="18%" Height="30px" AutoPostBack="False">
                            <asp:ListItem>Buscar por...</asp:ListItem>
                            <asp:ListItem>Número Documento</asp:ListItem>
                            <asp:ListItem>Nombre</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtfiltro" runat="server" Width="50%" Height="30px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarRepresentante" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarRepresentante_Click" />
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GvEmpleado" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdEmpleado" OnRowCommand="GvEmpleado_RowCommand" OnRowCreated="GvEmpleado_RowCreated" AllowSorting="True" OnPageIndexChanging="GvEmpleado_PageIndexChanging" OnSorting="GvEmpleado_Sorting" >
                            <Columns>
                                <asp:BoundField DataField="IdEmpleado" HeaderText="Código" InsertVisible="False" ReadOnly="True"  SortExpression="Nombre" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nómbre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" SortExpression="NumeroDocumento"  />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo"  />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion"  />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"  SortExpression="Estado"  />
                                <asp:BoundField DataField="IdTipoDocumento" HeaderText="IdTipoDocumento" />
                                <asp:BoundField DataField="TipoDocumento" HeaderText="TipoDocumento" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="Clave" HeaderText="Clave" />
                                <asp:BoundField DataField="IdTipoUsuario" HeaderText="IdTipoUsuario" />
                                <asp:BoundField DataField="Edad" HeaderText="Edad" />
                                <asp:BoundField DataField="IdEstado" HeaderText="IdEstado"  SortExpression="IdEstado" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgActualizar" runat="server" ImageUrl="~/img/Editar.png"
                                            ToolTip="Editar" CausesValidation="true" CommandName="Actualizar"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEliminar" runat="server" OnClientClick="return confirm('Realmente desea eliminar el empleado?')" ImageUrl="~/img/Eliminar.png"
                                                ToolTip="Eliminar" CommandName="Eliminar"></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                      <%--  <asp:SqlDataSource ID="dsGVEmpleados" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarEmpleados" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


