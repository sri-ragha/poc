<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#FF0066" 
        Text="User Name "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Placeholder="Username"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Size="Medium" 
        ForeColor="#FF0066" Text="Password"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>

