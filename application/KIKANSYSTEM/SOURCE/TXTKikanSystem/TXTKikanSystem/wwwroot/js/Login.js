import { LenghtPassword, NullEmail, RemoveCookies, CreateCookies } from '../Common/CommonSetting.js'
import { MessageErrorLenght, MessageEmailNull, UserLogin, MessageRemoveCookiesFail } from '../Common/CommonDataDefault.js'
import { HomePage } from '../Common/CommonUrl.js'
import { DomModalLoading } from '../Common/CommonLoading.js'

$(document).ready(function () {
    // Forcus Input Email when load page
    document.getElementById("TxtEmail").focus();
    var iconError = '<i class="fas fa-exclamation-triangle"></i>';

    // Login System
    $("#Login").click(function () {
        var email = $("#TxtEmail").val();
        var password = $("#TxtPassword").val();
        $("#ErrorPassword").empty();
        $("#ErrorEmail").empty();
        $("#MessageErrorLogin").empty();

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

        // Clear Local Storage
        localStorage.clear();
        // Remove Cookies Curent
        var removeCookies = RemoveCookies(UserLogin);

        if (removeCookies != true) {
            $("#MessageErrorLogin").append(iconError + " " + MessageRemoveCookiesFail);
            return;
        } else {
            // Show dialog Loading
            $("#Loading").append(DomModalLoading());
            $("#dialogLoading").show();
            // Call Api
            $.ajax({
                url: "/SignIn/Login",
                type: "post",
                data: {
                    email: email,
                    password: password
                },
                success: function (result) {
                    // Hide and Remove dialog Loading
                    RemoveDialogLoaing()

                    // Check Result Login
                    if (result.token == null || result.token == "") {
                        $("#MessageErrorLogin").append(iconError + " " + result.messageError);
                        $("#TxtEmail").val('');
                        $("#TxtPassword").val('');
                        document.getElementById("TxtEmail").focus();
                    } else {
                        // Create Cookie for Employer Login
                        var cookieResult = CreateCookies(UserLogin, result.token, result.expirationDate)

                        if (cookieResult == true) {
                            // Create Success save infomation Employer into Local Storage
                            localStorage.setItem("Employer", result.employer);
                            localStorage.setItem("RoleEmployer", result.role);
                            localStorage.setItem("DescriptionRole", result.descriptionRole);
                            localStorage.setItem("ExpirationDate", result.expirationDate);
                            localStorage.setItem("UserID", result.userID);
                            window.location.href = HomePage;
                        } else {
                            // Show Message Error
                            $("#MessageErrorLogin").append(iconError + " " + "Not Create Cookies, Please Contact To Manager");
                            return;
                        }
                    }
                }
            })
        }
    });

    // Hide and remove Dialog Loading
    function RemoveDialogLoaing() {
        // Hide dialog Loading
        $("#dialogLoading").hide();
        var dialogModal = document.getElementById("Loading");
        dialogModal.removeChild(dialogModal.firstElementChild);
    }
});

