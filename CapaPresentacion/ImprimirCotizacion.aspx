﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ImprimirCotizacion.aspx.cs" Inherits="CapaPresentacion.ImprimirCotizacion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">

        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnAtras" OnClick="btnAtras_Click" runat="server" CssClass="btn btn-primary" Width="150px" Text="Atrás" />
            </div>
        </div>

        <br />
        <!--Visualizar La imagen a subir -->
        <div class="row">
            <div class="col-md-12">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1139px" Height="550px">
                    <LocalReport ReportPath="Cotización.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsCotizacion" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DsAcabadosCotizacion" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
            </div>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.dsPrincipalTableAdapters.RecuperarCotizacionPorIdCotizacionTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter Name="IdCotizacion" QueryStringField="IdCotizacion" Type="Int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.dsPrincipalTableAdapters.RecuperarAcabadosCotizacionPorIdCotizacionTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="IdCotizacion" QueryStringField="IdCotizacion" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </section>
</asp:Content>



