<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EventBookingSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Easy Booking</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            padding-right: 15px;
            padding-left: 15px;
            margin-right: auto;
            margin-left: 0px
        }
    </style>
</head>
<body style="margin-left: 70px">
    <h1 class="text-center">Welcome to Moviebuzz!!</h1>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
        <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="userName" type="email"  placeholder="Enter username" runat="server" style="margin-left: 4px" Width="143px"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="password" type="password" placeholder="Enter password" runat="server" Width="144px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="Button1_Click" style="margin-left: 70px" Text="Login" Width="68px" />
        <asp:Button ID="Button2" class="btn btn-danger"  runat="server" OnClick="Button2_Click" style="margin-left: 20px" Text="Register" />
            <br />
            <br />
        <asp:TextBox  CssClass="form-control input-lg"  ID="TextBox3" runat="server" Width="275px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        </div>
     </form>
</body>
</html>
