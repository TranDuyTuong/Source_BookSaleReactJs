﻿import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
import { HomePage } from '../Common/CommonUrl.js'
import { ModalImportFile } from '../Common/CommonLoading.js'
$(document).ready(function () {

    // Reditrect Home Page
    $("#Btn_ReditrectHome").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/" + HomePage + "?Carshier=" + stringData;
    });

    // Show dialog Import File
    $("#btn_ShowDialogFile").click(function () {
        $("#ImportFile").append(ModalImportFile("Import Books File"));
        $("#dialogImport").show();
    });

})