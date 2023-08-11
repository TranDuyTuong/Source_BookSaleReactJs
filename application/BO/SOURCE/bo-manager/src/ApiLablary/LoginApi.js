import instance from "../ApiLablary/Axios";
import jwt_decode from "jwt-decode";
import { UserLogin_Post } from "../ObjectCommon/ApiCommon";
import { CreateCookies } from "../ObjectCommon/FunctionCommon";
import { ResultLogin } from "../ObjectCommon/Object";
import { messageCreateCookieFail } from "../MessageCommon/Message";
import { UserLogin } from "../ObjectCommon/EventCommon";

// Api Login User
const postDataLoginAPI = (info) => {
  const result = instance.post(`${UserLogin_Post}`, info);
  return result;
};

export const ServiceHandleLogin = async (request) => {
  const data = await postDataLoginAPI(request);
  // check result login
  var result = ResultLogin;

  if (data.Status === true) {
    // Read Value Token
    const tokenValue = jwt_decode(data.Token);

    // Create Cookie for Employer Login save in local
    var cookieResult = CreateCookies(UserLogin, data.Token);

    if (cookieResult === true) {
      // Create Success save infomation Employer into Local Storage
      window.localStorage.setItem("Employer", tokenValue.employerName);
      window.localStorage.setItem("RoleEmployer", tokenValue.roleID);
      window.localStorage.setItem("DescriptionRole", tokenValue.nameRole);
      window.localStorage.setItem("ExpirationDate", tokenValue.experiedDate);
      window.localStorage.setItem("UserID", tokenValue.userID);
      // Login Success
      result.Status = data.Status;
    } else {
      // Show Message Error
      result.Status = false;
      result.Message = messageCreateCookieFail;
    }
  } else {
    // Login Fail
    result.Status = data.Status;
    result.Message = data.Message;
  }

  return result;
};
