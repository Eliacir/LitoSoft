<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ImprimirCotizacion.aspx.cs" Inherits="CapaPresentacion.ImprimirCotizacion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <!--Visualizar La imagen a subir -->
        <div class="row">
            <div class="col-md-12">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1139px" Height="550px">
                    <LocalReport ReportPath="">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DsCotizacion" />              
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
            </div>

            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.dsPrincipalTableAdapters.RecuperarReporteCotizacionesPorIdTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter Name="IdCotizacion" QueryStringField="IdCotizacion" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </section>
</asp:Content>



