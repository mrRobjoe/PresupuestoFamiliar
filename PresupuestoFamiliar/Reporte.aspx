<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="PresupuestoFamiliar.WebForm4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/TransaccionesEstilos.css" rel="stylesheet" />
    <div>
        <asp:GridView ID="Gridview4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

        <p>
            Tipo transacción:
            <asp:DropDownList ID="dTipoTran" runat="server" Height="21px">
                <asp:ListItem Value="1">Ingresos</asp:ListItem>
                <asp:ListItem Value="2">Salidas</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Usuario:
            <asp:TextBox ID="tUser" runat="server"></asp:TextBox>
        </p>
        <p>
           Mes:
            <asp:DropDownList ID="dMes" runat="server" Height="21px">
                <asp:ListItem Value="01">Enero</asp:ListItem>
                <asp:ListItem Value="02">Febrero</asp:ListItem>
                <asp:ListItem Value="03">Marzo</asp:ListItem>
                <asp:ListItem Value="04">Abril</asp:ListItem>
                <asp:ListItem Value="05">Mayo</asp:ListItem>
                <asp:ListItem Value="06">Junio</asp:ListItem>
                <asp:ListItem Value="07">Julio</asp:ListItem>
                <asp:ListItem Value="08">Agosto</asp:ListItem>
                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                <asp:ListItem Value="10">Octubre</asp:ListItem>
                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                <asp:ListItem Value="12">Diciembre</asp:ListItem>
            </asp:DropDownList>
        </p>

        <div>
            <asp:Button CssClass="reporte-estilo" ID="bReporte" runat="server" Text="Reporte" OnClick="bReporte_Click" style="margin-left:10px" />
        </div>
        
    </div>
</asp:Content>
