<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EventBookingSystem.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Easy Booking</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <asp:Label ID="Label1" runat="server" Font-Size="30pt"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="20pt"></asp:Label>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_tick">
            </asp:Timer>

            <br />
             Please confirm your seats in: 
            <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <asp:Literal ID="Clock" runat="server"></asp:Literal>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />  
                </Triggers>
            </asp:UpdatePanel>to avoid loosing your seats!
           <br />
            <br />
            <br />
            <br />
        
        <asp:Button ID="Button1" class="btn btn-success" runat="server"  OnClick="Button1_Click" Text="Confirm" Width="108px" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Choose Different seats" />
        </div>
      </form>
</body>
</html>
