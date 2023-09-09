import React, { useState, useEffect, useRef } from "react";
import "../Styles/CreateItemMaster.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import Table from "react-bootstrap/Table";
import Modal from "react-bootstrap/Modal";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPlus,
  faPenToSquare,
  faSquareCheck,
  faSquareCaretLeft,
  faImages,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/ItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetInitializaItemMaster,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import {
  CompanyCode,
  FistCode,
  EventInitializaItemMaster,
  EventItemMaster,
  EventSeachItemMaster,
  EventCreateItemMaster,
  UserLogin,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import LoadingModal from "../CommonPage/LoadingCommon";
import { useNavigate } from "react-router-dom";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { ItemMasterReducer } from "../ReduxCommon/ReducerCommon/ReducerItemMaster";
import moment from "moment";
import { HandleValidationItemCode } from "../ApiLablary/ItemMasterApi";
import { Create, Delete, Update } from "../Contants/DataContant";

// Function Validation Create
function ValidationItemMaster(dataValidation) {
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

  // Price Sale
  if (
    dataValidation.PriceSale === null ||
    dataValidation.PriceSale === undefined ||
    dataValidation.PriceSale === ""
  ) {
    result.Status = false;
    const error = {
      id: 3,
      messageError: "PriceSale Not Null",
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

  // PublisingCompany
  if (
    dataValidation.PublisingCompany === null ||
    dataValidation.PublisingCompany === undefined ||
    dataValidation.PublisingCompany === "0" ||
    dataValidation.PublisingCompany === 0 ||
    dataValidation.PublisingCompany === ""
  ) {
    result.Status = false;
    const error = {
      id: 11,
      messageError: "PublisingCompany Not Null",
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
function ChangeBackroundValidationSuccess() {
  document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayPriceOrigin").style.backgroundColor =
    "white";
  document.getElementById("Btn_DisplayPriceSale").style.backgroundColor =
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
  document.getElementById(
    "Btn_DisplayPublishingCompany"
  ).style.backgroundColor = "white";
  document.getElementById("Btn_DisplaySize").style.backgroundColor = "white";
  document.getElementById("Btn_ItemCode").style.backgroundColor = "white";
}

// Function Set Display Item In Form
function ChangeDispayItemForm() {
  document.getElementById("Btn_DisplayApplydate").disabled = true;
  document.getElementById("Btn_DisplayPriceOrigin").disabled = true;
  document.getElementById("Btn_DisplayPriceSale").disabled = true;
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

// Function Set An Display Item In Form
function ChangeAnDispayItemForm() {
  document.getElementById("Btn_DisplayApplydate").disabled = false;
  document.getElementById("Btn_DisplayPriceOrigin").disabled = false;
  document.getElementById("Btn_DisplayPriceSale").disabled = false;
  document.getElementById("Btn_DisplayDescription").disabled = false;
  document.getElementById("Btn_DisplayDescriptionLong").disabled = false;
  document.getElementById("Btn_DisplayDescriptionShort").disabled = false;
  document.getElementById("Btn_DisplayStore").disabled = false;
  document.getElementById("Btn_DisplayQuantity").disabled = false;
  document.getElementById("Btn_DisplayCategory").disabled = false;
  document.getElementById("Btn_DisplayAuthor").disabled = false;
  document.getElementById("Btn_DisplayPublishingCompany").disabled = false;
  document.getElementById("Btn_DisplaySize").disabled = false;
  document.getElementById("Btn_DisplayNote").disabled = false;
}

// Function Set Backround none when create itemMaster Success
function ChangeBackoundNoneCreateItemMasterSuccess() {
  document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayPriceOrigin").style.backgroundColor =
    "#e9ecef";
  document.getElementById("Btn_DisplayPriceSale").style.backgroundColor =
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
  document.getElementById(
    "Btn_DisplayPublishingCompany"
  ).style.backgroundColor = "#e9ecef";
  document.getElementById("Btn_DisplaySize").style.backgroundColor = "#e9ecef";
}

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Setting Button
  const btn_Add = useRef(null);
  const btn_Update = useRef(null);
  const btn_Confirm = useRef(null);
  const btn_Image = useRef(null);
  const Btn_DisplayApplydate = useRef(null);
  const Btn_DisplayPriceOrigin = useRef(null);
  const Btn_DisplayPriceSale = useRef(null);

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  // Get List ItemMaster Create
  const ListItemMasterMain = useSelector(
    (item) => item.itemMasterData.ListItemMaster
  );

  // Show Store Select
  const [state_ListStore, SetListSotre] = useState([]);
  const [state_DefaulStore, SetDefaulStore] = useState("0");
  // Show Author Select
  const [state_ListAuthor, SetListAuthor] = useState([]);
  // Show Publishing Companys Select
  const [state_ListPublishingCompany, SetPublishingCompany] = useState([]);
  // Show Category Select
  const [state_ListCategory, SetListCategory] = useState([]);

  // Show And Hide Dialog Add Image
  const [showDialog, setShowDialog] = useState(false);

  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);
  // Url Image
  const [state_Url, SetUrl] = useState("");
  const [state_UrlDefault, SetUrlDefault] = useState("");
  const [state_ConfirmUrlImage, SetConfirmUrlImage] = useState("");
  const [state_MessageErrorImage, SetMessageErrorImage] = useState("");

  // Create ItemMaster
  const [state_ItemCode, SetItemCode] = useState("");
  const [state_Applydate, SetApplydate] = useState("");
  const [state_PriceOrigin, SetPriceOrigin] = useState("");
  const [state_PriceSale, SetPriceSale] = useState("");
  const [state_Description, SetDescription] = useState("");
  const [state_DescriptionLong, SetDescriptionLong] = useState("");
  const [state_DescriptionShort, SetDescriptionShort] = useState("");
  const [state_Store, SetStore] = useState("");
  const [state_Quantity, SetQuantity] = useState("");
  const [state_Category, SetCategory] = useState("");
  const [state_Author, SetAuthor] = useState("");
  const [state_PublisingCompany, SetPublisingCompany] = useState("");
  const [state_Size, SetSize] = useState("");
  const [state_Note, SetNote] = useState("");

  // Control State
  const [state_Control, setControl] = useState(0);

  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventItemMaster);

      // Set Object check Token Data
      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);

      // Check User Role
      var resultCheckRole = await HandleCheckRoleStaff(formData);
      if (resultCheckRole.Status === true) {
        // var OldURL = window.localStorage.getItem("oldURL");
        alert(resultCheckRole.Message);
        // User Don't have Role
        if (OldUrldata[0] === window.location.origin) {
          // redirect to Login Pgae
          window.location.href = window.location.origin;
        } else {
          // redirect to page before
          navigate(window.localStorage.getItem("oldURL"));
        }
      } else {
        // Reomve Old  Url
        window.localStorage.removeItem("oldURL");

        // Create New Url
        dispatch(OldURLReducer.actions.DeleteURL());
        dispatch(OldURLReducer.actions.AddUrl("/createitemmaster"));
        window.localStorage.setItem("oldURL", "/createitemmaster");

        // Setting Title Page
        document.title = "Create Item Maters";

        // Initializa Item Master, get all store
        async function InitializaData() {
          // Get Token
          var token = GetCookies(UserLogin);
          // Get EventCode
          var eventCode = ConcatStringEvent(
            FistCode,
            EventInitializaItemMaster
          );

          var formData = new FormData();
          formData.append("Token", token);
          formData.append("UserID", window.localStorage.getItem("UserID"));
          formData.append(
            "RoleID",
            window.localStorage.getItem("RoleEmployer")
          );
          formData.append("EventCode", eventCode);
          formData.append("MessageError", null);
          formData.append("Status", true);
          formData.append("CompanyCode", CompanyCode);
          // Call Api Initializa Data
          const response = await HandleGetInitializaItemMaster(formData);
          if (response.Status === true) {
            // List Select
            const listStore = [];
            response.ListStore.forEach(function (item) {
              const store = {
                StoreCode: item.StoreCode,
                Description: item.Description,
                DefaultSelect: null,
              };
              listStore.push(store);
            });
            const defauleStore = {
              StoreCode: "0",
              Description: "Select Store",
            };
            listStore.push(defauleStore);
            SetListSotre(listStore);

            SetListAuthor(response.ListAuthor);
            SetPublishingCompany(response.ListPublishingCompany);
            SetListCategory(response.ListCategory);

            // Set Array Null In List ItemMaster When Initializa Data
            dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
          } else {
            SetMessageError(response.MessageError);
          }

          // disabled button
          btn_Add.current.disabled = true;
          btn_Update.current.disabled = true;
          btn_Confirm.current.disabled = true;
          btn_Image.current.disabled = true;
          // Display Item Form
          ChangeDispayItemForm();
          setControl(0);
        }
        InitializaData();
      }
    };
    CheckTokenAndRole();
  }, []);

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  // Handle Select Store
  const HandleSelectStore = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Store!");
    } else {
      SetDefaulStore(e);
      SetStore(e);
    }
    return;
  };

  // Handle Select Author
  const HandleSelectAuthor = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Author!");
    } else {
      SetAuthor(e);
    }
    return;
  };

  // Handle Select PublishingCompany
  const HandleSelectPublishingCompany = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Publishing Company!");
    } else {
      SetPublisingCompany(e);
    }
    return;
  };

  // Handle Select Category
  const HandleSelectCategory = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Category!");
    } else {
      SetCategory(e);
    }
    return;
  };

  // Handle Close Dialog Image
  const HandleCloseDialogImage = (e) => {
    if (state_Control !== 1) {
      SetUrlDefault("");
      SetUrl("");
      SetConfirmUrlImage("");
    }
    SetMessageErrorImage("");
    setShowDialog(false);
  };

  // Handle Show Dialog Add Image Item
  const HandleAddImageItem = (e) => {
    if (state_Control !== 1) {
      SetUrlDefault("");
      SetUrl("");
      SetConfirmUrlImage("");
    }
    SetMessageErrorImage("");
    setShowDialog(true);
  };

  // Handle Add New Image in List Image
  const HandleAddNewImage = (e) => {
    // Validation Url Image
    if (
      state_UrlDefault === null ||
      state_UrlDefault === undefined ||
      state_UrlDefault === "" ||
      state_Url === null ||
      state_Url === undefined ||
      state_Url === ""
    ) {
      SetMessageErrorImage("Url Image Not Null, Please Try Again!");
    } else {
      const ImageItemMaster = {
        IsDefaulr: true,
        UrlImageDefault: state_UrlDefault,
        UrlImage: state_Url,
      };
      SetConfirmUrlImage(ImageItemMaster);

      SetUrlDefault("");
      SetUrl("");
      SetMessageErrorImage("");
      SetMessageError("");
      setShowDialog(false);
    }
    return;
  };

  // Handle Click Row Item In Table
  const HandleClickRowItem = (e) => {
    SetMessageError("");
    const findItemCode = ListItemMasterMain.find((item) => item.ItemCode === e);

    if (findItemCode !== undefined) {
      // Change Backround form
      ChangeBackroundValidationSuccess();
      // An Dispay Form
      ChangeAnDispayItemForm();
      // Set Data in Form
      btn_Image.current.disabled = false;
      SetItemCode(findItemCode.ItemCode);
      SetApplydate(findItemCode.ApplyDate);
      SetPriceOrigin(findItemCode.PriceOrigin);
      SetPriceSale(findItemCode.priceSale);
      SetDescription(findItemCode.Description);
      SetDescriptionLong(findItemCode.DescriptionLong);
      SetDescriptionShort(findItemCode.DescriptionShort);
      SetQuantity(findItemCode.Quantity);
      SetSize(findItemCode.size);
      SetNote(findItemCode.Note);
      SetUrlDefault(findItemCode.UrlImage.UrlImageDefault);
      SetUrl(findItemCode.UrlImage.UrlImage);
      // Set Image Confirm when click row
      const ImageItemMaster = {
        IsDefaulr: true,
        UrlImageDefault: state_UrlDefault,
        UrlImage: state_Url,
      };
      SetConfirmUrlImage(ImageItemMaster);
      // Update State Control
      setControl(1);
      // Set Select Defaul
      SetDefaulStore(findItemCode.StoreCode);
      // An Display Button Update
      btn_Confirm.current.disabled = false;
    } else {
      SetMessageError("Not Find ItemCode, Please Try Again!");
    }
  };

  // Handle Seach ItemCode
  const HandleSeachItemCodeUI = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventSeachItemMaster);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalItemMaster", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", state_ItemCode);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListItemMaster", []);

    SetShow(true);
    // Call Api check itemMaster code
    const resultValidaion = await HandleValidationItemCode(formData);
    SetShow(false);

    if (resultValidaion.Status === true) {
      SetMessageError("");
      // Can use this itemcode
      ChangeAnDispayItemForm();
      ChangeBackroundValidationSuccess();
      btn_Image.current.disabled = false;
      btn_Add.current.disabled = false;
    } else {
      SetMessageError(resultValidaion.MessageError);
      // Don't use this itemcode
      ChangeDispayItemForm();
      btn_Image.current.disabled = true;
      btn_Add.current.disabled = true;
    }
    // Reset Select Store
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetStore("0");

    // Reset Select Category
    const categorySelect = document.getElementById("Btn_DisplayCategory");
    categorySelect.selectedIndex = [...categorySelect.options].findIndex(
      (option) => option.text === "Select Category"
    );
    SetCategory("0");

    // Reset Select Author
    const authorSelect = document.getElementById("Btn_DisplayAuthor");
    authorSelect.selectedIndex = [...authorSelect.options].findIndex(
      (option) => option.text === "Select Author"
    );
    SetAuthor("0");

    // Reset Select Author
    const publishingCompanySelect = document.getElementById(
      "Btn_DisplayPublishingCompany"
    );
    publishingCompanySelect.selectedIndex = [
      ...publishingCompanySelect.options,
    ].findIndex((option) => option.text === "Select Publishing Company");
    SetPublisingCompany("0");

    // Reset Data In Form
    SetApplydate("");
    SetPriceOrigin("");
    SetPriceSale("");
    SetDescription("");
    SetDescriptionLong("");
    SetDescriptionShort("");
    SetQuantity("");
    SetSize("");
    SetNote("");
    SetConfirmUrlImage("");

    btn_Confirm.current.disabled = true;
    setControl(0);
    SetDefaulStore("0");
  };

  // Handle Create ItemMaster
  const HandleCreateItemMaster = (e) => {
    SetMessageError("");
    const currentDate = new Date().toISOString();
    // Validation Form
    const formData = {
      ItemCode: state_ItemCode,
      Applydate: state_Applydate,
      PriceOrigin: state_PriceOrigin,
      PriceSale: state_PriceSale,
      Description: state_Description,
      DescriptionLong: state_DescriptionLong,
      DescriptionShort: state_DescriptionShort,
      Store: state_Store,
      Quantity: state_Quantity,
      Category: state_Category,
      Author: state_Author,
      PublisingCompany: state_PublisingCompany,
      Size: state_Size,
      Note: state_Note,
    };

    // Validation Data Create
    const validation = ValidationItemMaster(formData);

    // Change Backround when Validation Success
    ChangeBackroundValidationSuccess();

    // Result Validation Form Data
    if (validation.Status === false) {
      // Error
      validation.listError.forEach(function (itemError) {
        switch (itemError.id) {
          case 1:
            document.getElementById(
              "Btn_DisplayApplydate"
            ).style.backgroundColor = "yellow";
            break;
          case 2:
            document.getElementById(
              "Btn_DisplayPriceOrigin"
            ).style.backgroundColor = "yellow";
            break;
          case 3:
            document.getElementById(
              "Btn_DisplayPriceSale"
            ).style.backgroundColor = "yellow";
            break;
          case 4:
            document.getElementById(
              "Btn_DisplayDescription"
            ).style.backgroundColor = "yellow";
            break;
          case 5:
            document.getElementById(
              "Btn_DisplayDescriptionLong"
            ).style.backgroundColor = "yellow";
            break;
          case 6:
            document.getElementById(
              "Btn_DisplayDescriptionShort"
            ).style.backgroundColor = "yellow";
            break;
          case 7:
            document.getElementById("Btn_DisplayStore").style.backgroundColor =
              "yellow";
            break;
          case 8:
            document.getElementById(
              "Btn_DisplayQuantity"
            ).style.backgroundColor = "yellow";
            break;
          case 9:
            document.getElementById(
              "Btn_DisplayCategory"
            ).style.backgroundColor = "yellow";
            break;
          case 10:
            document.getElementById("Btn_DisplayAuthor").style.backgroundColor =
              "yellow";
            break;
          case 11:
            document.getElementById(
              "Btn_DisplayPublishingCompany"
            ).style.backgroundColor = "yellow";
            break;
          case 12:
            document.getElementById("Btn_DisplaySize").style.backgroundColor =
              "yellow";
            break;
          case 13:
            document.getElementById("Btn_ItemCode").style.backgroundColor =
              "yellow";
            break;
          default:
            break;
        }
      });

      // Check Applydate More than Current Date
      if (
        moment(state_Applydate).format("YYYY/MM/DD") <=
        moment(currentDate).format("YYYY/MM/DD")
      ) {
        SetApplydate("");
        document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
          "yellow";
        SetMessageError("Apply date not less current date");
      }
      setControl(1);
    } else {
      // Check UrlImage
      if (
        state_ConfirmUrlImage === null ||
        state_ConfirmUrlImage === undefined ||
        state_ConfirmUrlImage === ""
      ) {
        // Error Image Url
        SetMessageError("Url Image Not Null, Please Try Again!");
      } else {
        // Success Add ItemMaster Create In Redux
        const ItemMaster = {
          CompanyCode: CompanyCode,
          StoreCode: state_Store,
          ItemCode: state_ItemCode,
          ApplyDate: state_Applydate,
          Description: state_Description,
          DescriptionShort: state_DescriptionShort,
          DescriptionLong: state_DescriptionLong,
          PriceOrigin: state_PriceOrigin,
          PercentDiscount: 0,
          priceSale: state_PriceSale,
          QuantityDiscountID: null,
          PairDiscountID: null,
          SpecialDiscountID: null,
          Quantity: state_Quantity,
          Viewer: 0,
          Buy: 0,
          CategoryItemMasterID: state_Category,
          AuthorID: state_Author,
          DateCreate: moment(currentDate).format("YYYY-MM-DD"),
          IssuingCompanyID: null,
          PublicationDate: moment(currentDate).format("YYYY-MM-DD"),
          size: state_Size,
          PageNumber: 0,
          PublishingCompanyID: state_PublisingCompany,
          IsSale: true,
          LastUpdateDate: null,
          Note: state_Note,
          HeadquartersLastUpdateDateTime: null,
          IsDeleteFlag: false,
          UserID: window.localStorage.getItem("UserID"),
          TaxGroupCodeID: null,
          TypeOf: Create,
          OldType: null,
          UrlImage: state_ConfirmUrlImage,
        };

        // Check ItemCode In ListItemCode Reux Main
        const checkItemCode = ListItemMasterMain.find(
          (item) => item.ItemCode === ItemMaster.ItemCode
        );

        if (checkItemCode === undefined) {
          SetMessageError("");
          // Dispatch Action Add ItemMaster
          dispatch(ItemMasterReducer.actions.AddItemMaster(ItemMaster));

          // Reset Select Store
          const storeSelect = document.getElementById("Btn_DisplayStore");
          storeSelect.selectedIndex = [...storeSelect.options].findIndex(
            (option) => option.text === "Select Store"
          );
          SetStore("0");

          // Reset Select Category
          const categorySelect = document.getElementById("Btn_DisplayCategory");
          categorySelect.selectedIndex = [...categorySelect.options].findIndex(
            (option) => option.text === "Select Category"
          );
          SetCategory("0");

          // Reset Select Author
          const authorSelect = document.getElementById("Btn_DisplayAuthor");
          authorSelect.selectedIndex = [...authorSelect.options].findIndex(
            (option) => option.text === "Select Author"
          );
          SetAuthor("0");

          // Reset Select Author
          const publishingCompanySelect = document.getElementById(
            "Btn_DisplayPublishingCompany"
          );
          publishingCompanySelect.selectedIndex = [
            ...publishingCompanySelect.options,
          ].findIndex((option) => option.text === "Select Publishing Company");
          SetPublisingCompany("0");

          // Reset Data In Form
          SetItemCode("");
          SetApplydate("");
          SetPriceOrigin("");
          SetPriceSale("");
          SetDescription("");
          SetDescriptionLong("");
          SetDescriptionShort("");
          SetQuantity("");
          SetSize("");
          SetNote("");
          SetConfirmUrlImage("");

          // Change Backound none when create Success
          ChangeBackoundNoneCreateItemMasterSuccess();
          // Display Form input
          ChangeDispayItemForm();

          btn_Image.current.disabled = true;

          // Create ItemMaster Success
          btn_Confirm.current.disabled = false;

          setControl(0);
          SetDefaulStore("0");
        } else {
          SetMessageError("Exist ItemCode In System, Please Try Again!");
        }
      }
    }
    btn_Confirm.current.disabled = true;
    return;
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <Button
          type="button"
          variant="light"
          onClick={() => HandleBackMenuUI()}
        >
          <FontAwesomeIcon icon={faSquareCaretLeft} /> Back
        </Button>
        | Create Item Master
      </h3>
      <Row>
        <Col xs={3}>
          <Form.Group>
            {/* input ItemCode */}
            <p className="titleItem">
              ItemCode <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_ItemCode"
                value={state_ItemCode}
                placeholder="Enter ItemCode ..."
                onChange={(e) => SetItemCode(e.target.value)}
              />
              <Button
                variant="outline-secondary"
                onClick={(e) => HandleSeachItemCodeUI()}
              >
                Seach
              </Button>
            </InputGroup>

            {/* input Applydate */}
            <p className="titleItem">
              Apply Date <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                type="datetime-local"
                aria-describedby="basic-addon2"
                ref={Btn_DisplayApplydate}
                id="Btn_DisplayApplydate"
                onChange={(e) => SetApplydate(e.target.value)}
                value={state_Applydate}
              />
            </InputGroup>

            {/* input Price Origin */}
            <p className="titleItem">
              Price Origin <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                type="Number"
                placeholder="Enter Price Origin ..."
                aria-describedby="basic-addon2"
                ref={Btn_DisplayPriceOrigin}
                id="Btn_DisplayPriceOrigin"
                onChange={(e) => SetPriceOrigin(e.target.value)}
                value={state_PriceOrigin}
              />
            </InputGroup>

            {/* input Price Sale */}
            <p className="titleItem">
              Price Sale <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                type="Number"
                placeholder="Enter Price Sale ..."
                aria-describedby="basic-addon2"
                ref={Btn_DisplayPriceSale}
                id="Btn_DisplayPriceSale"
                onChange={(e) => SetPriceSale(e.target.value)}
                value={state_PriceSale}
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={4}>
          <Form.Group>
            {/* input Description */}
            <p className="titleItem">
              Description <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescription"
                onChange={(e) => SetDescription(e.target.value)}
                value={state_Description}
              />
            </InputGroup>
            {/* input Description Long */}
            <p className="titleItem">
              Description Long <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item Long ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescriptionLong"
                onChange={(e) => SetDescriptionLong(e.target.value)}
                value={state_DescriptionLong}
              />
            </InputGroup>
            {/* input Description Long */}
            <p className="titleItem">
              Description Short <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item Short ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescriptionShort"
                onChange={(e) => SetDescriptionShort(e.target.value)}
                value={state_DescriptionShort}
              />
            </InputGroup>
            {/* input Store */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value)}
            >
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
        </Col>
        <Col xs={3}>
          <Form.Group>
            {/* input Quantity */}
            <p className="titleItem">
              Quantity <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Quantity ..."
                aria-describedby="basic-addon2"
                type="Number"
                id="Btn_DisplayQuantity"
                onChange={(e) => SetQuantity(e.target.value)}
                value={state_Quantity}
              />
            </InputGroup>

            {/* input Category */}
            <p className="titleItem">
              Category <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectCategory(e.target.value)}
              id="Btn_DisplayCategory"
            >
              <option defaultChecked value="0">
                Select Category
              </option>
              {state_ListCategory.map((item) => (
                <option
                  key={item.CategoryItemMasterID}
                  value={item.CategoryItemMasterID}
                >
                  {item.Description}
                </option>
              ))}
            </Form.Select>

            {/* input Author */}
            <p className="titleItem">
              Author <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectAuthor(e.target.value)}
              id="Btn_DisplayAuthor"
            >
              <option defaultChecked value="0">
                Select Author
              </option>
              {state_ListAuthor.map((item) => (
                <option key={item.AuthorID} value={item.AuthorID}>
                  {item.NameAuthor}
                </option>
              ))}
            </Form.Select>

            {/* input Publishing CompanyID */}
            <p className="titleItem">
              Publishing Company <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectPublishingCompany(e.target.value)}
              id="Btn_DisplayPublishingCompany"
            >
              <option defaultChecked value="0">
                Select Publishing Company
              </option>
              {state_ListPublishingCompany.map((item) => (
                <option
                  key={item.PublishingCompanyID}
                  value={item.PublishingCompanyID}
                >
                  {item.Description}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
        </Col>
        <Col xs={2}>
          <Form.Group>
            {/* input Size */}
            <p className="titleItem">
              Size <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_DisplaySize"
                placeholder="Enter Size ..."
                aria-describedby="basic-addon2"
                onChange={(e) => SetSize(e.target.value)}
                value={state_Size}
              />
            </InputGroup>

            {/* input Note */}
            <p className="titleItem">Note</p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_DisplayNote"
                placeholder="Enter Note ..."
                as="textarea"
                style={{ height: "50px" }}
                onChange={(e) => SetNote(e.target.value)}
                value={state_Note}
              />
            </InputGroup>

            {/* input image url */}
            <p className="titleItem">Url Image</p>
            <InputGroup className="mb-3">
              <Button
                ref={btn_Image}
                variant="secondary"
                onClick={() => HandleAddImageItem()}
                style={{ width: "inherit" }}
              >
                <FontAwesomeIcon icon={faImages} />
              </Button>
            </InputGroup>
            {state_ConfirmUrlImage.IsDefaulr === true && (
              <p
                style={{
                  color: "green",
                  "text-align": "right",
                  "font-size": "20px",
                }}
              >
                <FontAwesomeIcon icon={faImages} />
              </p>
            )}
          </Form.Group>
        </Col>
      </Row>
      <p className="messageError">{state_MessageError}</p>
      <Row>
        <Col>
          <div className="customtableCreateItemMaster">
            <Table bordered hover>
              <thead>
                <tr className="headerItemMaster">
                  <th>Item Code</th>
                  <th>Apply Date</th>
                  <th>Store</th>
                  <th>Quantity</th>
                  <th>Category</th>
                  <th>Author</th>
                  <th>PriceSale</th>
                  <th>PublishingCompanyID</th>
                  <th>Description</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody>
                {ListItemMasterMain.map(
                  (item) =>
                    (item.TypeOf === Create && (
                      <tr
                        key={item.ItemCode}
                        onClick={(e) => HandleClickRowItem(item.ItemCode)}
                      >
                        <td style={{ color: "blue" }}>{item.ItemCode}</td>
                        <td style={{ color: "blue" }}>{item.ApplyDate}</td>
                        <td style={{ color: "blue" }}>{item.StoreCode}</td>
                        <td style={{ color: "blue" }}>{item.Quantity}</td>
                        <td style={{ color: "blue" }}>
                          {item.CategoryItemMasterID}
                        </td>
                        <td style={{ color: "blue" }}>{item.AuthorID}</td>
                        <td style={{ color: "blue" }}>{item.priceSale}</td>
                        <td style={{ color: "blue" }}>
                          {item.PublishingCompanyID}
                        </td>
                        <td style={{ color: "blue" }}>{item.Description}</td>
                        <td style={{ color: "blue" }}>{item.TypeOf}</td>
                      </tr>
                    )) ||
                    (item.TypeOf === Update && (
                      <tr
                        key={item.ItemCode}
                        onClick={(e) => HandleClickRowItem(item.ItemCode)}
                      >
                        <td style={{ color: "red" }}>{item.ItemCode}</td>
                        <td style={{ color: "red" }}>{item.ApplyDate}</td>
                        <td style={{ color: "red" }}>{item.StoreCode}</td>
                        <td style={{ color: "red" }}>{item.Quantity}</td>
                        <td style={{ color: "red" }}>
                          {item.CategoryItemMasterID}
                        </td>
                        <td style={{ color: "red" }}>{item.AuthorID}</td>
                        <td style={{ color: "red" }}>{item.priceSale}</td>
                        <td style={{ color: "red" }}>
                          {item.PublishingCompanyID}
                        </td>
                        <td style={{ color: "red" }}>{item.Description}</td>
                        <td style={{ color: "red" }}>{item.TypeOf}</td>
                      </tr>
                    )) ||
                    (item.TypeOf === Delete && (
                      <tr
                        key={item.ItemCode}
                        onClick={(e) => HandleClickRowItem(item.ItemCode)}
                      >
                        <td>{item.ItemCode}</td>
                        <td>{item.ApplyDate}</td>
                        <td>{item.StoreCode}</td>
                        <td>{item.Quantity}</td>
                        <td>{item.CategoryItemMasterID}</td>
                        <td>{item.AuthorID}</td>
                        <td>{item.priceSale}</td>
                        <td>{item.PublishingCompanyID}</td>
                        <td>{item.Description}</td>
                        <td>{item.TypeOf}</td>
                      </tr>
                    ))
                )}
              </tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="alinebuttonsetting">
        <Button
          variant="primary"
          className="btn_setting"
          ref={btn_Add}
          onClick={(e) => HandleCreateItemMaster()}
        >
          <FontAwesomeIcon icon={faPlus} /> Add
        </Button>
        <Button variant="warning" className="btn_setting" ref={btn_Update}>
          <FontAwesomeIcon icon={faPenToSquare} /> Update
        </Button>
        <Button variant="success" className="btn_setting" ref={btn_Confirm}>
          <FontAwesomeIcon icon={faSquareCheck} /> Confirm
        </Button>
      </p>
      {/* Show And Hide Laoding Data */}
      {state_Show && <LoadingModal />}

      {/* Dialog Add Image Item */}
      <Modal show={showDialog}>
        <Modal.Header style={{ background: "white" }}>
          <Modal.Title>Add Image ItemMaster</Modal.Title>
        </Modal.Header>
        <Modal.Body style={{ background: "white" }}>
          <p className="messageError">{state_MessageErrorImage}</p>
          <span className="itemNotNull">*</span>
          <InputGroup className="mb-3">
            <Form.Control
              value={state_UrlDefault}
              placeholder="Enter Url Image Default ..."
              type="text"
              onChange={(e) => SetUrlDefault(e.target.value)}
            />
          </InputGroup>

          <span className="itemNotNull">*</span>
          <InputGroup className="mb-3">
            <Form.Control
              value={state_Url}
              placeholder="Enter Url Image ..."
              as="textarea"
              style={{ height: "100px", "white-space": "pre" }}
              onChange={(e) => SetUrl(e.target.value)}
            />
          </InputGroup>
        </Modal.Body>
        <Modal.Footer style={{ background: "white" }}>
          <Button variant="secondary" onClick={() => HandleCloseDialogImage()}>
            Close
          </Button>
          <Button variant="primary" onClick={() => HandleAddNewImage()}>
            Save
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default CreateItemMaster;
