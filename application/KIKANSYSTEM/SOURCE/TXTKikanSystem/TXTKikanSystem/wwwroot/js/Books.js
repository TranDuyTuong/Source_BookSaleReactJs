import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
import { HomePage } from '../Common/CommonUrl.js'
$(document).ready(function () {
    var idCloseDialog;

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
        $("#dialogImport").show();
    });

    // Close dialog Import File
    $("#btn_closeImportFile").click(function () {
        $("#formFile").val('');
        $("#dialogImport").hide();
    });

    // Dowload Template File
    $("#btn_DowloadTemplate").click(function () {
        var cookiesname = GetCookies(UserLogin);
        // Setting string for Carshier
        var queryString = location.origin;
        var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
        window.location.href = queryString + "/Imports/DowloadTemplate" + "?Carshier=" + stringData;
    })

    // Submit file Import
    $("#btn_SubmitFile").click(function ()
    {
        // Check File Import
        if ($("#formFile").val() == null || $("#formFile").val() == undefined || $("#formFile").val() == "") {
            alert("Please choose a File");
        } else {
            var file = $("#formFile").prop("files");
            var submitFile = new FormData();

            // Get file Import
            for (var i = 0; i < file.length; i++) {
                submitFile.append("ImportExcelBook", file[i]);
            }

            // Sent File Ajax
            $.ajax({
                url: "/Imports/ReadContentFileImport",
                type: "post",
                data: submitFile,
                contentType: false,
                processData: false,
                success: function (result) {

                }
            })
        }
        return;
    });

})