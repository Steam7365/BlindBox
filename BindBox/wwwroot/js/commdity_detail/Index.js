var btn1 = document.getElementById("grade_manager");
btn1.onclick = function () {
    layer.open({
        type: 2,
        area: ['650px', '500px'],
        anim: 3,
        scrollbar: false,
        content: 'https://localhost:7207/Grade/index'
    });
}
var btn2 = document.getElementById("add_commdity_detail");
btn2.onclick = function () {
    layer.open({
        type: 2,
        area: ['1000px', '530px'],
        anim: 3,
        scrollbar: false,
        content: 'https://localhost:7207/CommdityDetail/Create'
    });
}