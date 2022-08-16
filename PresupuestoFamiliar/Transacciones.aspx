<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="PresupuestoFamiliar.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/TransaccionesEstilos.css" rel="stylesheet" />

    <div class="ajustar-Text">

        <div>
            <p>
                <b>Ingresar:</b>Para Ingresar transacción agregar todos los campos a excepción del ID.<br />
                <b>Borrar:</b>Para Borrar transacción agregar únicamente el ID.<br />
                <b>Modificar:</b>Para Modificar transacción llenar todos los campos<br />
                <b>Consultar:</b>Para Consultar transacción agregar únicamente el ID.
            </p>
        </div>

        <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

        <div class="transaccion-style">

            <p>
                Id:
            <asp:TextBox ID="tId" runat="server"></asp:TextBox>
            </p>
            <p>
                Tipo Transacción:
            <asp:DropDownList ID="dTipoTransc" runat="server" Height="21px" OnSelectedIndexChanged="dTipoTransc_SelectedIndexChanged">
                <asp:ListItem Value="1">Ingresos</asp:ListItem>
                <asp:ListItem Value="2">Salidas</asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
                Correo:<br />
                <asp:TextBox ID="tCorreo" runat="server"></asp:TextBox>
            </p>
            <p>
                Descripción:<br />
                <asp:TextBox ID="tDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                Monto:<br />
                <asp:TextBox ID="tMonto" runat="server"></asp:TextBox>
            </p>

        </div>

        <div class="Buttons-styles">
            <asp:Button CssClass="button button1" ID="bIngresar" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
            <asp:Button class="button button3" ID="bBorrar" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
            <asp:Button CssClass="button button2" ID="bConsultar" runat="server" Text="Consultar" OnClick="bConsultar_Click" />
            <asp:Button class="button button4" ID="bModificar" runat="server" Text="Modificar" OnClick="bModificar_Click" />
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            margin-bottom: 0px;
        }
    </style>
</asp:Content>

