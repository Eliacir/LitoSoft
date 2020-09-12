<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarImagenes.aspx.cs" Inherits="CapaPresentacion.GestionarImagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1 style="text-align: center">GESTION DE COTIZACION</h1>
    </section>--%>
     <div class="col-md-12">
                         <asp:Button ID="btnAtras" runat="server" Text="Atras" CssClass="btn btn-primary" Width="150px" OnClick="btnAtras_Click1" />
            <br />
         </div>

    <section class="content">
        <!--Visualizar La imagen a subir -->
        <div class="row">

            <div class="col-md-6">
                <%--     <label>Imagen Agregada:</label>
                <br />
                <asp:Image ID="ImgPreviw" Width="200" ImageUrl="https://image.freepik.com/iconos-gratis/cargar-documento_318-8461.jpg" runat="server" />
                <br />
                <br />--%>
                <label>Proyecto:</label>
                <asp:DropDownList ID="ddlProyectos" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <br />
                <label>Seleccione la imagen:</label>
                <asp:FileUpload ID="fuploadImagen" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqImagen" ControlToValidate="fuploadImagen" ErrorMessage="Campo requerido." ValidationGroup="ValidationImagen" />
                <br />
                <label>Titulo de imagen:</label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqTitulo" ControlToValidate="txtTitulo" ErrorMessage="Campo requerido." ValidationGroup="ValidationImagen" />
                <br />
                <label>Numero de Imagen:</label>
                <asp:TextBox ID="txtNumeroImagen" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqNumeroImagen" ControlToValidate="txtNumeroImagen" ErrorMessage="Campo requerido." ValidationGroup="ValidationImagen" />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSubir" runat="server" Text="Registrar" CssClass="btn btn-primary" Width="150px" OnClick="btnSubir_Click" ValidationGroup="ValidationImagen" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="150px" Text="Eliminar Imagenes" OnClick="btnCancelar_Click" OnClientClick="return confirm('Realmente desea eliminar las imagenes de este proyecto?')" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--Visualizar todas las imagenes disponibles en la BD -->
        <div class="row">
            <section class="content-header">
                <h2 class="col-md-12">
                    <label id="lblImagenesProyecto">Imagenes del proyecto</label></h2>
            </section>
            <div class="col-md-12">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3">

                            <img class="img-responsive" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"Imagen")) %>" />
                            <%# DataBinder.Eval(Container.DataItem,"Tituloimagen")%>
                            <br />
                            <br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>


