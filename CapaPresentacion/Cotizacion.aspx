﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="CapaPresentacion.Cotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--   usamos para filtrar en control--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"></script>
    <link href=" https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    <script type="text/javascript">

</script>
    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE COTIZACIÓN</h1>
    </section>

    <section class="content">
        <div class="box box-primary" style="left: 0px; top: 0px; height: 861px">
            <div class="box-body">
                <!--VALORES JS-->
                <asp:HiddenField ID="txtpapelextra" runat="server" />
                <asp:HiddenField ID="txtDividendo" runat="server" />
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
                            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" onchange="impresionesTotal()"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqCantidad" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Tamaño</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txttamano" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="Rqtamano" ControlToValidate="txttamano" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Cavidad</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCavidad" runat="server" TextMode="Number" onchange="impresionesTotal()"></asp:TextBox>
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
                            <label>Valore plancha</label>
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
                        <div>
                            <asp:TextBox ID="txtFrente" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Respaldo</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRespaldo" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Misma Plancha</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddMismaplancha" runat="server" DataTextField="Corte" DataValueField="Montaje">
                                <asp:ListItem Value="Seleccionar">Seleccionar</asp:ListItem>
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />

                <%--               ACABADOS--%>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="btnAcabados" runat="server" Width="158px" ForeColor="White" BorderColor="#357ebd" Text="Mostrar acabados" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnAcabados_Click" />

                        <asp:MultiView ID="MultiView" runat="server">
                            <asp:View ID="VDatos" runat="server">

                                <div class="row">
                                    <br />
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Cantidad</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" onchange="impresionesTotal()"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RequiredFieldValidator1" ControlToValidate="txtCantidad" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Tamaño</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RequiredFieldValidator2" ControlToValidate="txttamano" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Cavidad</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" onchange="impresionesTotal()"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RequiredFieldValidator3" ControlToValidate="txtCavidad" ErrorMessage="Campo requerido." ValidationGroup="vgcotizacion" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Precio Papel</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Frente</label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox11" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Respaldo</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox12" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Misma Plancha</label>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="Corte" DataValueField="Montaje">
                                                <asp:ListItem Value="Seleccionar">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="VOcultar" runat="server"></asp:View>
                        </asp:MultiView>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Total Factura</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTotalfactura" runat="server" Enabled="False"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="btnCalcular" runat="server" Width="100px" BackColor="#428bca" ForeColor="White" BorderColor="#357ebd" Text="Calcular" BorderStyle="None" CssClass="btn btn-primary" Height="32px" OnClick="btnCalcular_Click" />
                        &nbsp;
                        <asp:Button ID="bntLimpiar" runat="server" Width="100px" ForeColor="White" BorderColor="#357ebd" Text="Limpiar" BorderStyle="None" CssClass="btn btn-success" Height="32px" OnClick="bntLimpiar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script>
        $('#<%=ddCorte.ClientID%>').chosen();
        $('#<%=ddSustrato.ClientID%>').chosen();
        $('#<%=ddClientes.ClientID%>').chosen();


        function impresionesTotal() {
            //Calcular impresiones imprTotales
            cantidad = $('#<%=txtCantidad.ClientID%>').val();
            cavidad = $('#<%=txtCavidad.ClientID%>').val();
            papelextra = $('#<%=txtpapelextra.ClientID%>').val();
            impresionesTotales = (cantidad / cavidad) + parseInt(papelextra);
            $('#<%=txtImpresionestotales.ClientID%>').val(impresionesTotales);

            //Calcular cantidad de pliegos
            var imprTotales = $('#<%=txtImpresionestotales.ClientID%>').val();
            var dividendo = $('#<%=txtDividendo.ClientID%>').val();
            cantidadPliegos = imprTotales / parseInt(dividendo);
            cantidadPliegos = Math.trunc(cantidadPliegos);
            $('#<%=txtCantidadpliego.ClientID%>').val(cantidadPliegos);
        }
    </script>
</asp:Content>


