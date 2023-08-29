import instance from "../ApiLablary/Axios";
import { InitializaItemMaster_Post } from "../ObjectCommon/ApiCommon";
import { post } from "../Contants/DataContant";

// Api Item Master
const ItemMasterAPI = (info, URL, TYPE) => {
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

// Handle Initializa Item Master
export const HandleInitializaItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, InitializaItemMaster_Post, post);

  // Set Data result
  if (data.Status === true) {
    const result = {
      Status: data.Status,
      ListStore: data.ListStore,
    };
    return result;
  } else {
    // Show Message Error
    const result = {
      Status: data.Status,
      MessageError: data.MessageError,
    };
    return result;
  }
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
