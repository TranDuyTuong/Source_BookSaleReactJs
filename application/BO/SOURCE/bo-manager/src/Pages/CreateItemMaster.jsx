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
  faRotate,
  faTrash,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/CreateItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetInitializaItemMaster,
  HandleCheckRoleStaff,
  CurrencyInputMoney,
  HandleCalculateDiscountPercentage,
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
import {
  HandleValidationItemCode,
  HandleInsertItemMaster,
} from "../ApiLablary/ItemMasterApi";
import {
  Create,
  Delete,
  Update,
  Revert,
  Create_ItemMaster,
} from "../Contants/DataContant";
import {
  ValidationItemMaster,
  ChangeBackroundValidationSuccess,
  ChangeDispayItemForm,
  ChangeAnDispayItemForm,
  ChangeBackoundNoneCreateItemMasterSuccess,
  InitializaDataSelect,
  ValidationContentInputItemMaster,
} from "../Validations/ValidationCreateItemMaster";

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Setting Button
  const btn_Add = useRef(null);
  const btn_Update = useRef(null);
  const btn_Image = useRef(null);
  const Btn_DisplayApplydate = useRef(null);
  const Btn_DisplayPriceOrigin = useRef(null);

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
  const [state_DefaulAuthor, SetDefaultAuthor] = useState("0");

  // Show Category Select
  const [state_ListCategory, SetListCategory] = useState([]);
  const [state_DefaultCategory, SetDefaultCategory] = useState("0");

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
  const [state_Description, SetDescription] = useState("");
  const [state_DescriptionLong, SetDescriptionLong] = useState("");
  const [state_DescriptionShort, SetDescriptionShort] = useState("");
  const [state_Quantity, SetQuantity] = useState("");
  const [state_Size, SetSize] = useState("");
  const [state_Note, SetNote] = useState("");

  const [state_KindButton, SetKindButton] = useState("");

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
            const initializaDataSelect = InitializaDataSelect(
              response.ListStore,
              response.ListAuthor,
              response.ListCategory
            );
            // List Select Store
            SetListSotre(initializaDataSelect.listStore);
            // List Select Author
            SetListAuthor(initializaDataSelect.listAuthor);
            // List Select Category
            SetListCategory(initializaDataSelect.listCategory);
            // Set Array Null In List ItemMaster When Initializa Data
            dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
            // Focus inputItemCode
            document.getElementById("Btn_ItemCode").focus();
          } else {
            SetMessageError(response.MessageError);
          }

          // disabled button
          btn_Add.current.disabled = true;
          btn_Update.current.disabled = true;
          btn_Image.current.disabled = true;
          // Display Item Form
          ChangeDispayItemForm();
          // Reset Form
          ResetForm();
        }
        InitializaData();
      }
    };
    CheckTokenAndRole();
  }, []);
  //---------------------------------------------------------------------------
  // COMMON FUNCTION
  // Handle Common Form
  function ResetForm() {
    // Reset Select Store
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");

    // Reset Select Category
    const categorySelect = document.getElementById("Btn_DisplayCategory");
    categorySelect.selectedIndex = [...categorySelect.options].findIndex(
      (option) => option.text === "Select Category"
    );
    SetDefaultCategory("0");

    // Reset Select Author
    const authorSelect = document.getElementById("Btn_DisplayAuthor");
    authorSelect.selectedIndex = [...authorSelect.options].findIndex(
      (option) => option.text === "Select Author"
    );
    SetDefaultAuthor("0");

    SetApplydate("");
    SetPriceOrigin("");
    SetDescription("");
    SetDescriptionLong("");
    SetDescriptionShort("");
    SetQuantity("");
    SetSize("");
    SetNote("");
    SetConfirmUrlImage("");
    setControl(0);
    SetKindButton("");
  }

  // Handle Common Validation Applydate And Url Image
  function ValidationApplydate(applydate, currentdate) {
    const resultAplydate = {
      Status: true,
    };
    if (applydate <= currentdate) {
      // Update UI
      SetApplydate("");
      document.getElementById("Btn_DisplayApplydate").style.backgroundColor =
        "yellow";
      SetMessageError("Apply date not less current date");
      // Result Error
      resultAplydate.Status = false;
    }
    setControl(1);
    return resultAplydate;
  }

  // Handle Common Validation Url Cofirm Image
  function ValidationUrlImage() {
    const resultUrlImage = {
      Status: true,
    };
    if (
      state_ConfirmUrlImage === null ||
      state_ConfirmUrlImage === undefined ||
      state_ConfirmUrlImage === ""
    ) {
      // Error Message UI
      SetMessageError("Url Image Not Null, Please Try Again!");
      resultUrlImage.Status = false;
    }
    return resultUrlImage;
  }

  // Handle Common Contant ItemMaster
  function ContantItemMaster(typeHandle, price) {
    const currentDate = new Date().toISOString();
    const contatnResult = {
      CompanyCode: CompanyCode,
      StoreCode: state_DefaulStore,
      ItemCode: state_ItemCode,
      ApplyDate: state_Applydate,
      Description: state_Description,
      DescriptionShort: state_DescriptionShort,
      DescriptionLong: state_DescriptionLong,
      PriceOrigin: price,
      PercentDiscount: 0,
      QuantityDiscountID: null,
      PairDiscountID: null,
      SpecialDiscountID: null,
      Quantity: state_Quantity,
      Viewer: 0,
      Buy: 0,
      CategoryItemMasterID: state_DefaultCategory,
      AuthorID: state_DefaulAuthor,
      DateCreate: moment(currentDate).format("YYYY-MM-DD"),
      size: state_Size,
      IsSale: true,
      LastUpdateDate: null,
      Note: state_Note,
      HeadquartersLastUpdateDateTime: null,
      IsDeleteFlag: false,
      UserID: window.localStorage.getItem("UserID"),
      TaxGroupCodeID: null,
      TypeOf: typeHandle,
      OldType: null,
      UrlImage: state_ConfirmUrlImage,
    };
    return contatnResult;
  }

  //---------------------------------------------------------------------------
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
    }
    return;
  };

  // Handle Select Author
  const HandleSelectAuthor = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Author!");
    } else {
      SetDefaultAuthor(e);
    }
    return;
  };

  // Handle Select Category
  const HandleSelectCategory = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Category!");
    } else {
      SetDefaultCategory(e);
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
      if (state_Control !== 1) {
        const ImageItemMaster = {
          IsDefault: true,
          UrlImageDefault: state_UrlDefault,
          UrlImage: state_Url,
        };
        SetConfirmUrlImage(ImageItemMaster);

        SetUrlDefault("");
        SetUrl("");
      } else {
        const ImageItemMaster = {
          IsDefault: true,
          UrlImageDefault: state_UrlDefault,
          UrlImage: state_Url,
        };
        SetConfirmUrlImage(ImageItemMaster);
      }
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
        IsDefault: true,
        UrlImageDefault: findItemCode.UrlImage.UrlImageDefault,
        UrlImage: findItemCode.UrlImage.UrlImage,
      };
      SetConfirmUrlImage(ImageItemMaster);
      // Update State Control
      setControl(1);
      // Set Select Defaul
      SetDefaulStore(findItemCode.StoreCode);
      SetDefaultAuthor(findItemCode.AuthorID);
      SetDefaultCategory(findItemCode.CategoryItemMasterID);
      // An Display Button Update
      btn_Update.current.disabled = false;
      // Set Kind Button Setting Delete Or Revert
      if (findItemCode.TypeOf === Delete) {
        SetKindButton(Revert);
      }
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
    // Reset Data In Form
    ResetForm();
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
      Description: state_Description,
      DescriptionLong: state_DescriptionLong,
      DescriptionShort: state_DescriptionShort,
      Store: state_DefaulStore,
      Quantity: state_Quantity,
      Category: state_DefaultCategory,
      Author: state_DefaulAuthor,
      Size: state_Size,
      Note: state_Note,
    };

    // Check Validation Null Data Create
    const validation = ValidationItemMaster(formData);
    // Check Validation Content Data Create
    const validationContent = ValidationContentInputItemMaster(formData);
    // Check Url Image Confirm
    const urlImageConfirm = ValidationUrlImage();
    // Check Applydate More than Current Date
    const validationApplydate = ValidationApplydate(
      moment(state_Applydate).format("YYYY/MM/DD"),
      moment(currentDate).format("YYYY/MM/DD")
    );

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
    }

    // Result Validation Content Form Data
    if (validationContent.Status === false) {
      // Error
      switch (validationContent.ContantError) {
        case 1:
          document.getElementById("Btn_ItemCode").style.backgroundColor =
            "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 2:
          document.getElementById(
            "Btn_DisplayDescription"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 3:
          document.getElementById(
            "Btn_DisplayDescriptionShort"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 4:
          document.getElementById(
            "Btn_DisplayDescriptionLong"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        default:
          document.getElementById("Btn_DisplaySize").style.backgroundColor =
            "yellow";
          SetMessageError(validationContent.MessageError);
          break;
      }
      setControl(1);
    }

    // Validation Successs
    if (
      validationContent.Status === true &&
      validation.Status === true &&
      validationApplydate.Status === true &&
      urlImageConfirm.Status === true
    ) {
      // Conver price original
      const price = HandleCalculateDiscountPercentage(state_PriceOrigin, 0);

      // Success Add ItemMaster Create In Redux
      const ItemMaster = ContantItemMaster(Create, price.priceOrigin);

      // Check ItemCode In ListItemCode Reux Main
      const checkItemCode = ListItemMasterMain.find(
        (item) => item.ItemCode === ItemMaster.ItemCode
      );

      if (checkItemCode === undefined) {
        SetMessageError("");
        // Dispatch Action Add ItemMaster
        dispatch(ItemMasterReducer.actions.AddItemMaster(ItemMaster));
        // Reset Data In Form
        ResetForm();
        // Change Backound none when create Success
        ChangeBackoundNoneCreateItemMasterSuccess();
        // Display Form input
        ChangeDispayItemForm();
        btn_Image.current.disabled = true;
        // Reset Input ItemCode
        SetItemCode("");
      } else {
        SetMessageError("Exist ItemCode In System, Please Try Again!");
      }
    }
    return;
  };

  // Handle Update ItemMaster
  const HandleUpdateItemMaster = (e) => {
    SetMessageError("");
    const currentDate = new Date().toISOString();
    // Validation Form
    const formData = {
      ItemCode: state_ItemCode,
      Applydate: state_Applydate,
      PriceOrigin: state_PriceOrigin,
      Description: state_Description,
      DescriptionLong: state_DescriptionLong,
      DescriptionShort: state_DescriptionShort,
      Store: state_DefaulStore,
      Quantity: state_Quantity,
      Category: state_DefaultCategory,
      Author: state_DefaulAuthor,
      Size: state_Size,
      Note: state_Note,
    };
    // Check Validation Null Data Create
    const validation = ValidationItemMaster(formData);
    // Check Validation Content Data Create
    const validationContent = ValidationContentInputItemMaster(formData);
    // Check Url Image Confirm
    const urlImageConfirm = ValidationUrlImage();
    // Check Applydate More than Current Date
    const validationApplydate = ValidationApplydate(
      moment(state_Applydate).format("YYYY/MM/DD"),
      moment(currentDate).format("YYYY/MM/DD")
    );

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
    }
    // Result Validation Content Form Data
    if (validationContent.Status === false) {
      // Error
      switch (validationContent.ContantError) {
        case 1:
          document.getElementById("Btn_ItemCode").style.backgroundColor =
            "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 2:
          document.getElementById(
            "Btn_DisplayDescription"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 3:
          document.getElementById(
            "Btn_DisplayDescriptionShort"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        case 4:
          document.getElementById(
            "Btn_DisplayDescriptionLong"
          ).style.backgroundColor = "yellow";
          SetMessageError(validationContent.MessageError);
          break;
        default:
          document.getElementById("Btn_DisplaySize").style.backgroundColor =
            "yellow";
          SetMessageError(validationContent.MessageError);
          break;
      }
      setControl(1);
    }

    if (
      validationContent.Status === true &&
      validation.Status === true &&
      validationApplydate.Status === true &&
      urlImageConfirm.Status === true
    ) {
      // Conver price original
      const price = HandleCalculateDiscountPercentage(state_PriceOrigin, 0);
      // Success Add ItemMaster Create In Redux
      const ItemMaster = ContantItemMaster(Update, price.priceOrigin);

      // Check ItemCode In ListItemCode Reux Main
      const checkItemCode = ListItemMasterMain.find(
        (item) => item.ItemCode === ItemMaster.ItemCode
      );

      if (checkItemCode !== undefined) {
        SetMessageError("");
        // Dispatch Action Add ItemMaster
        dispatch(ItemMasterReducer.actions.UpdateItemMaster(ItemMaster));
        // Reset Data In Form
        ResetForm();
        // Change Backound none when create Success
        ChangeBackoundNoneCreateItemMasterSuccess();
        // Display Form input
        ChangeDispayItemForm();
        btn_Image.current.disabled = true;
        btn_Update.current.disabled = true;
        // Reset ItemCode
        SetItemCode("");
      } else {
        SetMessageError("Not Find ItemCode In System, Please Try Again!");
      }
    }
    return;
  };

  // Handle Delete ItemMaster
  const HandleDeleteItemMaster = (e) => {
    SetMessageError("");
    // Check ItemCode In ListItemCode Reux Main
    const checkItemCode = ListItemMasterMain.find(
      (item) => item.ItemCode === state_ItemCode
    );

    if (checkItemCode !== undefined) {
      // Check ItemMaster was Delete ?
      if (checkItemCode.TypeOf === Delete) {
        SetMessageError("This ItemCode Were Delete, Cannot Delete");
      } else {
        const ItemMaster = {
          ItemCode: checkItemCode.ItemCode,
          TypeOf: Delete,
          OldType: checkItemCode.TypeOf,
        };
        SetMessageError("");
        // Dispatch Action Delete ItemMaster
        dispatch(ItemMasterReducer.actions.DeleteItemMaster(ItemMaster));
        // Reset Data In Form
        ResetForm();
        // Change Backound none when create Success
        ChangeBackoundNoneCreateItemMasterSuccess();
        // Display Form input
        ChangeDispayItemForm();
        btn_Image.current.disabled = true;
        btn_Update.current.disabled = true;
        // Reset ItemCode input
        SetItemCode("");
      }
    } else {
      SetMessageError("Please Choose a ItemCode Want Delete!");
    }
    return;
  };

  // Handle Revert ItemMaster
  const HandleRevertItemMaster = (e) => {
    SetMessageError("");
    // Check ItemCode In ListItemCode Reux Main
    const checkItemCode = ListItemMasterMain.find(
      (item) => item.ItemCode === state_ItemCode
    );

    if (checkItemCode !== undefined) {
      const ItemMaster = {
        ItemCode: checkItemCode.ItemCode,
        TypeOf: checkItemCode.OldType,
        OldType: null,
      };
      SetMessageError("");
      // Dispatch Action Revert ItemMaster
      dispatch(ItemMasterReducer.actions.RevertItemMaster(ItemMaster));
      // Reset Data In Form
      ResetForm();
      // Change Backound none when create Success
      ChangeBackoundNoneCreateItemMasterSuccess();
      // Display Form input
      ChangeDispayItemForm();
      btn_Image.current.disabled = true;
      btn_Update.current.disabled = true;
      // Reset ItemCode Input
      SetItemCode("");
    } else {
      SetMessageError("Not Find ItemCode In System, Please Try Again!");
    }
    return;
  };

  // Handle Confirm ItemMaster
  const HandleConfirmItemMaster = async (e) => {
    // Handle Get All ItemMaster Create in Redux
    const listItemMasterConfirm = [];
    ListItemMasterMain.forEach(function (item) {
      if (item.TypeOf !== Delete) {
        const insertItem = {
          CompanyCode: item.CompanyCode,
          StoreCode: item.StoreCode,
          ItemCode: item.ItemCode,
          ApplyDate: item.ApplyDate,
          Description: item.Description,
          DescriptionShort: item.DescriptionShort,
          DescriptionLong: item.DescriptionLong,
          PriceOrigin: item.PriceOrigin,
          QuantityDiscountID: item.QuantityDiscountID,
          PairDiscountID: item.PairDiscountID,
          SpecialDiscountID: item.SpecialDiscountID,
          Quantity: item.Quantity,
          Viewer: item.Viewer,
          Buy: item.Buy,
          CategoryItemMasterID: item.CategoryItemMasterID,
          AuthorID: item.AuthorID,
          DateCreate: item.DateCreate,
          size: item.size,
          IsSale: item.IsSale,
          LastUpdateDate: item.LastUpdateDate,
          Note: item.Note,
          HeadquartersLastUpdateDateTime: item.HeadquartersLastUpdateDateTime,
          IsDeleteFlag: item.IsDeleteFlag,
          UserID: item.UserID,
          TaxGroupCodeID: item.TaxGroupCodeID,
          TypeOf: item.TypeOf,
          OldType: item.OldType,
          ImageItemMaster: item.UrlImage,
        };
        listItemMasterConfirm.push(insertItem);
      }
    });

    // Conver Array to Json
    var jsonItemMasterInsert = JSON.stringify(listItemMasterConfirm);
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventCreateItemMaster);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalItemMaster", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", jsonItemMasterInsert);
    formData.append("CompanyCode", CompanyCode);
    formData.append("OTPControl", Create_ItemMaster);
    formData.append("ListItemMaster", []);

    // Call Api Confirm Insert ItemMaster
    const resultData = await HandleInsertItemMaster(formData);

    if (resultData.Status === true) {
      // Success
      alert("Create ItemMaster Success!");
      window.location.reload();
    } else {
      // Error
      SetMessageError(resultData.MessageError);
    }
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
              <CurrencyInputMoney
                ref={Btn_DisplayPriceOrigin}
                value={state_PriceOrigin}
                onChange={(e) => SetPriceOrigin(e.target.value)}
                id="Btn_DisplayPriceOrigin"
                placeholder="0 VND"
                type="text"
                className="inputPrice"
              />
            </InputGroup>

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
              value={state_DefaultCategory}
              onChange={(e) => HandleSelectCategory(e.target.value)}
              id="Btn_DisplayCategory"
            >
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
              value={state_DefaulAuthor}
              onChange={(e) => HandleSelectAuthor(e.target.value)}
              id="Btn_DisplayAuthor"
            >
              {state_ListAuthor.map((item) => (
                <option key={item.AuthorID} value={item.AuthorID}>
                  {item.NameAuthor}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
        </Col>
        <Col xs={2}>
          <Form.Group>
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
            {state_ConfirmUrlImage.IsDefault === true && (
              <p className="itemIconImage">
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
                  <th>PriceOriginal</th>
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
                        <td style={{ color: "blue" }}>{item.PriceOrigin}</td>
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
                        <td style={{ color: "red" }}>{item.PriceOrigin}</td>
                        <td style={{ color: "red" }}>{item.Description}</td>
                        <td style={{ color: "red" }}>{item.TypeOf}</td>
                      </tr>
                    )) ||
                    (item.TypeOf === Delete && (
                      <tr
                        key={item.ItemCode}
                        onClick={(e) => HandleClickRowItem(item.ItemCode)}
                      >
                        <td className="decorationTypeDelete">
                          {item.ItemCode}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.ApplyDate}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.StoreCode}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.Quantity}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.CategoryItemMasterID}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.AuthorID}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.priceOrigin}
                        </td>
                        <td className="decorationTypeDelete">
                          {item.Description}
                        </td>
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
        {ListItemMasterMain.length !== 0 && (
          <Button
            variant="danger"
            className="btn_setting"
            onClick={(e) => HandleDeleteItemMaster()}
          >
            <FontAwesomeIcon icon={faTrash} /> Delete
          </Button>
        )}
        {state_KindButton === Revert && (
          <Button
            variant="info"
            className="btn_setting"
            onClick={(e) => HandleRevertItemMaster()}
          >
            <FontAwesomeIcon icon={faRotate} /> Revert
          </Button>
        )}
        <Button
          variant="primary"
          className="btn_setting"
          ref={btn_Add}
          onClick={(e) => HandleCreateItemMaster()}
        >
          <FontAwesomeIcon icon={faPlus} /> Add
        </Button>
        <Button
          variant="warning"
          className="btn_setting"
          ref={btn_Update}
          onClick={(e) => HandleUpdateItemMaster()}
        >
          <FontAwesomeIcon icon={faPenToSquare} /> Update
        </Button>
        {ListItemMasterMain.length !== 0 && (
          <Button
            variant="success"
            className="btn_setting"
            onClick={(e) => HandleConfirmItemMaster()}
          >
            <FontAwesomeIcon icon={faSquareCheck} /> Confirm
          </Button>
        )}
      </p>
      {/* Show And Hide Laoding Data */}
      {state_Show && <LoadingModal />}

      {/* Dialog Add Image Item */}
      <Modal show={showDialog}>
        <Modal.Header className="backroundModal">
          <Modal.Title>Add Image ItemMaster</Modal.Title>
        </Modal.Header>
        <Modal.Body className="backroundModal">
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
              className="inputUrlImage"
              onChange={(e) => SetUrl(e.target.value)}
            />
          </InputGroup>
        </Modal.Body>
        <Modal.Footer className="backroundModal">
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
