import { LenghtPassword } from '../Common/CommonSetting.js'

$("form").submit(function () {
    var email = $("#TxtEmail").val();
    var password = $("#TxtPassword").val();
    var checkLengthPassword = LenghtPassword(password);
    if (checkLengthPassword == true) {
        alert("ok");
    } else {
        alert("not ok");
    }
});