import { PasswordMin, PasswordMax } from '../Common/CommonDataDefault.js'

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