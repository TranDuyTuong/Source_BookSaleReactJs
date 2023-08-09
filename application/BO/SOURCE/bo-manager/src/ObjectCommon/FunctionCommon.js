import { validationLogin } from "./Object";
import {
  messageNullEmail,
  messageNullPassword,
  messageErrorLenghtPassword,
} from "../MessageCommon/Message";
import { PasswordMin, PasswordMax } from "../ObjectCommon/EventCommon";
import Cookies from "js-cookie";

// Validation Input
export function ValidationInput(email, password) {
  validationLogin.Status = true;

  // Check Null Email
  if (email === null || email === "" || email === undefined) {
    validationLogin.Status = false;
    validationLogin.Message = messageNullEmail;
    validationLogin.Type = 1; // Email
  } else {
    // Check Null Password
    if (password === null || password === "" || password === undefined) {
      validationLogin.Status = false;
      validationLogin.Message = messageNullPassword;
      validationLogin.Type = 2; // Password
    }
  }
  return validationLogin;
}

// Remove Cookies
export function RemoveCookies(cookiesName) {
  // check cookiesName
  if (cookiesName == null || cookiesName === undefined || cookiesName === "") {
    return false;
  } else {
    document.cookie = cookiesName + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
    return true;
  }
}

// Create Cookies
export function CreateCookies(cookiesName, cookiesValue) {
  // check cookiesValue
  if (
    cookiesValue == null ||
    cookiesValue === undefined ||
    cookiesValue === ""
  ) {
    return false;
  }
  // create cookies
  Cookies.set(cookiesName, cookiesValue);
  return true;
}

// Get Cookies
export function GetCookies(cookie_name) {
  const value = "; " + document.cookie;
  const parts = value.split("; " + cookie_name + "=");
  if (parts.length === 2) return parts.pop().split(";").shift();
}

// Validation Length password
export function LenghtPassword(pasword) {
  var checkLenght = pasword.length;
  if (checkLenght > PasswordMin && checkLenght < PasswordMax) {
    validationLogin.Status = true;
  } else {
    validationLogin.Status = false;
    validationLogin.Message = messageErrorLenghtPassword;
  }
  return validationLogin;
}

// ConcatStringEvent
export function ConcatStringEvent(str1, str2) {
  var result = str1 + str2;
  return result;
}
