var vm = new Vue({ //创建vue对象
    el: '#app', //指定一个标签作为vue的挂载点（作用范围），使用css选择器选择
    data: { //vue中使用的数据
        describe_list: [],
        describe: {},
        is_add: true,
        commdityDetail: {},
        newid:0,
    },
    methods: {
        add_describe() {
            let _this = this;
            if (!_this.describe.DescTitle || !_this.describe.DescContent) {
                layer.tips('请在描述名与描述内容框中输入内容..', '#add_describe_btn', {
                    tips: [1, '#C64E2F'],
                    time: 4000
                });
                return;
            }
            //去除空格
            if (!_this.describe.DescTitle.trim().length > 0 || !_this.describe.DescContent.trim().length > 0) {
                layer.tips('请在描述名与描述内容框中输入内容..', '#add_describe_btn', {
                    tips: [1, '#C64E2F'],
                    time: 4000
                });
                return;
            }
            this.newid--;
            _this.describe.DescribeTypeId = this.newid;
            _this.describe_list.push(_this.describe);
            layer.msg('新增描述成功..', {
                icon: 1
            });
            _this.describe = {};
        },
        del_describe(id) {
            let _this = this;
            layer.confirm('你确认你要删除该描述信息？', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                console.log(id);
                _this.describe_list.some((p, i) => {
                    // 查询要删除的商品编号
                    if (p.DescribeTypeId == id) {
                        // 删除数组元素
                        _this.describe_list.splice(i, 1);
                    }
                })
                layer.msg('删除成功', {
                    icon: 1
                });
            }, function () {

            });
        },
        //将编辑的描述信息推送到文本框中
        update_push_describe(item) {
            let _this = this;
            _this.describe = Object.assign({}, item);
            _this.is_add = false;
        },
        update_describe() {
            let _this = this;
            if (!_this.describe.DescTitle || !_this.describe.DescContent) {
                layer.tips('请在描述名与描述内容框中输入内容..', '#update_describe_btn', {
                    tips: [1, '#C64E2F'],
                    time: 4000
                });
                return;
            }
            //去除空格
            if (!_this.describe.DescTitle.trim().length > 0 || !_this.describe.DescContent.trim().length > 0) {
                layer.tips('请在描述名与描述内容框中输入内容..', '#update_describe_btn', {
                    tips: [1, '#C64E2F'],
                    time: 4000
                });
                return;
            }
            _this.describe_list.some((p, i) => {
                // 查询要修改的商品编号
                if (p.DescribeTypeId == _this.describe.DescribeTypeId) {
                    // 修改数组元素
                    _this.describe_list.splice(i, 1, _this.describe);
                    _this.describe = Object.assign({}, _this.describe);
                    layer.msg('更改描述成功..', {
                        icon: 1
                    });
                }
            })
        },
        //编辑按钮转换为添加按钮
        exchange() {
            let _this = this;
            _this.is_add = true;
            _this.describe = {};
        },

        clearAll() {
            let _this = this;
            _this.describe_list = [];
            _this.describe = {};
            is_add: true;
            _this.commdityDetail = {};
            $("#comm_name").val(null);
            $("#comm_scpe").val(null);
            $("#comm_price").val(null);
            $("#comm_price2").val(null);
        },

        send_server(e) {
            var eve = e || window.event;
            let _this = this;
            if ($("#comm_name").val().trim().length <= 0 || $("#comm_scpe").val().trim().length <= 0 ||
                isNaN($("#comm_price").val()) || $("#comm_price2").val().trim().length <= 0) {
                console.log("-----");
                return;
            }
            e.preventDefault();
            var CommInfo = {
                CommdityDetailId: $("#comm_id").val(),
                ComminfoName: $("#comm_name").val(),
                ComminfoSpec: $("#comm_scpe").val(),
                ComminfoPrice: $("#comm_price").val(),
                OfficiaPrice: $("#comm_price2").val(),
                FKGradeId: $("#comm_fkid").val(),
            }
            var data = {
                "CommInfo": CommInfo,
                "DescInfos": _this.describe_list
            };
            console.log(JSON.stringify(data));
            $.ajax({
                type: "POST",
                url: "/commditydetail/edit",
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'text',
                success: function (response) {
                    layer.msg('修改子商品成功!!', {
                        icon: 6,
                        time: 2000
                    });
                }
            });
        }
    }
});

function get_describe_list() {
    vm.describe_list = JSON.parse($("#describes").text());
    console.log(vm.describe_list);
}
get_describe_list();