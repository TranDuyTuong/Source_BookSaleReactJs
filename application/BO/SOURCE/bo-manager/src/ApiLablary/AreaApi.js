import instance from "../ApiLablary/Axios";
import { SeachArea_Get } from "../ObjectCommon/ApiCommon";
import { M_ListArea } from "../ObjectCommon/Object";
import { get } from "../Contants/DataContant";

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

// Handle Validation Token Staff
export const HandleSeachArea = async (request) => {
  const data = await AreaAPI(request, SeachArea_Get, get);
  // Set Data result
  var result = M_ListArea;

  if (data.Status === true) {
    // Save List Area Into Redux
  } else {
    // Show Message Error
    result.Status = data.Status;
    result.MessageError = data.MessageError;
  }
  return result;
};
