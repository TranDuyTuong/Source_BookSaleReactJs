import { LenghtPassword, NullEmail } from '../Common/CommonSetting.js'
import { MessageErrorLenght, MessageEmailNull } from '../Common/CommonDataDefault.js'

$("form").submit(function (e) {
    var email = $("#TxtEmail").val();
    var password = $("#TxtPassword").val();
    $("#ErrorPassword").empty();
    $("#ErrorEmail").empty();

    // Check null email
    var checkNullEmail = NullEmail(email);

    if (checkNullEmail != true) {
        document.getElementById("TxtEmail").style.border = "2px solid red";
        document.getElementById("TxtEmail").style.background = "yellow";
        $("#ErrorEmail").append(MessageEmailNull);
        e.preventDefault();
        return;
    } else {
        document.getElementById("TxtEmail").style.border = "1px solid";
        document.getElementById("TxtEmail").style.background = "none";
    }

    // Check lenght for password
    var checkLengthPassword = LenghtPassword(password);
   
    if (checkLengthPassword != true) {
        document.getElementById("TxtPassword").style.border = "2px solid red";
        document.getElementById("TxtPassword").style.background = "yellow";
        $("#ErrorPassword").append(MessageErrorLenght);
        e.preventDefault();
        return;
    } else {
        document.getElementById("TxtEmail").style.border = "1px solid";
        document.getElementById("TxtEmail").style.background = "none";
    }

    // Call Api
});