<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DetalleCotizacion.aspx.cs" Inherits="CapaPresentacion.DetalleCotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION MANO DE OBRA</h1>
    </section>--%>

<div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingOne">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
          Detalle Insumos
        </a>
      </h4>
    </div>
    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
      <div class="panel-body">
         

              <section class="content">

        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAtras" runat="server" CssClass="btn btn-primary" Width="200px" Text="Atras" OnClick="btnAtras_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label>Descripción</label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqDescripcion" ControlToValidate="txtDescripcion" ErrorMessage="Campo requerido." ValidationGroup="ValidationDetalleCotizacion" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>Cantidad</label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCantidad" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="ValidationDetalleCotizacion" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>Valor unitario</label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtValorUnitario" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqValorUnitario" ControlToValidate="txtValorUnitario" ErrorMessage="Campo requerido." ValidationGroup="ValidationDetalleCotizacion" />
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <label></label>
                </div>
                <div class="form-group">
                    <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/img/Agregar.png" OnClick="btnAgregar_Click" ValidationGroup="ValidationDetalleCotizacion" ToolTip="Agregar" />
                    <asp:ImageButton ID="btnActualizar" runat="server" ImageUrl="~/img/Editar.png" ValidationGroup="ValidationDetalleCotizacion" ToolTip="Actualizar" Visible="false" OnClick="btnActualizar_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="box-header">
                            <h3 class="box-title">Lista detalle cotización</h3>
                        </div>
                                             <div class="box-body table-responsive">
                        <asp:DropDownList ID="DDFiltro" runat="server" Width="18%" Height="30px" AutoPostBack="False">
                            <asp:ListItem>Buscar por...</asp:ListItem>
                            <asp:ListItem>Cotización</asp:ListItem>
                            <asp:ListItem>Descripcion</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtfiltro" runat="server" Width="50%" Height="30px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscarRepresentante" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Buscar" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnBuscarRepresentante_Click" />
                    </div>
                        <div class="box-body table-responsive">
                            <asp:GridView ID="GvDetalleCotizacion" runat="server" class="table table-bordered" AutoGenerateColumns="False" DataKeyNames="IdDetalleCotizacion" OnRowCommand="GvDetalleCotizacion_RowCommand" OnRowCreated="GvDetalleCotizacion_RowCreated" AllowSorting="True">
                                <Columns>
                                    <asp:BoundField DataField="CodigoCotizacion" HeaderText="Cotización" InsertVisible="False" ReadOnly="True" SortExpression="CodigoCotizacion" />
                                    <asp:BoundField DataField="IdDetalleCotizacion" HeaderText="Item" SortExpression="IdDetalleCotizacion" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitario" SortExpression="ValorUnitario" />
                                    <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" SortExpression="ValorTotal" />
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgActualizar" runat="server" ImageUrl="~/img/Editar.png"
                                                ToolTip="Editar" CausesValidation="true" CommandName="Actualizar"></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEliminar" runat="server" OnClientClick="return confirm('Realmente desea eliminar item?')" ImageUrl="~/img/Eliminar.png"
                                                ToolTip="Eliminar" CommandName="Eliminar"></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
<%--                            <asp:SqlDataSource ID="dsGVDetalleCotizacio" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConn %>" SelectCommand="RecuperarDetalleCotizacion" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

      </div>
    </div>
  </div>
<%--  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingTwo">
      <h4 class="panel-title">
        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
          Collapsible Group Item #2
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
      <div class="panel-body">
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingThree">
      <h4 class="panel-title">
        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
          Collapsible Group Item #3
        </a>
      </h4>
    </div>
    <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
      <div class="panel-body">
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
      </div>
    </div>
  </div>--%>
</div>

</asp:Content>


