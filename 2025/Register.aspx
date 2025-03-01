<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Label ID="Label1" runat="server" Text="User Name " Font-Size="Medium" 
        ForeColor="#FF0066"></asp:Label>

    &nbsp;

    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Password" Font-Size="Medium" 
        ForeColor="#FF0066"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Role" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlRole" runat="server">
            <asp:ListItem Text="Admin" />
            <asp:ListItem Text="User" />
            <asp:ListItem Text="Worker" />
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />

</asp:Content>
