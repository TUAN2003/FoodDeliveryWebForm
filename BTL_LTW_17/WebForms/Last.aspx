<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Last.aspx.cs" Inherits="BTL_LTW_17.WebForms.Last" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #box {
            height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }
    </style>
    <link rel="stylesheet" href="../fontawesome-free-6.2.1-web/css/all.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="box">
            <%if (isSuccess)
                {
            %><div><i class="fa-regular fa-circle-check"></i>Đặt hàng thành công<a href="Home.aspx">Quay về trang chủ</a> <span class="second">5</span></div>

            <%}
                else
                {  %>
            <div><i class="fa-solid fa-triangle-exclamation"></i>Đã xảy ra lỗi <a href="Home.aspx">Quay về trang chủ</a><span class="second">5</span></div>
            <%} %>
        </div>
    </form>
    <script>
        localStorage.removeItem('basket');
        var second = document.querySelector('.second');
        var c = 4;
        setInterval(
            function () {
                second.textContent = c;
                c--;
            }, 1000)
        setTimeout(function () {
            window.location.href = 'Home.aspx';
        }, 5000);
    </script>
</body>
</html>
