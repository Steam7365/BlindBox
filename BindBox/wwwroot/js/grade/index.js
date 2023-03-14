function del(id) {
    layer.confirm('您确认删除该商品等级？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        window.location.href = 'https://localhost:7207/Grade/Delete/' + id;
    }, function () {
        clearInterval(0);
    })
}