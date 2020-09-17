<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapaPresentacion.Default" %>

<!DOCTYPE html>

<html class="bg-dark" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />

    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/sweetalert.min.js" type="text/javascript"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="form-box" id="login-box">
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
                <LayoutTemplate>
                    <div class="header">Iniciar sesión</div>
                    <div class="body bg-gray">
                        <div class="form-group">
                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Ingrese usuario.."></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqUsuario" ControlToValidate="UserName" ErrorMessage="Debe ingrese su usuario" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Ingrese clave.." TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="text-red" ID="RqClave" ControlToValidate="Password" ErrorMessage="Debe ingrese su clave" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnIngresar" Text="Aceptar" CommandName="Login" runat="server" CssClass="btn bg-primary btn-block" />
                        </div>
                    </div>

                </LayoutTemplate>
            </asp:Login>
        </div>
    </form>
</body>
</html>
