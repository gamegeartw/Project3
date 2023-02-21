$('#btnSubmit').click(function (event) {
    event.preventDefault();
    let form = $('#formAdd');
    $.ajax({
        type: 'POST',
        data: form.serialize(),
        success: function (data) {
            if (data.code === 200) {
                parent.layer.msg(data.message, {icon: 1, time: 1000}, function () {
                    parent.layer.closeAll();
                });
            } else {
                parent.layer.msg(data.message, {icon: 2, time: 1000});
            }
        },
        error: function (data) {}
    });
});
let roles=[];
$('input[type="checkbox"]').iCheck({
    checkboxClass: 'icheckbox_square-blue',
}).on('ifChecked', function (event) {
    let id = $(this).data('id');
    let hiddenRole = $('#hiddenRoles');
    roles.push(id);
    hiddenRole.val(roles.join(','));
}).on('ifUnchecked', function (event) {
    let id = $(this).data('id');
    let hiddenRole = $('#hiddenRoles');
    roles = roles.filter(function (item) {
        return item !== id;
    });
    hiddenRole.val(roles.join(','));
});