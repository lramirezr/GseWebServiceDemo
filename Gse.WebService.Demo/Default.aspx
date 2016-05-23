<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gse.WebService.Ui.Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WebService Demo</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="Button3" runat="server" Text="Añadir 1 usuario" OnClick="Button1_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button4" runat="server" Text="Añadir 100 usuarios" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <fieldset style="width:200px;float:left;">
                <legend>Añadir 1 usuario</legend>
                Tiempo ini.: <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset style="width:200px;">
               <legend>Añadir 100 usuarios</legend>
                Tiempo ini.: <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#339933"></asp:Label><br />
                Tiempo fin: <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            </fieldset>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
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
