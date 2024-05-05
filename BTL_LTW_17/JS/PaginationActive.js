document.addEventListener("DOMContentLoaded", function () {
    var links = document.querySelectorAll('.pag-item');

    links.forEach(function (link) {
        link.addEventListener('click', function (event) {
            removeActiveClass(links); // Loại bỏ lớp active khỏi tất cả các liên kết
            link.classList.add('pagination-active'); // Thêm lớp active vào liên kết được click
        });
    });

    function removeActiveClass(links) {
        links.forEach(function (link) {
            link.classList.remove('pagination-active');
        });
    }
});