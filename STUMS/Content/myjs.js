/// <reference path="E:\Lymic\2-源码\C#\A_Ly\STUMS\STUMS\scripts/jquery-1.10.2.min.js" />

/*
    使用：
        myjs.datatable.colNames_list = ["id", "name", "age", "addr"];
        myjs.datatable.colTitle_list = ["Id", "名称", "Age", "Addr"];
        myjs.datatable.url_getlist = "/Content/data.json";
        myjs.datatable.url_update = "/Content/data.json";
        myjs.datatable.url = "/Content/data.json";
        myjs.datatable.main();


*/
myjs = (function () {
    var rr = {
        datatable: {
            /*url返回的json数据：{msg:'',data:[{},{},...]}
            */
            /*设置获取数据的url*/
            url: '',
            /*点击搜索，获取数据的url*/
            url_getlist: '',
            /*modal,里，点击更新，提交的url*/
            url_update: '',
            /*设置列名Name/ID，用于绑定数据，对应Json数据的key*/
            colNames_list: ['id'],
            /*设置列标题 */
            colTitle_list: ['id'],
            /*设置，更新表单的列，考虑：input是否隐藏，默认值，select控件，*/
            colNames_update: ['id'],
            colNames_regex: { ucode: /SDT[0-5]{5}/i },
            /*设置设置搜索栏的列*/
            colNames_search: ['id'],
            /*设置列模板*/
            col_templet: {
                id: function (data, type, row) {
                    return "<b>" + data + "</b>";
                },
                /*渲染列的模板函数，data--列值*/
                state: function (data, type, row) {
                    var html = "";
                    if (data == 0) {
                        html = "<span class='label label-danger'>已删除</span>"
                    } else if (data == 1) {
                        html = "<span class='label label-primary'>正常</span>"
                    } else if (data == 2) {
                        html = "<span class='label label-sucess'>已审核</span>"
                    } else {
                        html = "<span class='label label-warning'>其他</span>"
                    }
                    return html;
                },
            },
            /*默认设置，用于记录默认值*/
            default_setting: {
                table_id: '#table_main',
                sWidth: "120px",/*列宽*/
                btn_insert_layer: '#btn_insert_layer',
                thead_tr_input_id: 'thead_tr_input_id',
                thead_tr_input_style: 'background-color:#feeeed;',
                tr_input_class: 'tr-input-l',
                modal_id: 'modal_add',
                is_head_input: false,  /* 是否在thead里生成输入框行，用于维护数据 */
                is_modal_input: true, /* 是否生成弹出框，用于维护数据 */
                /*是否在页面加载时，查询数据*/
                is_loading_select_data: true,
                /*搜索栏，form id*/
                form_search_id: 'form_search',
                /*更新窗口，form id*/
                form_add_id: 'form_add',
                /*按钮，查询按钮*/
                btn_search_id: 'btn_search_ok',
                /*按钮，确认更新按钮*/
                btn_inup_id: 'btn_inup_ok',
            },
            /*生成后的列list，暂存*/
            x_aoColumns: [],
            /*用于生成列list，main的第一步*/
            xInitCols: function () {
                rr.datatable.x_aoColumns = []; // 置空
                rr.datatable.colNames_list.forEach(function (e, i) { //循环列名，生成列
                    rr.datatable.x_aoColumns.push({
                        "data": e,//获取列数据
                        "class": "center",//显示样式
                        "render": (rr.datatable.col_templet[e] ? rr.datatable.col_templet[e] : null),
                        "title": (rr.datatable.colTitle_list[i] || e),
                        "width": rr.datatable.default_setting.sWidth
                    });
                });
            },
            /*初始化表格，main的第二步*/
            tableInit: () => {
                /* 生成 datatable，并设置行列 */
                $(rr.datatable.default_setting.table_id).dataTable({
                    ajax: rr.datatable.url,
                    columns:rr.datatable.x_aoColumns
                });
            },
            tableInit2: (data_array) => {
                /*生成表格的表格头部表头*/                
                let thead = $('<thead style="border-bottom:2px solid green;"></thead>');
                let tr = $('<tr></tr>');
                rr.datatable.colNames_list.forEach((e, i) => {
                    tr.append('<th>' + (rr.datatable.colTitle_list[i] || e) + '</th>');
                });
                thead.append(tr);
                let table_id = rr.datatable.default_setting.table_id;
                $(table_id).append(thead);
                /*绑定表格的数据*/
                $(table_id).dataTable({
                    /*绑定数据[{},{}...]*/
                    data: data_array,
                    /*设置列配置 
                     *[{ data:'id',render:(data,type,row)=>{}  },...]
                     */
                    columns: rr.datatable.x_aoColumns,
                    /*设置列格式定义*/
                    columnDefs: [
                        {
                            targets: -1,
                            className: 'dt-body-center'
                        }
                    ],
                });
            },
            /*生成，头部表头第二行的 输入栏 */
            init_thead_input: function () {
                if (!rr.datatable.default_setting.is_head_input) { return;}
                let tr_input_id = rr.datatable.default_setting.thead_tr_input_id;
                let tr_input_class = rr.datatable.default_setting.tr_input_class;
                let tableid = rr.datatable.default_setting.table_id;
                let tr_style = rr.datatable.default_setting.thead_tr_input_style;

                let tr_input = $('<tr id="' + tr_input_id + '" style="' + tr_style + '"></tr>');/*表头的输入框*/
                rr.datatable.colNames_list.forEach((e, i) => {
                    tr_input.append('<th><input type="text" name="' + e + '" class="form-control ' + tr_input_class + '" style="boder-color:green;"/></th>');
                });
                $(tableid + " thead").append(tr_input);
            },
            set_data_to_input_by_name:function(data){
                if (data) {
                    for (let key in data) {
                        $("[name=" + key + "]").each(function (i, e) {
                            $(e).val(data[key]);
                        });
                    }
                }
            },
            /*查询函数*/
            select: function () {
                let fid = rr.datatable.default_setting.form_search_id;
                let search_data = $('#' + fid).serialize();
                let url_getlist = rr.datatable.url_getlist;
                $.get(url_getlist, search_data, (r) => {
                    //rr.datatable.main(r.data);

                });
            },
            /*更新函数*/
            update: function () {
                let formid = rr.datatable.default_setting.form_add_id;
                let url_updata = rr.datatable.url_update;
                /*校验更新数据的必填项 和 正则表达式*/
                if ($('#' + formid)[0].checkValidity() && rr.datatable.chk_regx()) {
                    let data_inup = $('#' + formid).serialize();
                    $.post(url_updata, data_inup, (r) => {
                        alert(r.msg);
                    });
                } else {
                    alert("请将 [ *必填项 ] 填写完成");
                }
            },
            /*正则校验函数*/
            chk_regx: function () {
                let bb = true;
                let formid = rr.datatable.default_setting.form_add_id;
                let regexs = rr.datatable.colNames_regex;
                $('#' + formid + ' input').each(function (i, e) {
                    let name = $(e).attr('name');
                    let val = $(e).val();
                    if (regexs[name]) {
                        if (regexs[name].test(val)) {

                        } else {
                            /*z正则校验不通过*/
                            $(e).css('color', 'red');
                            bb = false;
                        }
                    }
                });
                return bb;
            },
            /*主函数，初始化*/
            main: (data_array) => {
                let tableid = rr.datatable.default_setting.table_id;
              
                rr.datatable.xInitCols(); /*生成 列list*/
                //rr.datatable.tableInit2(data_array); /*绑定数据表格*/
                rr.datatable.tableInit(); /*绑定数据表格*/
                rr.datatable.init_thead_input();

                /*按钮点击事件，新增按钮点击事件，弹出新增框*/
                let tr_id_in =  rr.datatable.default_setting.thead_tr_input_id;
                $(rr.datatable.default_setting.btn_insert_layer).click(() => {
                    $('#' + tr_id_in).toggle();
                });

                /*行点击事件*/
                var table = $(tableid).DataTable();
                let SetData = rr.datatable.set_data_to_input_by_name; /*传值函数*/
                $(tableid+' tbody').on('click', 'tr', function () {
                    var data = table.row(this).data();
                    //console.log(data);
                    SetData(data);
                });

                /*行双击事件*/
                var modal_id = rr.datatable.default_setting.modal_id;
                $(tableid + ' tbody').on('dblclick', 'tr', function () {
                    var data = table.row(this).data();                    
                    SetData(data);
                    $('#' + tr_id_in).toggle();
                    $('#'+modal_id).modal('toggle');
                });

                /*查询按钮点击事件*/
                let btn_search_id = rr.datatable.default_setting.btn_search_id;
                $('#' + btn_search_id).click(function () {
                    rr.datatable.select();
                });

                /*初始化时，运行，获取表格数据*/
                if (rr.datatable.default_setting.is_loading_select_data) {
                    rr.datatable.select(); 
                }
                
                /*更新按钮点击事件*/
                let btn_inup_id = rr.datatable.default_setting.btn_inup_id;
                $('#' + btn_inup_id).click(function () {
                    rr.datatable.update();
                });
            },
        },


        
    };
    return rr;
})();