function scrollToElement(str) {
    element = document.getElementById(str);
    const headerHeight = 70; // Đổi 'fixedHeader' thành id của phần tử fixed
    const elementPosition = element.offsetTop - headerHeight; // Lấy vị trí của phần tử cần nhảy đến, điều chỉnh vị trí theo chiều cao của phần tử fixed

    window.scrollTo({
        top: elementPosition,
        behavior: 'smooth' // Cuộn mượt đến vị trí của phần tử
    });
}