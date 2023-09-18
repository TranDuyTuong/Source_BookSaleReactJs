// Function Set Display Item In Form
export function DispayItemForm() {
  document.getElementById("Btn_DisplayDescription").disabled = true;
  document.getElementById("Btn_DisplayDescriptionLong").disabled = true;
  document.getElementById("Btn_DisplayDescriptionShort").disabled = true;
  document.getElementById("Btn_DisplayStore").disabled = true;
  document.getElementById("Btn_DisplayQuantity").disabled = true;
  document.getElementById("Btn_DisplayCategory").disabled = true;
  document.getElementById("Btn_DisplayPublishingCompany").disabled = true;
  document.getElementById("Btn_DisplayAuthor").disabled = true;
  document.getElementById("Btn_DisplaySize").disabled = true;
  document.getElementById("Btn_DisplayNote").disabled = true;
}

// Function Set Data Select when Initializa
export function InitializaDataSelect(
  LISTSTORE,
  LISTAUTHOR,
  LISTCATEGORY,
  LISTPUBLISHINGCOMPANY
) {
  const result = {
    listStore: [],
    listAuthor: [],
    listPublishingCompany: [],
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

  // List Select PublishingCompany
  LISTPUBLISHINGCOMPANY.forEach(function (item) {
    const publishingCompany = {
      PublishingCompanyID: item.PublishingCompanyID,
      Description: item.Description,
    };
    result.listPublishingCompany.push(publishingCompany);
  });
  const defaulePublishingCompany = {
    PublishingCompanyID: "0",
    Description: "Select PublishingCompany",
  };
  result.listPublishingCompany.push(defaulePublishingCompany);

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
