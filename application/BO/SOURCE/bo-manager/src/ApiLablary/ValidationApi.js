import instance from "../ApiLablary/Axios";
import { CheckTokenUser_Post } from "../ObjectCommon/ApiCommon";
import { ReturnCommonApi } from "../ObjectCommon/Object";

// Api Login User
const postDataValidationTokenAPI = (info) => {
  const result = instance.post(`${CheckTokenUser_Post}`, info);
  return result;
};

// Handle Validation Token Staff
export const HandleValidationToken = async (request) => {
  const data = await postDataValidationTokenAPI(request);
  // Set Data result
  var result = ReturnCommonApi;
  result.Status = data.Status;
  result.IdPlugin = data.IdPlugin;
  result.Message = data.Message;
  return result;
};
