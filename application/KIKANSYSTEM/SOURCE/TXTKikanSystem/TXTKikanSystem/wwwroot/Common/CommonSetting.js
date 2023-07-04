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
export function CreateCookies(cookiesName, cookiesValue, daysToExpire) {
    // create daysToExpire
    var date = new Date();

    // check daysToExpire null
    if (daysToExpire == null || daysToExpire == undefined || daysToExpire == 0 || daysToExpire == "") {
        return false;
    }

    // check cookiesValue
    if (cookiesValue == null || cookiesValue == undefined || cookiesValue == "") {
        return false;
    }

    date.setTime(date.getTime() + (daysToExpire * 24 * 60 * 60 * 1000));
    // create cookies
    document.cookie = cookiesName + "=" + cookiesValue + ", expires=" + date.toGMTString();
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