<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PaginaCotizacion.aspx.cs" Inherits="CapaPresentacion.PaginaCotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 20px;
        }

        .auto-style4 {
            display: block;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 0px !important;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -webkit-border-radius: 0px !important;
            -moz-border-radius: 0px !important;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--ACABADOS--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"></script>
    <link href=" https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    <script type="text/javascript">

</script>
    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE COTIZACIÓN</h1>
    </section>

    <section class="content">
        <div class="box box-primary" style="left: 0px; top: 0px; height: 1600px">
            <div class="box-body">
                <!--VALORES JS-->
                <asp:HiddenField ID="txtRangoMillar" runat="server" />
                <asp:HiddenField ID="txtpapelextra" runat="server" />
                <asp:HiddenField ID="txtMontajeDecimal" runat="server" />
                <!--FIN VALORES JS-->
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Cliente</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddClientes" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="Precio" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Cantidad</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCantidad_OnTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCantidad" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Costo Diseño</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCostoDiseno" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCostoDiseno_OnTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCostodiseno" ControlToValidate="txtCostoDiseno" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Cavidad</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCavidad" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCavidad_OnTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCavidad" ControlToValidate="txtCavidad" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Sustrato</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddSustrato" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="Precio" AutoPostBack="True" OnSelectedIndexChanged="ddSustrato_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Precio Papel</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorpapel" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Corte X-Y</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddCorte" runat="server" CssClass="form-control" DataTextField="Corte" DataValueField="Montaje" AutoPostBack="True" OnSelectedIndexChanged="ddCorte_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Montaje</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMontaje" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Impresiones Totales</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtImpresionestotales" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Cantidad Pliegos</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidadpliego" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Valor plancha</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtvalorplancha" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Valor Impresión</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorImpresion" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Valor total en papel</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorTotalPapel" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Frente</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddFrente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddFrente_SelectedIndexChanged" Height="20px" Width="100px">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label id="lblValorfrente" runat="server">Cantidad Color Frente</label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtFrente" runat="server" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="txtFrente_OnTextChanged" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Respaldo</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddRespaldo" runat="server" DataTextField="Corte" DataValueField="Montaje" AutoPostBack="True" OnSelectedIndexChanged="ddRespaldo_SelectedIndexChanged" Height="20px" Width="100px">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label id="lblValorrespaldo" runat="server">Cantidad Color Respaldo</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRespaldo" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtRespaldo_OnTextChanged" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Misma Plancha</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddMismaplancha" runat="server" Height="20px" Width="100px" DataTextField="Corte" DataValueField="Montaje" AutoPostBack="True" OnSelectedIndexChanged="ddMismaplancha_SelectedIndexChanged">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Total Impresiones</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorTotalImpresiones" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Valor total en plancha</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtValorTotalplancha" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <br />

                <%-- ACABADOS--%>
                <div class="row">
                    <div class="col-md-12">
                        <%--   <asp:Button ID="btnAcabados" runat="server" Width="158px" ForeColor="White" BorderColor="#357ebd" Text="Mostrar acabados" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnAcabados_Click" />--%>

                        <asp:LinkButton ID="btnAcabados" runat="server" OnClick="btnAcabados_Click">Mostrar acabados</asp:LinkButton>
                        <br />
                        <br />
                        <asp:MultiView ID="MultiView" runat="server">
                            <asp:View ID="VDatos" runat="server">
                                <div>
                                    <table>
                                        <tr>
                                            <td class="auto-style3">
                                                <label>Descripción Acabado</label>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <label id="lblTituloValor1" runat="server">Frente</label>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <label id="lblTituloValor2" runat="server">Respaldo</label>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <label>Valor Acabado</label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddAcabados" runat="server" CssClass="auto-style4" DataTextField="Nombre" DataValueField="Precio" AutoPostBack="True" Width="329px" OnSelectedIndexChanged="ddAcabados_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddFrenteAcabado" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddFrenteAcabado_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="Si">Si</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddTipoToquelado" runat="server" AutoPostBack="false" Height="20px" Visible="false" Width="100px">
                                                    <asp:ListItem Value="Troquel">Troquel</asp:ListItem>
                                                    <asp:ListItem Value="Refile">Refile</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddRespaldoAcabado" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddRespaldoAcabado_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="Si">Si</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtValorToquelado" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtValorAcabado" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/img/Agregar.png" OnClick="btnAgregar_Click" ToolTip="Agregar" />

                                                <asp:ImageButton ID="btnActualizar" runat="server" ImageUrl="~/img/Editar.png" ToolTip="Actualizar" Visible="false" OnClick="btnActualizar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="row">                                   
                                        <div class="box-body table-responsive">
                                            <asp:GridView ID="GvAcabados" runat="server" class="table table-bordered" AutoGenerateColumns="False" AllowSorting="True" Width="818px" OnRowCommand="GvAcabados_RowCommand" OnRowCreated="GvAcabados_RowCreated" OnRowDataBound="GvAcabados_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="RowId" ReadOnly="True" visible="false" />                                                 
                                                    <asp:BoundField DataField="RowNumber" ReadOnly="True" HeaderText="Numero"  />
                                                    <asp:BoundField DataField="Acabado" ReadOnly="True" HeaderText="Acabado" />
                                                    <asp:BoundField DataField="Valor" ReadOnly="True" HeaderText="Valor"  />
                                                    <asp:BoundField DataField="Frente" ReadOnly="True" HeaderText="Frente" >
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Respaldo" ReadOnly="True" HeaderText="Respaldo">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipoTroquelado" HeaderText="Tipo Valor" ReadOnly="True" SortExpression="TipoTroquelado" />
                                                    <asp:BoundField DataField="ValorTroquelado" HeaderText="Valor" ReadOnly="True" SortExpression="ValorTroquelado" />
                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgActualizar" runat="server" CausesValidation="true" CommandName="Actualizar" ImageUrl="~/img/Editar.png" ToolTip="Editar" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eliminar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgEliminar" runat="server" CommandName="Eliminar" ImageUrl="~/img/Eliminar.png" OnClientClick="return confirm('Realmente desea eliminar acabado?')" ToolTip="Eliminar" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>                                 
                                </div>

                            </asp:View>
                            <asp:View ID="VOcultar" runat="server">
                            </asp:View>
                        </asp:MultiView>
                    </div>              
                </div>

                <br />
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Total Acabados</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTotalAcabados" runat="server" Enabled="False"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <table>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Total Factura</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtTotalfactura" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </td>
                         <td style="width: 10px"></td>
                         <td>
                            <div class="form-group">
                                <label>Porcentaje Ganancia</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPorcentajeGanancia" runat="server" AutoPostBack="true" OnTextChanged="txtPorcentajeGanancia_OnTextChanged"></asp:TextBox>
                            </div>
                        </td>
                      </tr>
                </table>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="btnGuardar" runat="server" Width="100px" Height="32px" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click"/>
                        &nbsp;
                        <asp:Button ID="bntLimpiar" runat="server" Width="100px" Height="32px" Text="Limpiar" CssClass="btn btn-primary" OnClick="bntLimpiar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        $('#<%=ddCorte.ClientID%>').chosen();
        $('#<%=ddSustrato.ClientID%>').chosen();
        $('#<%=ddClientes.ClientID%>').chosen();
        $('#<%=ddAcabados.ClientID%>').chosen();
    </script>
</asp:Content>


