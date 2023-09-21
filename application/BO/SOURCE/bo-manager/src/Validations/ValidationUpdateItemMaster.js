// Function Set Display Item In Form
export function DispayItemForm(status) {
  // status is 1 => AnDisplay selector
  if (status === 1) {
    document.getElementById("Btn_DisplayDescription").disabled = false;
    document.getElementById("Btn_DisplayDescriptionLong").disabled = false;
    document.getElementById("Btn_DisplayDescriptionShort").disabled = false;
    document.getElementById("Btn_DisplayQuantity").disabled = false;
    document.getElementById("Btn_DisplayCategory").disabled = false;
    document.getElementById("Btn_DisplayPublishingCompany").disabled = false;
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
    document.getElementById("Btn_DisplayPublishingCompany").disabled = true;
    document.getElementById("Btn_DisplayAuthor").disabled = true;
    document.getElementById("Btn_DisplaySize").disabled = true;
    document.getElementById("Btn_DisplayNote").disabled = true;
  }
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

  // List Select PublishingCompany
  if (LISTPUBLISHINGCOMPANY !== undefined) {
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
