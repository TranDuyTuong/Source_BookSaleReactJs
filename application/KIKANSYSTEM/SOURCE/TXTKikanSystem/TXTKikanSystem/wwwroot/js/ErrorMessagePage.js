import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
$(document).ready(function () {

    // Back ToCurrent Page
    $("#btn_ReditectHome").click(function () {
        var curentpage = $("#Txt_CurentPage").val();
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/Imports/" + curentpage + "?Carshier=" + stringData;
    })
})