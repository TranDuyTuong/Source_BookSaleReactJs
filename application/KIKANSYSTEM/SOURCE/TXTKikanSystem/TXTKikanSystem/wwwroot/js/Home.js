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

    // click redirect to ImportCategory Page
    $("#btn_ImportCategorys").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/Categorys" + "?Carshier=" + stringData;
    });

    // click redirect to ImportCitys Page
    $("#btn_ImportCitys").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/Citys" + "?Carshier=" + stringData;
    });

    // click redirect to ImportDistrict Page
    $("#btn_ImportDistrict").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/Districts" + "?Carshier=" + stringData;
    });

    // click redirect to ImportAuthors Page
    $("#btn_ImportAuthors").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/Authors" + "?Carshier=" + stringData;
    });

    // click redirect to ImportPublishingCompany Page
    $("#btn_ImportPublishingCompany").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/PublishingCompany" + "?Carshier=" + stringData;
    });

    // click redirect to ImportPublisher Page
    $("#btn_ImportPublisher").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/IssuingCompanys" + "?Carshier=" + stringData;
    });

    // click redirect to ImportPublisher Page
    $("#btn_ImportPublisher").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/IssuingCompanys" + "?Carshier=" + stringData;
    });

    // click redirect to ImportPublisher Page
    $("#btn_BankSuport").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + "Imports/BankSuports" + "?Carshier=" + stringData;
    });

})