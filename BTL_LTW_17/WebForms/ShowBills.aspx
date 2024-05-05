<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBills.aspx.cs" Inherits="BTL_LTW_17.WebForms.ShowBills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server" ID="myTable" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID Nhà hàng</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Số điện thoại User</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Ds món ăn</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Địa chỉ giao hàng</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Tổng số tiền</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Ghi chú cho shipper</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
