import instance from "../ApiLablary/Axios";
import { UserSignOut_Post } from "../ObjectCommon/ApiCommon";
import { ReturnCommonApi } from "../ObjectCommon/Object";

// Api Login User
const postDataSignOutAPI = (info) => {
  const result = instance.post(`${UserSignOut_Post}`, info);
  return result;
};

export const ServiceHandleSignOut = async (request) => {
  const data = await postDataSignOutAPI(request);
  // Set Data Result
  var result = ReturnCommonApi;
  if (data.Status === true) {
    // SignOut Success
    result.Status = true;
  } else {
    // SignOut Fail have message Error
    result.Status = false;
    result.Message = data.Message;
  }
  return result;
};
