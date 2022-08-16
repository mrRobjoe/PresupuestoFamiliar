<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PresupuestoFamiliar.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Css/RegisterLogin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="centrar" class="loginF">
            <div class="header">
                <h1>Registrarse</h1>
                </div>

            <div class="content">
                <p>
                    Cédula:
                    <asp:TextBox Class="texto" ID="tCedula" runat="server" OnTextChanged="tCedula_TextChanged" />
                </p>
                <p>
                    Nombre:
                    <asp:TextBox Class="texto" ID="tNombre" runat="server" OnTextChanged="tNombre_TextChanged" />
                </p>             
                <p>              
                    Apellido:    
                    <asp:TextBox Class="texto" ID="tApellido" runat="server" OnTextChanged="tApellido_TextChanged" />
                </p>             
                <p>              
                    Dirección:   
                    <asp:TextBox ID="tDireccion" runat="server" TextMode="multiline" OnTextChanged="tDireccion_TextChanged" />
                </p>             
                <p>              
                    Teléfono:    
                    <asp:TextBox Class="texto" ID="tTelefono" runat="server" OnTextChanged="tTelefono_TextChanged" />
                </p>
                <p>
                    Correo:
                    <asp:TextBox Class="texto" ID="tCorreo" runat="server" OnTextChanged="tCorreo_TextChanged" />
                </p>
                <p>
                    Clave:
                    <asp:TextBox Class="texto" ID="tClave" runat="server" OnTextChanged="tClave_TextChanged" />
                </p>
                <!--<p>
                    Id Usuario:
                    <asp:TextBox Class="texto" ID="tIdUser" runat="server" />
                </p>-->
                <p>
                    Tipo Usuario:         
                    <asp:DropDownList ID="dTipoUser" runat="server" Height="21px" OnSelectedIndexChanged="dTipoUser_SelectedIndexChanged">
                        <asp:ListItem Value="2">Regular</asp:ListItem>
                        <asp:ListItem Value="1">Administrador</asp:ListItem>
                    </asp:DropDownList>
                    
                </p>
            </div>
            <div class="footer">
                  <asp:Button Class="button button1" Text="Registrar" ID="bRegistrar" runat="server" OnClick="bRegistrar_Click" />
              
                <p class="cent">
                    <a href="Login.aspx">Iniciar sesión</a>
                </p>
            </div>

        </div>
    </form>
</body>
</html>
