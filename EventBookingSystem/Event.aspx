<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="EventBookingSystem.EventMenu" %>

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
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="container-fluid">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="30pt"></asp:Label>
            </div>

            <asp:Button ID="btn1" class="btn align-content-end" runat="server" Text="Logout" OnClick="btn1_Click" />

            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="margin-left: 295px">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" class="btn btn-dark" runat="server" OnClick="Button1_Click" Style="margin-left: 325px" Text="Reserve Seat!" />
            <br />
            <br />
            <br />
            <p>
                Click on &quot;View&quot; to see your past reservations<br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View" />
            </p>
        </div>
    </form>
    
</body>
</html>
