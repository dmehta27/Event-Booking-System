<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EventBookingSystem.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Easy Booking</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
</head>
<body>
    <script type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };
    </script>
    <h1 class="text-center">Welcome to Moviebuzz!!</h1>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
&nbsp; :&nbsp;
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
&nbsp; :&nbsp;
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email id"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;
            <asp:TextBox ID="EmailId" type="email" runat="server"></asp:TextBox>
&nbsp;
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp; :&nbsp;
            <asp:TextBox ID="Password" type="password" runat="server"></asp:TextBox>
&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SignUp" class="btn btn-warning" runat="server" OnClick="SignUp_Click" Text="Sign Up" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel" />
            <br />
        </div>
    </form>
</body>
</html>
