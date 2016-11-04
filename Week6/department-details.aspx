﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department-details.aspx.cs" Inherits="Week6.department_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="txtName" class="col-sm-3 control-label">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtBudget" class="col-sm-3 control-label">Budget:</label>
        <asp:TextBox ID="txtBudget" runat="server" required Type="number" min="0" Max="999999999" step="1" />
      </div>  

    <asp:button class="btn btn-success col-sm-offset-3" ID="btnSave" runat="server" Text="save" OnClick="btnSave_Click" />
</asp:Content>
