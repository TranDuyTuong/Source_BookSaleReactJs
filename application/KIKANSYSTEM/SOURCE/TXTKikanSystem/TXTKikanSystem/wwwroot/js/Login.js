import { LenghtPassword, NullEmail, RemoveCookies } from '../Common/CommonSetting.js'
import { MessageErrorLenght, MessageEmailNull, UserLogin, MessageRemoveCookiesFail } from '../Common/CommonDataDefault.js'

$("#Login").click(function () {
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
            data: {
                email: email,
                password: password
            },
            success: function (result) {
                var converJSON = JSON.parse(result);
                console.log(converJSON);
                if (converJSON.Status == true) {
                    switch (converJSON.Message) {
                        case "000_5":
                            break;
                        default:
                            break;
                    }
                } else {

                }
                return;
            }
        })
    }
});
