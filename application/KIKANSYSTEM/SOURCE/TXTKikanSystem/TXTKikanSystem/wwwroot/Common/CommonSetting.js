import { PasswordMin, PasswordMax } from '../Common/CommonDataDefault'
// Validation Length password 
export function LenghtPassword(pasword) {
    var checkLenght = pasword.length;
    if (checkLenght > PasswordMin && checkLenght < PasswordMax) {
        return true;
    } else {
        return false
    }
}