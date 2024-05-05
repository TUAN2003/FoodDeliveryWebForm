<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BTL_LTW_17.WebForms.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <style>
        input[type=number] {
            width: 40px;
        }

        img {
            width: 50px;
        }
    </style>
    <link rel="stylesheet" href="../fontawesome-free-6.2.1-web/css/all.min.css" />
    <link rel="stylesheet" href="../Css/Cart.css" />
</head>
<body>
    <%if (_currentUser != null)
        {
    %>
    <form id="form1" action="OrderConfirm.aspx" runat="server" method="post" onsubmit="return handleSubmit();">
        <nav>
            <div class="container">
                <div id="logoHeader2" class="nav-block logo-block">
                    <a href="Home.aspx">
                        <img class="img-logo" src="../Images/logo-delifood.png" alt="Go To DeliFood" />
                    </a>
                </div>
                <div class="nav-block">
                    <div id="userAccount2" runat="server" class="nav-block">
                        <%if (_currentUser.Avatar != null)
                            {  %>
                        <img id="img-avatar" src="data:image/png;base64,<%:_currentUser.Avatar %>" alt="avatar" />
                        <%}
                            else
                            {  %>
                        <img id="img-avatar2" src="../Images/default_avatar.jpg" alt="avatar" />
                        <%} %>
                        <h4 id="nameUser"><%:_currentUser.Name %></h4>
                        <i class="fa-solid fa-sort-down"></i>
                        <div class="dropdown">
                            <div class="dropdown-menu">
                                <a href="#">
                                    <div class="dropdown-item order-history">
                                        <i class="fa-solid fa-clock-rotate-left"></i>
                                        <span>Lịch sử đặt hàng</span>
                                    </div>
                                </a>
                                <a href="#">
                                    <div class="dropdown-item update-acc">
                                        <i class="fa-solid fa-user"></i>
                                        <span>Cập nhật tài khoản</span>
                                    </div>
                                </a>
                                <a href="./Logout.aspx">
                                    <div class="dropdown-item logout">
                                        <i class="fa-solid fa-power-off"></i>
                                        <span>Đăng xuất</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
        <div class="top">
            <h1 style="text-align: center; color: #FE5621">Giỏ hàng</h1>
        </div>
        <div id="container">
        </div>
        <div class="footer">
            <h3 id="totalPrice">Tổng cộng:  <span id="valueTotal">0</span>vnđ</h3>
            <input type="submit" value="Chi tiết đơn hàng" />
        </div>
    </form>
    <script>
        function handleSubmit() {
            var elms = document.querySelectorAll('.checkbox');
            var b = false;
            for (let c of elms) {
                if (c.checked) {
                    b = true;
                    break;
                }
            }
            return b;
        }
        //function test(order) {
        //    $.ajax({
        //        type: "POST",
        //        url: "Pay.aspx/AddToCart",
        //        data: JSON.stringify(order.items[0].food),
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function () {
        //            alert("Mặt hàng đã được thêm vào giỏ hàng.");
        //        },
        //        error: function () {
        //            alert("Đã xảy ra lỗi khi thêm mặt hàng vào giỏ hàng.");
        //        }
        //    });
        //}
        function increaseValue(index) {
            var ip = document.querySelectorAll('.count')[index];
            var value = parseInt(ip.value, 10);
            value = isNaN(value) ? 0 : value;
            value++;
            ip.value = value;
            basket.items[index].quantity = value;
            localStorage.setItem('basket', JSON.stringify(basket));
            document.querySelectorAll('.price')[index].textContent = value * basket.items[index].food.price;
            sum();
        }

        function decreaseValue(index) {
            var ip = document.querySelectorAll('.count')[index];
            var value = parseInt(ip.value, 10);
            value = isNaN(value) ? 0 : value;
            value = value <= 0 ? 0 : value - 1;
            ip.value = value;
            basket.items[index].quantity = value;
            localStorage.setItem('basket', JSON.stringify(basket));
            document.querySelectorAll('.price')[index].textContent = value * basket.items[index].food.price;
            sum();
        }
        function deleteFood(index) {
            var bas = JSON.parse(localStorage.getItem("basket"));
            bas.items.splice(index, 1);
            localStorage.setItem('basket', JSON.stringify(bas));
            document.querySelectorAll('.item-block')[index].remove();
            window.location.reload();
        }
        function sum() {
            var prices = document.querySelectorAll('.price');
            var checks = document.querySelectorAll('.checkbox');
            var i = 0;
            var sum = 0;
            for (let c of checks) {
                if (c.checked) {
                    sum += parseInt(prices[i].textContent);
                }
                i++;
            }
            document.getElementById('valueTotal').textContent = sum;
        }
        var container = document.getElementById('container');
        var basket = JSON.parse(localStorage.getItem("basket"));
        var restId = document.createElement('input');
        restId.type = 'hidden';
        restId.name = 'id';
        restId.value = basket.id;
        var price = 0;
        let block = document.createElement('div');
        container.appendChild(block);
        let title = document.createElement('h3');
        let text = document.createTextNode(basket.name);
        title.appendChild(text);
        block.appendChild(title);
        block.appendChild(restId);
        let ind = 0;
        for (let item of basket.items) {
            let i = ind;
            let itemBlock = document.createElement('div');
            itemBlock.className = 'item-block';
            let checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkbox.className = 'checkbox';
            checkbox.value = item.food.fid + ';' + i;
            checkbox.name = 'check';
            checkbox.onclick = function () { sum(); };
            itemBlock.appendChild(checkbox);
            let itemImg = document.createElement('img');
            itemImg.src = item.food.img;
            itemBlock.appendChild(itemImg);
            let itemName = document.createElement('span');
            itemName.className = 'name-rest';
            itemName.appendChild(document.createTextNode(item.food.name));
            itemBlock.appendChild(itemName);
            let incre = document.createElement('span');
            incre.innerHTML = '<i class="fa-solid fa-plus"></i>';
            incre.onclick = function () { increaseValue(i) };
            let decre = document.createElement('span');
            decre.innerHTML = '<i class="fa-solid fa-minus"></i>';
            decre.onclick = function () { decreaseValue(i) };
            itemBlock.appendChild(decre);
            let itemCount = document.createElement('input');
            itemCount.type = 'number';
            itemCount.readOnly = true;
            itemCount.className = 'count';
            itemCount.name = 'quantity';
            itemCount.value = item.quantity
            itemBlock.appendChild(itemCount);
            itemBlock.appendChild(incre);
            let itemPrice = document.createElement('span');
            itemPrice.textContent = item.quantity * item.food.price;
            itemPrice.className = 'price';
            itemBlock.appendChild(itemPrice);
            let del = document.createElement('span');
            del.innerHTML = '<i class="fa-solid fa-trash-can"></i>';
            del.onclick = function () { deleteFood(i) };
            itemBlock.appendChild(del);
            block.appendChild(itemBlock);
            ind++;
        }
    </script>
    <%}
        else
        {%>
    <form id="form2" runat="server">
        <nav>
            <div class="container">
                <div id="logoHeader" class="nav-block logo-block">
                    <a href="Home.aspx">
                        <img class="img-logo" src="../Images/logo-delifood.png" alt="Go To DeliFood" />
                    </a>
                </div>
                <div class="nav-block">
                    <div id="userAccount" runat="server" class="nav-block">
                        <button id="Button1" runat="server" type="button" onserverclick="SignIn">
                            Đăng Nhập
                        </button>
                    </div>
                </div>
            </div>
        </nav>
        <div id="text">
            Đăng nhập để đặt đơn
        </div>
    </form>
    <%} %>
</body>
</html>
