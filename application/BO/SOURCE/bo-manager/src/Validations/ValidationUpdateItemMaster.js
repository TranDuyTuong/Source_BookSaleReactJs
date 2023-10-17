// Function Set Display Item In Form
export function DispayItemForm(status) {
  // status is 1 => AnDisplay selector
  if (status === 1) {
    document.getElementById("Btn_DisplayDescription").disabled = false;
    document.getElementById("Btn_DisplayDescriptionLong").disabled = false;
    document.getElementById("Btn_DisplayDescriptionShort").disabled = false;
    document.getElementById("Btn_DisplayQuantity").disabled = false;
    document.getElementById("Btn_DisplayCategory").disabled = false;
    document.getElementById("Btn_DisplayAuthor").disabled = false;
    document.getElementById("Btn_DisplaySize").disabled = false;
    document.getElementById("Btn_DisplayNote").disabled = false;
  }
  // status is 0 => Display selector
  if (status === 0) {
    document.getElementById("Btn_DisplayDescription").disabled = true;
    document.getElementById("Btn_DisplayDescriptionLong").disabled = true;
    document.getElementById("Btn_DisplayDescriptionShort").disabled = true;
    document.getElementById("Btn_DisplayQuantity").disabled = true;
    document.getElementById("Btn_DisplayCategory").disabled = true;
    document.getElementById("Btn_DisplayAuthor").disabled = true;
    document.getElementById("Btn_DisplaySize").disabled = true;
    document.getElementById("Btn_DisplayNote").disabled = true;
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    const authorSelect = document.getElementById("Btn_DisplayAuthor");
    authorSelect.selectedIndex = [...authorSelect.options].findIndex(
      (option) => option.text === "Select Author"
    );
    const categorySelect = document.getElementById("Btn_DisplayCategory");
    categorySelect.selectedIndex = [...categorySelect.options].findIndex(
      (option) => option.text === "Select Category"
    );
  }
}

// Function Set Data Select when Initializa
export function InitializaDataSelect(LISTSTORE, LISTAUTHOR, LISTCATEGORY) {
  const result = {
    listStore: [],
    listAuthor: [],
    listCategory: [],
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

  // List Select Author
  if (LISTAUTHOR !== undefined) {
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
  }

  // List Select Category
  if (LISTCATEGORY !== undefined) {
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
