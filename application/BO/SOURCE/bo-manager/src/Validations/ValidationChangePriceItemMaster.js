// Function Set Display Item In Form
export function DispayItemForm(status) {
  // status is 1 => AnDisplay selector
  if (status === 1) {
    document.getElementById("Txt_Applydate").disabled = false;
    document.getElementById("Txt_CornerPrice").disabled = false;
    document.getElementById("Txt_PriceSale").disabled = false;
    document.getElementById("Txt_PercentDiscount").disabled = false;
    document.getElementById("Txt_Description").disabled = false;
    document.getElementById("Btn_Update").disabled = false;
    document.getElementById("Btn_Cancel").disabled = false;
  }
  // status is 0 => Display selector
  if (status === 0) {
    document.getElementById("Txt_Applydate").disabled = true;
    document.getElementById("Txt_CornerPrice").disabled = true;
    document.getElementById("Txt_PriceSale").disabled = true;
    document.getElementById("Txt_PercentDiscount").disabled = true;
    document.getElementById("Txt_Description").disabled = true;
    document.getElementById("Btn_Update").disabled = true;
    document.getElementById("Btn_Cancel").disabled = true;
  }
}

// Function Set Data Select when Initializa
export function InitializaDataSelect(LISTSTORE) {
  const result = {
    listStore: [],
  };
  // List Select Store
  if (LISTSTORE !== undefined || LISTSTORE !== null) {
    LISTSTORE.forEach(function (item) {
      const store = {
        StoreCode: item.StoreCode,
        Description: item.Description,
      };
      result.listStore.push(store);
    });
    const defauleStore = {
      StoreCode: "0",
      Description: "Select Store",
    };
    result.listStore.push(defauleStore);
  }

  return result;
}

// Function Validation Null ItemMaster Update
export function ValidationItemMasterUpdate(dataVali) {
  const result = {
    Status: true,
    IdElement: null,
    MessageError: null,
  };

  if (
    dataVali.Description === null ||
    dataVali.Description === undefined ||
    dataVali.Description === ""
  ) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescription";
    result.MessageError = "Description Not Null !";
  }

  if (
    dataVali.DescriptionLong === null ||
    dataVali.DescriptionLong === undefined ||
    dataVali.DescriptionLong === ""
  ) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescriptionLong";
    result.MessageError = "DescriptionLong Not Null !";
  }

  if (
    dataVali.DescriptionShort === null ||
    dataVali.DescriptionShort === undefined ||
    dataVali.DescriptionShort === ""
  ) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescriptionShort";
    result.MessageError = "DescriptionShort Not Null !";
  }

  if (
    dataVali.Quantity === null ||
    dataVali.Quantity === undefined ||
    dataVali.Quantity === ""
  ) {
    result.Status = false;
    result.IdElement = "Btn_DisplayQuantity";
    result.MessageError = "Quantity Not Null !";
  }

  if (
    dataVali.size === null ||
    dataVali.size === undefined ||
    dataVali.size === ""
  ) {
    result.Status = false;
    result.IdElement = "Btn_DisplaySize";
    result.MessageError = "Size Not Null !";
  }

  if (dataVali.StoreCode === "0") {
    result.Status = false;
    result.IdElement = "Btn_DisplayStore";
    result.MessageError = "StoreCode Not Null !";
  }

  if (dataVali.AuthorID === "0") {
    result.Status = false;
    result.IdElement = "Btn_DisplayAuthor";
    result.MessageError = "AuthorID Not Null !";
  }

  if (dataVali.CategoryItemMasterID === "0") {
    result.Status = false;
    result.IdElement = "Btn_DisplayCategory";
    result.MessageError = "CategoryItemMasterID Not Null !";
  }

  if (dataVali.PublishingCompanyID === "0") {
    result.Status = false;
    result.IdElement = "Btn_DisplayPublishingCompany";
    result.MessageError = "PublishingCompanyID Not Null !";
  }
  return result;
}

// Function Validation Character ItemMaster Update
export function ValidationCharacterItemMasterUpdate(dataVali) {
  const result = {
    Status: true,
    IdElement: null,
    MessageError: null,
  };

  if (dataVali.Description.length > 50) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescription";
    result.MessageError = "Content Description must small than 50 !";
  }

  if (dataVali.DescriptionLong.length > 100) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescriptionLong";
    result.MessageError = "Content DescriptionLong must small than 100 !";
  }

  if (dataVali.DescriptionShort.length > 25) {
    result.Status = false;
    result.IdElement = "Btn_DisplayDescriptionShort";
    result.MessageError = "Content DescriptionShort must small than 25 !";
  }

  if (dataVali.size.length > 100) {
    result.Status = false;
    result.IdElement = "Btn_DisplaySize";
    result.MessageError = "Content Size must small than 100 !";
  }

  return result;
}

export const ValidationPriceIsNull = (e) => {
  const result = {
    status: false,
    messageError: null,
  };

  if (e === "" || e === null || e === undefined) {
    result.status = false;
    result.messageError = "Price Is Not Null, Please Check Again!";
  } else {
    result.status = true;
  }

  return result;
};

export const HandleUpdateOrCreateChangePrice = (request, listItemMaster) => {
  const result = {
    status: false,
    messageError: null,
    output: null,
  };

  const findItemMaster = listItemMaster.find(
    (item) =>
      item.ItemCode === request.itemCode &&
      item.ApplyDate === request.applydate &&
      item.StoreCode === request.storecode
  );

  if (findItemMaster === undefined) {
    request.id = guildv4();
    result.status = true;
    result.output = request;
    result.messageError = null;
  } else {
    request.id = guildv4();
    result.status = true;
    result.messageError = null;
    result.output = request;
  }
  return result;
};

const guildv4 = (e) => {
  return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
    const r = (Math.random() * 16) | 0,
      v = c === "x" ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
};
