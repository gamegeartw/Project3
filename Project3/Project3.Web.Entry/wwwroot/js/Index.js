// 系统内部切换主题 
function switchSkin() {
    top.layer.open({
        type : 2,
        shadeClose : true,
        title : "切换主题",
        area : ["530px", "386px"],
        content : ["AdminLTE-Iframe/views/skin.html", 'no']
    })
}

function openUserPanel() {
    top.layer.open({
        type : 2,
        shadeClose : true,
        title : "个人中心",
        area : ["800px", "500px"],
        content : ["AdminLTE-Iframe/views/user.html", 'no']
    });
}

function openChangePwdPanel() {
    top.layer.open({
        type : 2,
        shadeClose : true,
        title : "修改密码",
        area : ["800px", "500px"],
        content : ["AdminLTE-Iframe/views/changePwd.html", 'no']
    });
}