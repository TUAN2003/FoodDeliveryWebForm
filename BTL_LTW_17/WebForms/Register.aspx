<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTL_LTW_17.WebForms.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" href="../fontawesome-free-6.2.1-web/css/all.min.css" />
    <link rel="stylesheet" href="../Css/Register.css" />
    <title>Đăng kí</title>
</head>
<body>
    <form id="form1" action="#" method="post" class="box" onsubmit="return handleSubmit()" runat="server">
        <div class="content">
            <div class="title">
                <h2 class="text-title">Đăng Ký</h2>
            </div>
            <div id="userAvatar">
                <input type="file" id="fileUpload" name="fileUpload" style="display: none" accept="image/*" runat="server" />
                <img id="imgAvatar" src="../Images/default_avatar.jpg" alt="Alternate Text" />
            </div>
            <div class="form-input">
                <input id="phone" type="tel" placeholder="Số điện thoại" name="phone">
                <input id="username" type="text" placeholder="Tên người dùng" name="username">
                <input id="password" type="password" placeholder="Mật khẩu" name="password">
                <input id="confirm_password" type="password" placeholder="Nhập lại mật khẩu" name="confirm_password">
                <input id="address" type="text" placeholder="Địa chỉ giao hàng mặc định" name="address">
                <input id="identity" type="text" placeholder="Căn cước công dân" name="identity">
                <div class="sex">
                    <span class="sex-inner">Giới tính: </span>
                    <input class="sex-inner radio" type="radio" id="male" name="sex" value="male">
                    <label class="sex-inner" for="male">Nam</label>
                    <input class="sex-inner radio" type="radio" id="fmale" name="sex" value="fmale">
                    <label class="sex-inner" for="fmale">Nữ</label>
                </div>
            </div>
            <div id="alertFail" runat="server">
            </div>
            <button type="submit" class="btn-submit">Đăng ký</button>
            <div class="redirect-login">
                <span class="text-redirect">Đã có tài khoản:
                </span>
                <a href="../Htmls/Login.html">Đăng nhập ngay</a>
            </div>
        </div>
    </form>
    <script>
        let _phone = document.getElementById('phone');
        let _username = document.getElementById('username');
        let _password = document.getElementById('password');
        let _cpassword = document.getElementById('confirm_password');
        let _male = document.getElementById('male');
        let _fmale = document.getElementById('fmale');
        let _alertFail = document.getElementById('alertFail');
        let avatar = document.getElementById('userAvatar');
        let imgAvatar = document.getElementById('imgAvatar');
        let fileUpload = document.getElementById('fileUpload');

        let url = window.location.search;
        let usp = new URLSearchParams(url);
        let success = usp.get("success");
        if (success != null) {
            alert(success);
        }
        avatar.addEventListener('click', function () {
            fileUpload.click();
        });

        // Xử lí phía client
        function handleSubmit() {
            var phone = _phone.value;
            if (phone === '') {
                alertFail('Số điện thoại không được để trống');
                _phone.focus();
                return false;
            }
            var username = _username.value;
            if (username === '') {
                alertFail('Tên người dùng không để trống');
                _username.focus();
                return false;
            }
            var password = _password.value;
            if (password === '') {
                alertFail('Mật khẩu không được để trống');
                _password.focus();
                return false;
            }
            var cpassword = _cpassword.value;
            if (cpassword !== password) {
                alertFail('Xác nhận mật khẩu không trùng khớp');
                _cpassword.focus();
                return false;
            }
            var b = _male.checked ^ _fmale.checked;
            if (!b) {
                alertFail('Giới tính không để trống');
                _male.focus();
                return false;
            }
            return true;
        }

        fileUpload.addEventListener('change', function () {
            // Lấy file đã chọn
            var file = this.files[0];

            // Kiểm tra xem file có phải là hình ảnh không
            if (file && file.type.startsWith('image/')) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    imgAvatar.src = e.target.result;
                }
                reader.readAsDataURL(file);
            } else {
                alert('Vui lòng chọn một file hình ảnh.');
            }
        });

        function alertFail(msg) {
            _alertFail.innerHTML = `<img src="../Images/warning.png" alt="Warning" /> ${msg}`;
            _alertFail.style.display = 'flex';
        }
    </script>
</body>
</html>
