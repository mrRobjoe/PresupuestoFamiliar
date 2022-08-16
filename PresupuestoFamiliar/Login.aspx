<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresupuestoFamiliar.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Css/LoginEstilos.css" rel="stylesheet" />
    <title>Login</title>
	<meta http-equiv="content-type" content="text/html"; charset="utf-8" />
</head>
<body>
    <div id="wrapper">

	<form name="login-form" class="login-form" action="#" method="post" runat="server">
	
		<div class="header">
		<h1>Iniciar Sesión</h1>
		<span>Si no tiene un correo y clave registre su información y usuario.</span>
		</div>
	
		<div class="content">	
		<asp:TextBox ID="tCorreo" name="username" class="input username" runat="server" placeholder="Correo electrónico" />
		<div class="user-icon"></div>
		<asp:TextBox ID="tClave" name="password" Class="input password" runat="server" placeholder="Clave" />
		<div class="pass-icon"></div>		
		</div>

		<div class="footer">
        <asp:Button ID="bIniciarSesion" type="submit" name="submit" Text="Iniciar sesión" Class="button" runat="server" OnClick="bIniciarSesion_Click" />
		<asp:Button ID="bRegistrar" type="submit" name="submit" Text="Registrarse" Class="register" runat="server" OnClick="bRegistrar_Click" />
		</div>
	
	</form>

</div>
<div class="gradient"></div>
</body>
</html>
