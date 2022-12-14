<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Placa.aspx.cs" Inherits="Examen_Final.Placa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="css/Fomulario.css" rel="stylesheet" />
    <link href="css/gridviw.css" rel="stylesheet" />
    <div class="buscar">
        <asp:Label ID="Label1" runat="server" Text="Buscar por:"></asp:Label>
        <asp:DropDownList ID="Dbuscar" runat="server">
            <asp:ListItem>Numero de Placa</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="Tbuscar" runat="server"></asp:TextBox>
        <asp:Button ID="Bbuscar" runat="server" Text="Buscar" OnClick="Bbuscar_Click"  />
    </div>
    <div class="Contenedor" >
        <asp:Label ID="Luser" runat="server" Text="Numero de Placa:"></asp:Label>
        <asp:TextBox ID="Tplaca" runat="server" Width="250px"></asp:TextBox>
        <asp:Label ID="Lclave" runat="server" Text="Numero de Usuario:"></asp:Label>
        <asp:TextBox ID="Tid" runat="server"></asp:TextBox>
        <asp:Label ID="Lnombre" runat="server" Text="Monto:"></asp:Label>
        <asp:TextBox ID="Tmonto" runat="server" Width="180px"></asp:TextBox>
        
        <asp:Button ID="Beliminar" runat="server" Text="ELIMINAR" OnClick="Beliminar_Click" />
        <asp:Button ID="Bmodificar" runat="server" Text="MODIFICAR" OnClick="Bmodificar_Click"  />
        <asp:Button ID="Bagregar" runat="server" Text="AGREGAR" OnClick="Bagregar_Click"  />
    </div>

    <div>
        
 <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" >
            </asp:GridView>
    </div>

</asp:Content>
