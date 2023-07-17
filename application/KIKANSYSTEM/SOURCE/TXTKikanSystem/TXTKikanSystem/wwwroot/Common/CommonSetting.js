import { PasswordMin, PasswordMax, UserLogin} from '../Common/CommonDataDefault.js'

// Validation Length password 
export function LenghtPassword(pasword) {
    var checkLenght = pasword.length;
    if (checkLenght > PasswordMin && checkLenght < PasswordMax) {
        return true;
    } else {
        return false
    }
}

// Validation Email 
export function NullEmail(email) {
    if (email == null || email == undefined || email == "") {
        return false;
    } else {
        return true;
    }
}

// Create Cookies
export function CreateCookies(cookiesName, cookiesValue) {

    // check cookiesValue
    if (cookiesValue == null || cookiesValue == undefined || cookiesValue == "") {
        return false;
    }
    // create cookies
    document.cookie = cookiesName + "=" + cookiesValue;
    return true;
}

// Remove Cookies
export function RemoveCookies(cookiesName) {
    // check cookiesName
    if (cookiesName == null || cookiesName == undefined || cookiesName == "") {
        return false;
    } else {
        document.cookie = cookiesName + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        return true;
    }
}

// Get Cookies
export function GetCookies(cookie_name) {
    const value = "; " + document.cookie;
    const parts = value.split("; " + cookie_name + "=");
    if (parts.length === 2) return parts.pop().split(";").shift();
}