$(function () {
    $('input').iCheck({
        checkboxClass: 'icheckbox_square-blue',
        radioClass: 'iradio_square-blue',
        increaseArea: '20%' /* optional */
    });
    const lang = localStorage.getItem('lang');
    if (lang) {
        $('#ddlLang').val(lang);
    }else{
        $('#ddlLang').val('zh-Hant');
    }
});

$('#form1').submit(function() {
        let index = layer.load(1, {
        shade: [0.5, '#000'] //0.5透明度的白色背景
    });
});

$('#ddlLang').change(function() {
    localStorage.setItem('lang', $(this).val());
    let qs=location.search.substring(1);
    let qsArr=qs.split('&');
    let langIndex=-1;
    for(let i=0;i<qsArr.length;i++){
        if(qsArr[i].indexOf('culture=')>-1){
            langIndex=i;
            break;
        }
    }
    
    if(langIndex>-1){
        qsArr[langIndex]='culture='+$(this).val();
    }else{
        qsArr.push('culture='+$(this).val());
    }
    qs=qsArr.join('&');
    
    location.search=qs;
});