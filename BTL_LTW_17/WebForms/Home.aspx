<%@ Page Title="Home" Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BTL_LTW_17.WebForms.Home" MasterPageFile="~/WebForms/Site.Master" %>

<asp:Content ID="BodyContent_DoAn" ContentPlaceHolderID="MainContent1" runat="server">
    <main id="Home">
        <div class="container">
            <%--<%if (Session[BTL_LTW_17.Utils.Constants.KEY_USER] != null)
             {  %>
            <div id="location">
                <span>Giao đến</span>
                <span><i class="fa-solid fa-location-dot" style="color: #eb0a0a;"></i></span>
                <span style="font-weight: 600;"><%=" "+ ((BTL_LTW_17.Models.User)Session[BTL_LTW_17.Utils.Constants.KEY_USER]).Address %></span>
                <i style="position: absolute; right: 5px; font-size: 22px;" class="fa-solid fa-location-crosshairs"></i>
            </div>
            <%} %>--%>
            <div id="listRestaurant" runat="server">
            </div>
            <div class="show-more">
                <a href="#">xem thêm</a>
            </div>
            <div>
                Số lượng người dùng là
                <%:Application["count"].ToString() %>
            </div>
        </div>
    </main>
</asp:Content>
