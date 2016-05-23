<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gse.WebService.Ui.Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <%--<h1>WebService Demo</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>--%>
    </div>
    <asp:Label ID="lblMsgError" runat="server" Text="Msg" Font-Italic="True" Font-Size="Medium"></asp:Label>
    <hr />
    <asp:Button ID="Button1" runat="server" Text="Borrar usuarios añadidos" OnClick="Button1_Click1" />
    <br />
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="Button3" runat="server" Text="Añadir 1 usuario" OnClick="Button1_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button4" runat="server" Text="Añadir 100 usuarios" OnClick="Button4_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <fieldset style="width:200px;float:left;">
                <legend>Añadir 1 usuario</legend>
                Tiempo ini.: <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label5" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset style="width:200px;">
               <legend>Añadir 100 usuarios</legend>
                Tiempo ini.: <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label6" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset style="width:200px;">
               <legend>Grid usuarios</legend>
                Tiempo ini.: <asp:Label ID="Label8" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="Red"></asp:Label><br />
                Tiempo dif.: <asp:Label ID="Label10" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            </fieldset>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <p><asp:Button ID="Button2" runat="server" Text="Cargar grid" OnClick="Button2_Click" /></p>
            <p>Count de registros <asp:Label ID="Label7" runat="server" Text="0" Font-Bold="True"></asp:Label></p>
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
    <div style="position:absolute;top:40%;z-index:999999;background-color:grey;width:80%;display:none;">
        <asp:Panel ID="Panel1" runat="server" Visible="false" style="padding-top:5px;padding-left:3px;padding-bottom:2px;padding-right:2px;">
            
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Bold="True" BackColor="Red" ForeColor="White">(X) Cerrar</asp:LinkButton>
                    <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AllowPaging="True" CellSpacing="2" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="4">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
        </asp:Panel>
    </div>
    <script language="javascript">

        function validateNumUsuarios() {
            var isValid = true;
            
            var $textbox = $("#<% //TextBox1.ClientID  %>");

            if (isNaN(parseInt($textbox.val()))) {
                isValid = false;
                alert('Introduce un valor numerico.');
            } else {
                var val = parseInt($textbox.val());
                if (val > 100 || val < 1) {
                    isValid = false;
                    alert("El valor debe estar comprendido entre 1 y 100");
                }
            }
            
            return isValid;
        }
    </script>
</asp:Content>
