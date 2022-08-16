<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="PersonaUsuario.aspx.cs" Inherits="PresupuestoFamiliar.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/PersonaUser.css" rel="stylesheet" />

    <div class="contentplace">
        <div class="Gridview1">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

            <div class="Persona-style">
            <p>
                ID:
        <asp:TextBox ID="tId" runat="server" Style="margin-left: 47px"></asp:TextBox>
            </p>
            <p>
                Cédula:
        <asp:TextBox ID="tCedula" runat="server" Style="margin-left: 19px"></asp:TextBox>
            </p>
            <p>
                Nombre:
        <asp:TextBox ID="tNombre" runat="server" Style="margin-left: 11px"></asp:TextBox>
            </p>
            <p>
                Apellido:
        <asp:TextBox ID="tApellido" runat="server" Style="margin-left: 11px"></asp:TextBox>
            </p>
            <p>
                Dirección:<br />
                <asp:TextBox ID="tDireccion" runat="server" Style="margin-left: 4px" TextMode="MultiLine" Height="70px"></asp:TextBox>
            </p>
            <p>
                Teléfono:
        <asp:TextBox ID="tTelefono" runat="server" Style="margin-left: 9px"></asp:TextBox>
            </p>

            <div class="PadreButtons">
                <asp:Button CssClass="button button1" Style="margin-left: 10px" ID="bModificarPerson" runat="server" Text="Modificar" OnClick="bModificarPerson_Click1" />
                <asp:Button CssClass="button button2" Style="margin-left: 10px" ID="bConsultarPerson" runat="server" Text="Consultar" OnClick="bConsultarPerson_Click" />
                <asp:Button class="button button3" Style="margin-left: 10px" ID="bBorrarPerson" runat="server" Text="Borrar" OnClick="bBorrarPerson_Click" />
            </div>

        </div>

        </div>
        <div class="auto-style1">
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

             <div class="auto-style2">
            <p>
                Correo:
            <asp:TextBox ID="tCorreo" runat="server" Style="margin-left: 33px"></asp:TextBox>
            </p>
            <p>
                Clave:
            <asp:TextBox ID="tClave" runat="server" Style="margin-left: 43px"></asp:TextBox>
            </p>
            <p>
                Tipo Usuario:
            <asp:DropDownList ID="dTipoUser" runat="server" Height="21px" OnSelectedIndexChanged="dTipoUser_SelectedIndexChanged">
                <asp:ListItem Value="2">Regular</asp:ListItem>
                <asp:ListItem Value="1">Administrador</asp:ListItem>
            </asp:DropDownList>
            </p>

            <div class="PadreButtons2">
                <asp:Button class="button button1" Style="margin-left: 10px" ID="bModificarUser" runat="server" Text="Modificar" OnClick="bModificarUser_Click" />
                <asp:Button class="button button2" Style="margin-left: 10px" ID="bConsultarUser" runat="server" Text="Consultar" OnClick="bConsultarUser_Click" />
                <asp:Button class="button button3" Style="margin-left: 10px" ID="bBorrarUser" runat="server" Text="Borrar" OnClick="bBorrarUser_Click" />
            </div>

        </div>

        </div>

        <div class="register-style">
            Registrar una nueva persona y usuario,<br /> llenar campos de Persona y Usuario<br />
            <asp:Button CssClass="registro-estilo" ID="bRegister" runat="server" Text="Registrar" OnClick="bRegister_Click" />
        </div>

    </div>

</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 0;
            right: 0;
            width: 520px;
    /*display:inline-block;*/
    /*position:absolute;
    width:231px;
    top:0px;
    right:110px;
    margin-right:70px;
    margin-left:470px  */
        }
        .auto-style2 {
            /* position: absolute;
    right:20px;
    top:200px;*/
        width: 385px;
        }
    </style>
</asp:Content>



