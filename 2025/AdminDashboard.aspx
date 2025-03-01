<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:GridView ID="gvComplaints" runat="server" AutoGenerateColumns="False" OnRowCommand="gvComplaints_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Complaint ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Assign">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlWorkers" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnAssign" runat="server" Text="Assign" CommandName="Assign" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvFeedback" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Feedback ID" />
                <asp:BoundField DataField="Message" HeaderText="Message" />
            </Columns>
        </asp:GridView>
</asp:Content>

