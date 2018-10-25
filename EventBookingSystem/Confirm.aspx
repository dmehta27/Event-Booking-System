<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="EventBookingSystem.Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Congratulations
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            ! Your booking has been confirmed!<br />
            <br />
            Please click on &quot;Continue&quot; to make another booking.<br />
            OR<br />
            Click on &quot;Logout&quot;<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Continue" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="View Bookings!" />
        </div>
    </form>
     <script type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };
    </script>
</body>
</html>
