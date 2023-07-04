import { LenghtPassword, NullEmail, RemoveCookies } from '../Common/CommonSetting.js'
import { MessageErrorLenght, MessageEmailNull, UserLogin, MessageRemoveCookiesFail } from '../Common/CommonDataDefault.js'

$("form").submit(function (e) {
    var email = $("#TxtEmail").val();
    var password = $("#TxtPassword").val();
    $("#ErrorPassword").empty();
    $("#ErrorEmail").empty();
    $("#ErrorMessageRemoveCookies").empty();

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

    // Remove Cookies Curent
    var removeCookies = RemoveCookies(UserLogin);
    if (removeCookies != true) {
        $("#ErrorMessageRemoveCookies").append(MessageRemoveCookiesFail);
        return;
    } else {
        // Call Api
        $.ajax({
            url: "/SignIn/Login",
            type: "post",
            data: JSON.stringify({
                Email: email,
                Password: password,
                RememberMe: true,
            }),
            dataType: "json",
            success: function (result) {

            }
        })
    }
});