<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="Week6.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="txtName" class="col-sm-3 control-label">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtLName" class="col-sm-3 control-label">Last Name:</label>
        <asp:TextBox ID="txtLName1" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtEDate" class="col-sm-3 control-label">Enrollment Date:</label>
        <asp:TextBox ID="TxtEDate" runat="server" Text='<%# Bind("Date", "{0:yyyy-MM-dd}") %>' required />
      
      </div>
   
     <asp:button class="btn btn-success col-sm-offset-3" ID="btnSave" runat="server" Text="save" OnClick="btnSave_Click" />
</asp:Content>
