// Function Validation Create
export function ValidationItemMaster(dataValidation) {
  const result = {
    Status: true,
    listError: [],
  };

  // ApplyDate
  if (
    dataValidation.Applydate === null ||
    dataValidation.Applydate === undefined ||
    dataValidation.Applydate === ""
  ) {
    result.Status = false;
    const error = {
      id: 1,
      messageError: "ApplyDate Not Null",
    };
    result.listError.push(error);
  }

  // Price Origin
  if (
    dataValidation.PriceOrigin === null ||
    dataValidation.PriceOrigin === undefined ||
    dataValidation.PriceOrigin === ""
  ) {
    result.Status = false;
    const error = {
      id: 2,
      messageError: "PriceOrigin Not Null",
    };
    result.listError.push(error);
  }

  // Description
  if (
    dataValidation.Description === null ||
    dataValidation.Description === undefined ||
    dataValidation.Description === ""
  ) {
    result.Status = false;
    const error = {
      id: 4,
      messageError: "Description Not Null",
    };
    result.listError.push(error);
  }

  // Description Long
  if (
    dataValidation.DescriptionLong === null ||
    dataValidation.DescriptionLong === undefined ||
    dataValidation.DescriptionLong === ""
  ) {
    result.Status = false;
    const error = {
      id: 5,
      messageError: "DescriptionLong Not Null",
    };
    result.listError.push(error);
  }

  // Description Short
  if (
    dataValidation.DescriptionShort === null ||
    dataValidation.DescriptionShort === undefined ||
    dataValidation.DescriptionShort === ""
  ) {
    result.Status = false;
    const error = {
      id: 6,
      messageError: "DescriptionShort Not Null",
    };
    result.listError.push(error);
  }

  // Store
  if (
    dataValidation.Store === null ||
    dataValidation.Store === undefined ||
    dataValidation.Store === "0" ||
    dataValidation.Store === 0 ||
    dataValidation.Store === ""
  ) {
    result.Status = false;
    const error = {
      id: 7,
      messageError: "Store Not Null",
    };
    result.listError.push(error);
  }

  // Quantity
  if (
    dataValidation.Quantity === null ||
    dataValidation.Quantity === undefined ||
    dataValidation.Quantity === ""
  ) {
    result.Status = false;
    const error = {
      id: 8,
      messageError: "Quantity Not Null",
    };
    result.listError.push(error);
  }

  // Category
  if (
    dataValidation.Category === null ||
    dataValidation.Category === undefined ||
    dataValidation.Category === "0" ||
    dataValidation.Category === 0 ||
    dataValidation.Category === ""
  ) {
    result.Status = false;
    const error = {
      id: 9,
      messageError: "Category Not Null",
    };
    result.listError.push(error);
  }

  // Author
  if (
    dataValidation.Author === null ||
    dataValidation.Author === undefined ||
    dataValidation.Author === "0" ||
    dataValidation.Author === 0 ||
    dataValidation.Author === ""
  ) {
    result.Status = false;
    const error = {
      id: 10,
      messageError: "Author Not Null",
    };
    result.listError.push(error);
  }

  // Size
  if (
    dataValidation.Size === null ||
    dataValidation.Size === undefined ||
    dataValidation.Size === ""
  ) {
    result.Status = false;
    const error = {
      id: 12,
      messageError: "Size Not Null",
    };
    result.listError.push(error);
  }

  // ItemCode
  if (
    dataValidation.ItemCode === null ||
    dataValidation.ItemCode === undefined ||
    dataValidation.ItemCode === ""
  ) {
    result.Status = false;
    const error = {
      id: 13,
      messageError: "ItemCode Not Null",
    };
    result.listError.push(error);
  }

  return result;
}

// Function Set Backround Validation Success
export function ChangeBackroundValidationSuccess() {
  document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayPriceOrigin").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayDescription").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayDescriptionLong").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayDescriptionShort").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayStore").style.backgroundColor = "white";
  document.getElementById("Btn_DisplayQuantity").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayCategory").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayAuthor").style.backgroundColor = "white";
  document.getElementById("Btn_DisplaySize").style.backgroundColor = "white";
  document.getElementById("Btn_ItemCode").style.backgroundColor = "white";
}

// Function Set Display Item In Form
export function ChangeDispayItemForm() {
  document.getElementById("Btn_DisplayApplydate").disabled = true;
  document.getElementById("Btn_DisplayPriceOrigin").disabled = true;
  document.getElementById("Btn_DisplayDescription").disabled = true;
  document.getElementById("Btn_DisplayDescriptionLong").disabled = true;
  document.getElementById("Btn_DisplayDescriptionShort").disabled = true;
  document.getElementById("Btn_DisplayStore").disabled = true;
  document.getElementById("Btn_DisplayQuantity").disabled = true;
  document.getElementById("Btn_DisplayCategory").disabled = true;
  document.getElementById("Btn_DisplayAuthor").disabled = true;
  document.getElementById("Btn_DisplaySize").disabled = true;
  document.getElementById("Btn_DisplayNote").disabled = true;
}

// Function Set An Display Item In Form
export function ChangeAnDispayItemForm() {
  document.getElementById("Btn_DisplayApplydate").disabled = false;
  document.getElementById("Btn_DisplayPriceOrigin").disabled = false;
  document.getElementById("Btn_DisplayDescription").disabled = false;
  document.getElementById("Btn_DisplayDescriptionLong").disabled = false;
  document.getElementById("Btn_DisplayDescriptionShort").disabled = false;
  document.getElementById("Btn_DisplayStore").disabled = false;
  document.getElementById("Btn_DisplayQuantity").disabled = false;
  document.getElementById("Btn_DisplayCategory").disabled = false;
  document.getElementById("Btn_DisplayAuthor").disabled = false;
  document.getElementById("Btn_DisplaySize").disabled = false;
  document.getElementById("Btn_DisplayNote").disabled = false;
}

// Function Set Backround none when create itemMaster Success
export function ChangeBackoundNoneCreateItemMasterSuccess() {
  document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayPriceOrigin").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayDescription").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayDescriptionLong").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayDescriptionShort").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayStore").style.backgroundColor = "#e9ecef";
  document.getElementById("Btn_DisplayQuantity").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayCategory").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayAuthor").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplaySize").style.backgroundColor = "#e9ecef";
}

// Function Set Data Select when Initializa
export function InitializaDataSelect(LISTSTORE, LISTAUTHOR, LISTCATEGORY) {
  const result = {
    listStore: [],
    listAuthor: [],
    listCategory: [],
  };
  // List Select Store
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

  // List Select Author
  LISTAUTHOR.forEach(function (item) {
    const author = {
      AuthorID: item.AuthorID,
      NameAuthor: item.NameAuthor,
    };
    result.listAuthor.push(author);
  });
  const defauleAuthor = {
    AuthorID: "0",
    NameAuthor: "Select Author",
  };
  result.listAuthor.push(defauleAuthor);

  // List Select Category
  LISTCATEGORY.forEach(function (item) {
    const category = {
      CategoryItemMasterID: item.CategoryItemMasterID,
      Description: item.Description,
    };
    result.listCategory.push(category);
  });
  const defaulCategory = {
    CategoryItemMasterID: "0",
    Description: "Select Category",
  };
  result.listCategory.push(defaulCategory);

  return result;
}

// Function Validation Content ItemMaster Input
export function ValidationContentInputItemMaster(requestData) {
  const resultItem = {
    Status: true,
    MessageError: null,
    ContantError: 0,
  };
  // Validation Lenght ItemCode
  if (requestData.ItemCode.length >= 26) {
    resultItem.Status = false;
    resultItem.MessageError =
      "Length of itemCode must small than 26 characters";
    resultItem.ContantError = 1;
  } else if (requestData.Description >= 50) {
    resultItem.Status = false;
    resultItem.MessageError =
      "Lenght of description must small than 50 characters";
    resultItem.ContantError = 2;
  } else if (requestData.DescriptionShort >= 25) {
    resultItem.Status = false;
    resultItem.MessageError =
      "Lenght of descriptionShort must small than 25 characters";
    resultItem.ContantError = 3;
  } else if (requestData.DescriptionLong >= 100) {
    resultItem.Status = false;
    resultItem.MessageError =
      "Lenght of descriptionLong must small than 100 characters";
    resultItem.ContantError = 4;
  } else if (requestData.size >= 100) {
    resultItem.Status = false;
    resultItem.MessageError = "Lenght of size must small than 100 characters";
    resultItem.ContantError = 5;
  } else {
    resultItem.Status = true;
    resultItem.MessageError = null;
    resultItem.ContantError = 0;
  }
  return resultItem;
}
