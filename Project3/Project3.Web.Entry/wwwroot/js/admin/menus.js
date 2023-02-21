$(function () {
    
    $(".table").dataTable({
        "paging": false,
        "dom": "Bfrtip",
        "colReorder": true,
        "buttons": [
            {
                "text": '新增',
                "className": 'btn btn-primary btn-flat',
                "action": function (e, dt, node, config) {
                    console.log(dt);
                    console.log(e);
                    parent.layer.open({
                        type: 2,
                        title: '新增選單',
                        shadeClose: true,
                        shade: 0.8,
                        area: ['800px', '500px'],
                        content: 'admin/menus/add',
                        end: function () {
                            location.reload();
                        }
                    });
                }
            }
        ]
    });
});

$('.edit').click(function (event) {
    event.preventDefault();
    let id = $(this).data('id');
    parent.layer.open({
        type: 2,
        title: '編輯選單',
        shadeClose: true,
        shade: 0.8,
        area: ['800px', '500px'],
        content: 'admin/menus/edit/' + id,
        end: function () {
            location.reload();
        }
    });
});
$('.delete').click(function (event) {
    event.preventDefault();
    let id = $(this).data('id');
    parent.layer.confirm('確定要刪除嗎？', {icon: 3, title: '提示'}, function (index) {
        let form = $('#form');
        form.find('input[name="id"]').val(id);
        $.ajax({
            url: 'menus?handler=Delete',
            type: 'POST',
            data: form.serialize(),
            success: function (res) {
                if (res.code === 200) {
                    parent.layer.msg('刪除成功', {
                        icon: 1, time: 1000, end: function () {
                            location.reload();
                        }
                    });

                } else {
                    parent.layer.msg(res.message, {icon: 2});
                }
            }
        });
        parent.layer.close(index);
    });
});

$('.detail').click(function (event) {
    event.preventDefault();
    let id = $(this).data('id');
    parent.layer.open({
        type: 2,
        title: '選單詳情',
        shadeClose: true,
        shade: 0.8,
        area: ['800px', '500px'],
        content: 'admin/menus/detail/' + id,
        end: function () {
            location.reload();
        }
    });
});

$('.move').click(function (event) {
    event.preventDefault();
    let id = $(this).data('id');
    let type = $(this).data('type');
    console.log('id='+id);
    console.log('type='+type);
    $('input[name="id"]').val(id);
    $('input[name="type"]').val(type);
    $.ajax({
        url: 'menus?handler=Move',
        type: 'POST',
        data: $('#form').serialize(),
        success: function (res) {
            if (res.code === 200) {
                parent.layer.msg('移動成功', {
                    icon: 1, time: 1000, end: function () {
                        location.reload();
                    }
                });

            } else {
                parent.layer.msg(res.message, {icon: 2});
            }
        },
        error: function (res) {
            parent.layer.msg(res.message, {icon: 2});
        }
    });
});