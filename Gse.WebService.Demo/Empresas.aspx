<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="Gse.WebService.Demo.Empresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblMsgError" runat="server" Text="" Font-Italic="True" Font-Size="Medium"></asp:Label>
    </div>
    <hr />
     <div class="row">
        <div class="col-md-4">
            <asp:Button ID="Button3" runat="server" Text="Añadir 1 empresa" OnClick="Button3_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button4" runat="server" Text="Añadir 100 empresas" OnClick="Button4_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button2" runat="server" Text="Cargar grid empresas" OnClick="Button2_Click" />
            Count de registros <asp:Label ID="Label7" runat="server" Text="0" Font-Bold="True"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <fieldset style="width:200px;float:left;">
                <legend>Añadir 1 empresa</legend>
                Tiempo ini.: <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label5" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset style="width:200px;">
               <legend>Añadir 100 empresas</legend>
                Tiempo ini.: <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label6" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset style="width:200px;">
               <legend>Grid empresas</legend>
                Tiempo ini.: <asp:Label ID="Label8" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label10" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Font-Names="Arial" Font-Size="Small" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="6">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
