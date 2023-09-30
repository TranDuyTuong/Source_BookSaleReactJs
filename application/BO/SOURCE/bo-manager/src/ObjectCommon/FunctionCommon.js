import React from "react";
import { validationLogin } from "./Object";
import {
  messageNullEmail,
  messageNullPassword,
  messageErrorLenghtPassword,
} from "../MessageCommon/Message";
import { PasswordMin, PasswordMax } from "../ObjectCommon/EventCommon";
import Cookies from "js-cookie";
import {
  HandleValidationToken,
  HandleValidationRole,
} from "../ApiLablary/ValidationApi";
import { messageTimeOutToken } from "../MessageCommon/Message";
import { HandleInitializaItemMaster } from "../ApiLablary/ItemMasterApi";
import MaskedInput from "react-text-mask";
import createNumberMask from "text-mask-addons/dist/createNumberMask";
import PropTypes from "prop-types";
import { VND } from "../Contants/DataContant";

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

// Check Infomation Staff
export const HandleCheckTokenStaff = async (request) => {
  // Check Token
  var result = await HandleValidationToken(request);
  return result;
};

// Check User Have Role Handle
export const HandleCheckRoleStaff = async (request) => {
  // Check Role
  var result = await HandleValidationRole(request);
  return result;
};

// Check TimeOut Token User
export const HandleCheckTimeOut = () => {
  var timeOut = Date.parse(window.localStorage.getItem("ExpirationDate"));
  var currentDate = Date.now();
  if (timeOut <= currentDate) {
    clearInterval(1000);
    alert(messageTimeOutToken);
    window.location.href = window.location.origin;
  }
};

// Get All Data InitializaItemMaster
export const HandleGetInitializaItemMaster = async (info) => {
  const result = await HandleInitializaItemMaster(info);
  return result;
};

// Conver Money From Input Form
const defaultMaskOptions = {
  prefix: "",
  suffix: " " + VND,
  includeThousandsSeparator: true,
  thousandsSeparatorSymbol: ",",
  allowDecimal: true,
  decimalSymbol: ".",
  decimalLimit: 2, // how many digits allowed after the decimal
  integerLimit: 7, // limit length of integer numbers
  allowNegative: false,
  allowLeadingZeroes: false,
};

export const CurrencyInputMoney = ({ maskOptions, ...inputProps }) => {
  const currencyMask = createNumberMask({
    ...defaultMaskOptions,
    ...maskOptions,
  });

  return <MaskedInput mask={currencyMask} {...inputProps} />;
};

CurrencyInputMoney.defaultProps = {
  inputMode: "numeric",
  maskOptions: {},
};

CurrencyInputMoney.propTypes = {
  inputmode: PropTypes.string,
  maskOptions: PropTypes.shape({
    prefix: PropTypes.string,
    suffix: PropTypes.string,
    includeThousandsSeparator: PropTypes.bool,
    thousandsSeparatorSymbol: PropTypes.string,
    allowDecimal: PropTypes.bool,
    decimalSymbol: PropTypes.string,
    decimalLimit: PropTypes.string,
    requireDecimal: PropTypes.bool,
    allowNegative: PropTypes.bool,
    allowLeadingZeroes: PropTypes.bool,
    integerLimit: PropTypes.number,
  }),
};
