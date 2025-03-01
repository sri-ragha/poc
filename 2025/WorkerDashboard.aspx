<%@ Page Title="" Language="C#" MasterPageFile="~/Worker.master" AutoEventWireup="true" CodeFile="WorkerDashboard.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTasks_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Task ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Update Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Text="Pending" />
                            <asp:ListItem Text="Resolved" />
                        </asp:DropDownList>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateStatus" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>

