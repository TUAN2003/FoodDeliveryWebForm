<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="Restaurant.aspx.cs" Inherits="BTL_LTW_17.WebForms.Restaurant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <link href="../Css/Restaurant.css" rel="stylesheet" />
    <main id="restaurantPage">
        <div class="container">
            <div id="popup" class="popup">
                Thêm vào giỏ hàng thành công
            </div>
            <div class="infomation-restaurant-all">
                <div id="avatar">
                    <img id="imgAvatar" src="#" alt="Alternate Text" runat="server" />
                </div>
                <div id="detail">
                    <p>
                        <span style="background-color: red; color: white; padding: 5px; cursor: pointer">
                            <i class="fa-solid fa-thumbs-up"></i>Yêu thích</span>
                        <span id="kindRest" runat="server">Quán ăn</span>
                    </p>
                    <h2 id="nameRest" runat="server"></h2>
                    <p id="addressRest" runat="server"></p>
                    <a href="DeleteRest.aspx?Id=<%:id %>" id="deleteRest">Xóa sản phẩm</a>
                    <div id="rating">
                        <span class="stars">
                            <i class="fas fa-star" style="color: #F8DC03;"></i>
                            <i class="fas fa-star" style="color: #ffc107;"></i>
                            <i class="fas fa-star" style="color: #ffc107;"></i>
                            <i class="fas fa-star" style="color: #ffc107;"></i>
                            <i class="fas fa-star-half-alt" style="color: #ffc107;"></i>
                        </span>
                        <span class="number-rating" style="color: white; background-color: #ffc107; padding: 0 5px; border-radius: 4px">999+</span>
                        Lượt đánh giá trên shopee
                    </div>
                    <div class="more-reviews"><a href="#">Xem thêm đánh giá trên DeliFood</a></div>
                    <div class="status-rest">
                        <div class="stt-open">
                            <span><i class="fa-solid fa-circle" style="color: #237d39;"></i></span>
                            <span>Open</span>
                            <span><i class="fa-solid fa-clock"></i></span>
                            <span class="time-open">6:00-18:00</span>
                        </div>
                    </div>
                    <div class="price-range">
                        <span><i class="fa-solid fa-dollar-sign"></i></span>
                        <span class="value-range">25000-30000 VNĐ</span>
                    </div>
                    <div class="info-extension" style="display: flex; flex-direction: row; position: relative">
                        <div>
                            <p>PHÍ DỊCH VỤ</p>
                            <p>0.00% Phí dịch vụ</p>
                            <img class="partner" src="../Images/partner.png" alt="Alternate Text" />
                        </div>
                        <hr style="margin-inline: 20px" />
                        <div>
                            <p>DỊCH VỤ BỞI</p>
                            <p>ShopeeFood</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="menu-restaurant-tab">
                <fieldset style="border: 1px solid #ebebeb;">
                    <legend style="color: red; font-weight: 700; font-size: 20px">Thực đơn</legend>
                    <div class="menu-restaurant-block">
                        <div class="col-menu">
                            <ul>
                                <%if (_restaurant.Menu != null)
                                    {
                                        _restaurant.Menu.Sort();
                                        _restaurant.Categorys.Sort();%>
                                <% foreach (var item in _restaurant.Categorys)
                                    {
                                %>
                                <li onclick="scrollToElement('<%=item %>')"><%=item %></li>
                                <%} %>
                            </ul>
                        </div>
                        <div class="col-food-list">
                            <div class="search-items">
                                <p class="input-group">
                                    <i class="fas fa-search"></i>
                                    <input type="search" name="searchKey" placeholder="Tìm món" value="">
                                </p>
                            </div>
                            <% 
                                int i = 0;
                                foreach (var item in _restaurant.Categorys)
                                {
                            %>
                            <div id="<%=item %>" class="title-menu-item">
                                <details open>
                                    <summary>
                                        <%=item %>
                                    </summary>
                                    <%
                                        while (i < foods.Count && item.Equals(foods[i].Category))
                                        {
                                    %>

                                    <div class="list-food">
                                        <div class="food-row">
                                            <div class="avatar-food">
                                                <img src="<%=foods[i].Image %>" alt="Alternate Text" />
                                            </div>
                                            <div class="food-desc">
                                                <p><%=foods[i].Name %></p>
                                                <p><%=foods[i].Description %></p>
                                            </div>
                                            <div style="margin-inline-end:5px;">
                                                <div class="food-price">
                                                    <%=foods[i].Price %>
                                                    <span style="position: relative; top: -5px; right: 3px;">vnđ</span>
                                                </div>
                                            </div>
                                            <div id="addToCart<%:foods[i].Id %>" class="add-to-cart" onclick="addToCart({fid:<%:foods[i].Id %> , img:'<%:foods[i].Image %>' , 
                                                name:'<%:foods[i].Name %>' , price:<%:foods[i].Price %>})">
                                                <i class="fa-solid fa-square-plus" style="color: #FE5621; font-size: 25px"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                            i++;
                                        }
                                    %>
                                </details>
                            </div>
                            <%
                                    }
                                }
                            %>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </main>
    <script>
        var url = window.location.search;
        var usp = new URLSearchParams(url);
        var idRestaurant = usp.get("Id");
        document.getElementById('deleteRest').addEventListener('click', function (event) {
                var conf = confirm('có xóa không?');
            if (!conf) {
                event.preventDefault();
            }
        });
        var nameRestaurant = usp.get("Name");
        function addToCart(food) {
            var basket = JSON.parse(localStorage.getItem("basket"));
            if (basket != null && idRestaurant == basket.id) {
                var item;
                var c = 0;
                var i = -1;
                for (let x of basket.items) {
                    if (food.fid == x.food.fid) {
                        item = x;
                        i = c;
                        break;
                    }
                    c++;
                }
                if (item == null) {
                    basket.items.push({ food:food, quantity: 1 });
                    let elm = document.createElement('i');
                    elm.className = 'fa-solid fa-trash-can';
                    elm.style.fontSize = '22px';
                    let elm2 = document.getElementById('addToCart'+food.fid);
                    elm2.innerHTML = '';
                    elm2.appendChild(elm);
                } else {
                    basket.items.splice(i,1);
                    let elm = document.createElement('i');
                    elm.className = 'fa-solid fa-square-plus';
                    elm.style.color = '#FE5621';
                    elm.style.fontSize = '25px';
                    let elm2 = document.getElementById('addToCart' + food.fid );
                    elm2.innerHTML = '';
                    elm2.appendChild(elm);
                }
            } else {
                basket = { id: idRestaurant, name: nameRestaurant, items: [{ food: food, quantity: 1 }] };
                let elm = document.createElement('i');
                elm.className = 'fa-solid fa-trash-can';
                elm.style.fontSize = '22px';
                let elm2 = document.getElementById('addToCart' + food.fid);
                elm2.innerHTML = '';
                elm2.appendChild(elm);
            }
            localStorage.setItem("basket", JSON.stringify(basket));
            showNoti();
        }

        var bask = JSON.parse(localStorage.getItem("basket"));
        if (bask != null && bask.id === idRestaurant) {
            var elms = document.querySelectorAll('.add-to-cart');
            for (let x of bask.items) {
                for (let y of elms) {
                    if (y.id === ('addToCart' + x.food.fid)) {
                        let elm = document.createElement('i');
                        elm.className = 'fa-solid fa-trash-can';
                        elm.style.fontSize = '22px';
                        y.innerHTML = '';
                        y.appendChild(elm);
                    }
                }
            }
        }
        function showPopup() {
            var popup = document.getElementById('popup');
            popup.style.display = 'block';
            setTimeout(function () {
                popup.style.display = 'none';
            }, 2000); // 2000 milliseconds = 2 seconds
        }
        function showNoti() {
            var basket = JSON.parse(localStorage.getItem("basket"));
            var elm = document.getElementById('countFloat');
            if (basket.items.length > 0) {
                elm.style.display = 'block';
            } else {
                elm.style.display = 'none';
            }
        }
    </script>
</asp:Content>
