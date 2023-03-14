
var app = new Vue({	//创建vue对象
    el: '#app',		//指定一个标签作为vue的挂载点（作用范围），使用css选择器选择
    data: {			//vue中使用的数据
        close_message: true,
    },
    methods: {
        grade_list() {
            layer.open({
                type: 2,
                area: ['650px', '500px'],
                anim: 3,
                scrollbar: false,
                content: 'https://localhost:7207/Grade/index'
            });
        },
        abc(param1) {
            console.log(param1)
            layer.open({
                type: 2,
                area: ['1000px', '580px'],
                anim: 3,
                scrollbar: false,
                content: 'https://localhost:7207/CommdityDetail/Create/' + param1
            });
        },
        edit(param1, param2) {
            console.log(param1);
            layer.open({
                type: 2,
                area: ['1000px', '580px'],
                anim: 3,
                scrollbar: false,
                content: 'https://localhost:7207/CommdityDetail/Edit/' + param1 + '/' + param2
            });
        },
        del(id) {
            layer.confirm('您确认删除该子商品？', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                window.location.href = 'https://localhost:7207/CommdityDetail/Delete/' + id;
            }, function () {
                clearInterval(0);
            })
        }
    },
})
