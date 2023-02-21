//用於頁面初始化之後載入頁面
function loadProperties(language) {
    jQuery.i18n.properties({ // 載入資瀏覽器語言對應的資原始檔
        name: 'lang', // 資原始檔名稱
        path: './i18n/', // 資原始檔路徑
        cache: true,
        language: language, //zh中文  en英文
        mode: 'map', // 用 Map 的方式使用資原始檔中的值
        callback: function() { // 載入成功後設定顯示內容
            //   $(document).attr("title",$.i18n.prop('login.title'));

            var insertEle = $(".i18n");
            insertEle.each(function() {
                // 根據i18n元素的 ID 獲取內容寫入頁面熱
                // $(this).html($(this).attr('data-lang'));
                try {
                    if(typeof($(this).attr("placeholder"))!="undefined"){
                        $(this).attr("placeholder",$.i18n.prop($(this).attr('data-lang')));
                    }else if(typeof($(this).attr("button"))!="undefined"){
                        $(this).attr("button",$.i18n.prop($(this).attr('data-lang')));
                    }else {
                        $(this).html($.i18n.prop($(this).attr('data-lang')));
                    }
                } catch(e) {

                    console.log("key不存在，請在配置檔案中配置對應的key：" + $(this).attr('data-lang'));
                }
            });
        }
    });
};