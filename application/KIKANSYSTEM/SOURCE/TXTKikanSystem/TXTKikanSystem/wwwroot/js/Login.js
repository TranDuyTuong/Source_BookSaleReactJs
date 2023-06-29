import { hello } from '../Common/CommonSetting.js'

$("form").submit(function () {
    let vardat = hello();
    var email = $("#TxtEmail").val();
    var password = $("#TxtPassword").val();

});