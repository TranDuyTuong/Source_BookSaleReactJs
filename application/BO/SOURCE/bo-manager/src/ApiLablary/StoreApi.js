import instance from "../ApiLablary/Axios";
import { SeachStore_Get } from "../ObjectCommon/ApiCommon";
import { M_ListStore } from "../ObjectCommon/Object";
import { post } from "../Contants/DataContant";

// Api Login User
const StoreAPI = (info, URL, TYPE) => {
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

// Handle Seach Store
export const HandleSeachStore = async (request) => {
  const data = await StoreAPI(request, SeachStore_Get, post);
  // Set Data result
  var result = M_ListStore;

  if (data.Status === true) {
    result.Status = data.Status;
    result.ListStore = data.ListStore;
    result.TotalStore = data.TotalStore;
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
/*
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
};*/
