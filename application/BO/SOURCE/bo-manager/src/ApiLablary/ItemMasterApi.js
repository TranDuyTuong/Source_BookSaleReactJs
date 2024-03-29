import instance from "../ApiLablary/Axios";
import {
  InitializaItemMaster_Post,
  SeachItemMaster_Post,
  ValidationItemMaster_Post,
  CreateItemMaster_Post,
  GetAllItemMaster_Post,
  SeachUpdateItemMaster_Post,
  UpdateItemMaster_Post,
  SeachItemMasterUpdatePrice_Post,
  ChangePriceItemMaster_Post,
} from "../ObjectCommon/ApiCommon";
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
      ListAuthor: data.ListAuthor,
      ListPublishingCompany: data.ListPublishingCompany,
      ListCategory: data.ListCategory,
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

// Handle Seach ItemMaster
export const HandleSeachItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, SeachItemMaster_Post, post);
  return data;
};

// Handle Validation ItemCode
export const HandleValidationItemCode = async (request) => {
  const data = await ItemMasterAPI(request, ValidationItemMaster_Post, post);
  return data;
};

// Handle Insert ItemMaster
export const HandleInsertItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, CreateItemMaster_Post, post);
  return data;
};

// Handle GetAll ItemMaster
export const HandleGetAllItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, GetAllItemMaster_Post, post);
  return data;
};

// Handle Seach ItemMaster For Update
export const HandleSeachItemMasterUpdate = async (request) => {
  const data = await ItemMasterAPI(request, SeachUpdateItemMaster_Post, post);
  return data;
};

// Handle Update Base ItemMaster
export const HandleUpdateBaseItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, UpdateItemMaster_Post, post);
  return data;
};

// Handle Seach ItemMaster Update Price
export const HandleSeachItemMasterUpdatePrice = async (request) => {
  const data = await ItemMasterAPI(
    request,
    SeachItemMasterUpdatePrice_Post,
    post
  );
  return data;
};

// Handle Confirm Change Price ItemMaster
export const HandleChangePriceItemMaster = async (request) => {
  const data = await ItemMasterAPI(request, ChangePriceItemMaster_Post, post);
  return data;
};
