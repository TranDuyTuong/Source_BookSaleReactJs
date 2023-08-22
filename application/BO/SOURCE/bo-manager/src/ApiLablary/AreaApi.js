import instance from "../ApiLablary/Axios";
import { SeachArea_Get, ConfirmArea_Post } from "../ObjectCommon/ApiCommon";
import { M_ListArea } from "../ObjectCommon/Object";
import { post } from "../Contants/DataContant";

// Api Login User
const AreaAPI = (info, URL, TYPE) => {
  switch (TYPE) {
    case "get":
      const resultGet = instance.get(`${URL}`, info);
      return resultGet;
    case "post":
      const resultPost = instance.post(`${URL}`, info);
      return resultPost;
    default:
      break;
  }
};

// Handle Seach Area
export const HandleSeachArea = async (request) => {
  const data = await AreaAPI(request, SeachArea_Get, post);
  // Set Data result
  var result = M_ListArea;

  if (data.Status === true) {
    result.Status = data.Status;
    result.ListArea = data.ListArea;
    result.TotalArea = data.TotalArea;
    result.CompanyCode = data.CompanyCode;
    result.MessageError = data.MessageError;
  } else {
    // Show Message Error
    result.Status = data.Status;
    result.MessageError = data.MessageError;
  }
  return result;
};

// Handle Confirm Area
export const HandleConfirmArea = async (request) => {
  const data = await AreaAPI(request, ConfirmArea_Post, post);
  // Set Data result
  var result = M_ListArea;

  if (data.Status === true) {
    result.Status = data.Status;
  } else {
    result.Status = data.Status;
    result.MessageError = data.MessageError;
  }
  return result;
};
