<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirm.aspx.cs" Inherits="BTL_LTW_17.WebForms.OrderConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xác nhận đặt đơn</title>
    <style>
        textarea{
            resize:none;
        }
        #form1{
           display:flex;
           justify-content:center;
        }
        #form2{
   display:flex;
   justify-content:center;
}
        .container{

        }
        .footer{
            position:fixed;
            bottom:0px;
            display:flex;
            flex-direction:row;
            align-items:center;
            justify-content:space-around;
            width:100%;
            z-index:100;
            background-color:white;
        }
    </style>
    <link href="../Css/OrderConfirm.css" rel="stylesheet" />
</head>
<body>
        <%if (Session[BTL_LTW_17.Utils.Constants.KEY_USER] == null)
            {  %>
        <form id="form1" runat="server">
        <div id="text">
            Hãy
            <button id="signIn" runat="server" type="button" onserverclick="SignIn">
                Đăng Nhập
            </button>
        </div>
        </form>
        <%}%>
        <%else{%>
    <form id="form2" runat="server" action="Last.aspx" method="post">
            <div class="container">
                <%if(true){  %>
                <div class="title">
                    <h1>Bước cuối cùng-Thanh toán</h1>
                    <h3><%:restaurant.Name %></h3>
                </div>
                <div class="info">
                    <div id="infoAddress">
                        <h5>Giao đến</h5>
                        <label for="address">Địa chỉ của bạn</label>
                        <br />
                        <textarea name="address" maxlength="200"><%:user.Address %></textarea>
                        <br />
                        <label for="note">Ghi chú cho tài xế</label>
                        <br />
                        <textarea name="note"  placeholder="Ví dụ: hãy chờ tôi tại sảnh"></textarea>
                    </div>
                    <div id="listFoodOrder">
                        <h5>Đồ ăn đã chọn</h5>
                        <%foreach (var item in foodOrders)
                            {%>
                        <div class="food-row">
                            <div class="avatar-food">
                                <img src="<%:item.Item.Image %>" alt="Alternate Text" />
                            </div>
                            <div class="food-desc">
                                <p><%:item.Item.Name %></p>
                                <p><%:item.Item.Description %></p>
                            </div>
                            <div style="margin-inline-end: 5px;">
                                <div class="food-price">
                                    <%:item.Item.Price %>
                                    <span style="position: relative; top: -5px; right: 3px;">vnđ</span>
                                </div>
                            </div>
                            <div>
                                <%:item.Quantity %>
                            </div>
                        </div>
                        <%} %>
                    </div>
                    <div id="paymentMethod">
                        <h5>Phương thức thanh toán</h5>
                        <select name="method">
                            <option value="cash">Tiền mặt</option>
                            <option value="bank">Chuyển khoản</option>
                            <option value="zalopay">Zalo Pay</option>
                        </select>
                    </div>
                </div>
                <%} %>
            </div>
            <div class="footer">
                <div class="text-footer">
                    <h3>Tổng cộng</h3>
                    <h4><%:TotalPrice() %></h4>
                </div>
                <div>
                    <input type="submit" value="Đặt đơn" />
                </div>
            </div>
    </form>
        <%} %>
</body>
</html>
