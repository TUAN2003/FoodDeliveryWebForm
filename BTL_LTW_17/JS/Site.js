document.getElementById('toggle').addEventListener('click', function () {
    var elm = document.getElementById('menuToggle');
    if (elm.style.display === 'none') {
        elm.style.display = 'block';
    } else {
        elm.style.display = 'none';
    }
})