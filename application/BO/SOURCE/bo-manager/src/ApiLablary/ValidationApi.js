import instance from "../ApiLablary/Axios";
import {
  CheckTokenUser_Post,
  CheckRoleUser_Post,
} from "../ObjectCommon/ApiCommon";
import { ReturnCommonApi } from "../ObjectCommon/Object";
import { messageUserNotHaveRole } from "../MessageCommon/Message";

// Api validation role limit
const postDataValidationAPI = (info, URL) => {
  const result = instance.post(`${URL}`, info);
  return result;
};

// Handle Validation Token Staff
export const HandleValidationToken = async (request) => {
  const data = await postDataValidationAPI(request, CheckTokenUser_Post);
  // Set Data result
  var result = ReturnCommonApi;
  result.Status = data.Status;
  result.IdPlugin = data.IdPlugin;
  result.Message = data.Message;
  return result;
};

// Handle Validation Role Staff
export const HandleValidationRole = async (request) => {
  const data = await postDataValidationAPI(request, CheckRoleUser_Post);
  // Set Data Result
  var result = ReturnCommonApi;

  if (data === undefined) {
    alert("Error, Accessing Invalid Url, Please Contact Manager!");
    // Call Api error 500 Return login page
    window.location.href = window.location.origin;
  } else {
    if (data.Status === true) {
      // Staff Don't have role Handle
      result.Status = true;
      result.Message = messageUserNotHaveRole;
    } else {
      // Staff Have Role Handle
      result.Status = false;
    }
  }
  return result;
};
