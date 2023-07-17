$(document).ready(function () {
    // Get Infomation Emplyoeer in localStorage
    var UserID = localStorage.getItem("UserID");
    var UserName = localStorage.getItem("Employer");
    var DescriptionRole = localStorage.getItem("DescriptionRole");
    var ExpirationDate = localStorage.getItem("ExpirationDate");

    // Show Employeer Up UI
    $("#NameEmployeer").empty();
    $("#ExpirationDate").empty();
    $("#RoleDescription").empty();

    $("#NameEmployeer").append(UserID + " " + UserName);
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
    }

});