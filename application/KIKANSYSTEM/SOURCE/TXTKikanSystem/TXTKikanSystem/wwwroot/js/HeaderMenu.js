import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
$(document).ready(function () {
    // Get Infomation Emplyoeer in localStorage
    var cookiesname = GetCookies(UserLogin);
    var UserID = localStorage.getItem("UserID");
    var RoleID = localStorage.getItem("RoleEmployer");
    var UserName = localStorage.getItem("Employer");
    var DescriptionRole = localStorage.getItem("DescriptionRole");
    var ExpirationDate = localStorage.getItem("ExpirationDate");

    // Show Employeer Up UI
    $("#NameEmployeer").empty();
    $("#ExpirationDate").empty();
    $("#RoleDescription").empty();

    $("#NameEmployeer").append('<i class="fas fa-user"></i>' + " " + UserName);
    $("#ExpirationDate").append(ExpirationDate);
    $("#RoleDescription").append(DescriptionRole);

    // SetTimeOut Check ExpirationDate 6000 call ValidationTimeOutExpirationDate
    setInterval(() => ValidationTimeOutExpirationDate(), 6000);

    // Check TimeOut ExpirationDate
    function ValidationTimeOutExpirationDate() {
        var expirationDate = new Date(ExpirationDate);
        var converExpirationDateNumber = Date.parse(expirationDate);
        var curentDate = new Date();
        var converCurentDateNumber = Date.parse(curentDate);

        // If converExpirationDateNumber small than converCurentDateNumber
        if (converExpirationDateNumber < converCurentDateNumber) {
            alert("Login session has expired, please login again");
            var queryString = location.origin;
            window.location.href = queryString;
        }
    };

    // SingOut System
    $("#btn_SignOut").click(function () {
        $.ajax({
            url: "SignIn/SignOut",
            type: "post",
            data: {
                token: cookiesname,
                UserID: UserID,
                RoleID: RoleID,
                ExpirationDate: ExpirationDate
            },
            success: function (result) {
                var queryString = location.origin;

                // Check result singOut
                if (result.status == false) {
                    // SignOut Fail redirect to notication SignOut Fail
                    window.location.href = queryString + "/SignIn/SignOutFail" + "?messageError=" + result.message;
                } else {
                    // SignOut Success redirect to Login Page
                    window.location.href = queryString;
                }
            }
        })
    });

});