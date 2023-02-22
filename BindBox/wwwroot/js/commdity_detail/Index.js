
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
                area: ['1000px', '530px'],
                anim: 3,
                scrollbar: false,
                //btn: ['按钮一', '按钮二']
                //, yes: function (index, layero) {
                //    //按钮【按钮一】的回调
                //    app.close_message = false;
                //}
                //, btn2: function (index, layero) {
                //    //按钮【按钮二】的回调

                //    //return false 开启该代码可禁止点击该按钮关闭
                //},
                content: 'https://localhost:7207/CommdityDetail/Create/' + param1
            });
        },
        edit: function (param1, param2) {
            console.log(param1);
            layer.open({
                type: 2,
                area: ['1000px', '530px'],
                anim: 3,
                scrollbar: false,
                //btn: ['按钮一', '按钮二']
                //, yes: function (index, layero) {
                //    //按钮【按钮一】的回调
                //    app.close_message = false;
                //}
                //, btn2: function (index, layero) {
                //    //按钮【按钮二】的回调

                //    //return false 开启该代码可禁止点击该按钮关闭
                //},
                content: 'https://localhost:7207/CommdityDetail/Edit/' + param1 + '/' + param2
            });
        }
    },
})
