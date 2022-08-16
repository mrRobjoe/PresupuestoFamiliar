<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PresupuestoFamiliar.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="h1Inic-estilo">Bienvenido al presupuesto familiar</h1>
        <div class="centrar">
            <img src="images/Presupuesto.jpg" alt="Alternate Text" class="auto-style1" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 707px;
            height: 517px;
        }

        .h1Inic-estilo {
            text-align: center;
            text-shadow:
                2px 2px 1px #FF3333,
                4px 4px 2px #66B2FF,
                6px 6px 2px #000099;
            
        }

        .centrar {
            text-align: center;
        }
    </style>
</asp:Content>

