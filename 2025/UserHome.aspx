<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h2>Submit a Complaint</h2>
        <asp:TextBox ID="txtComplaint" runat="server" TextMode="MultiLine" Rows="4" Columns="50" Placeholder="Enter your complaint"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmitComplaint" runat="server" Text="Submit Complaint" OnClick="btnSubmitComplaint_Click" />
        
        <h2>Submit Feedback</h2>
        <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Rows="4" Columns="50" Placeholder="Enter your feedback"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmitFeedback" runat="server" Text="Submit Feedback" OnClick="btnSubmitFeedback_Click" />
        
        <h2>View Complaint Status</h2>
        <asp:GridView ID="gvComplaintStatus" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Complaint ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
</asp:Content>

