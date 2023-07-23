import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
$(document).ready(function () {
    // click redirect to ImportBook Page
    $("#btn_ImportBooks").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/Books" + "?Carshier=" + stringData;
    });
})