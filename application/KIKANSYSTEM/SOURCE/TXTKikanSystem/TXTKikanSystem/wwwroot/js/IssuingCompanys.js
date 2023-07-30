import { GetCookies } from '../Common/CommonSetting.js'
import { UserLogin } from '../Common/CommonDataDefault.js'
import { HomePage } from '../Common/CommonUrl.js'
import { DomModalLoading } from '../Common/CommonLoading.js'

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
    $("#btn_SubmitFile").click(function () {
        //preventDefault();
        //stopImmediatePropagation();
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

            // Get Info Employeer
            var cookiesname = GetCookies(UserLogin);
            // Setting string for Carshier
            var stringData = localStorage.getItem("UserID") + "*" + localStorage.getItem("RoleEmployer") + "*" + cookiesname;
            submitFile.append("Carshier", stringData);

            // Show dialog Loading
            $("#Loading").append(DomModalLoading());
            $("#dialogLoading").show();

            // Sent File Ajax
            $.ajax({
                url: "/Imports/ReadContentFileImport",
                type: "post",
                data: submitFile,
                contentType: false,
                processData: false,
                success: function (result) {
                    $("#formFile").val('');
                    $("#dialogImport").hide();
                    // Close dialog loading
                    RemoveDialogLoaing()

                    // Redirect Page Message Error
                    var queryString = location.origin;
                    if (result == 0) {
                        window.location.href = queryString;
                    }
                    if (result == 1) {
                        window.location.href = queryString + "/Imports/ErrorMessagePage";
                    }

                    // If Have Call Api Success
                    switch (result.status) {
                        case true:
                            toastr.success("Success !", result.message);
                            break;
                        case false:
                            toastr.error("Error !", result.message);
                            break;
                        default:
                            return;
                    }
                }
            })
        }
        return;
    });

    // Hide and remove Dialog Loading
    function RemoveDialogLoaing() {
        // Hide dialog Loading
        $("#dialogLoading").hide();
        var dialogModal = document.getElementById("Loading");
        dialogModal.removeChild(dialogModal.firstElementChild);
    }

})