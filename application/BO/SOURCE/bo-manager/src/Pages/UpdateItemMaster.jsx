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
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSquareCheck,
  faSquareCaretLeft,
  faEllipsis,
  faPenToSquare,
  faBan,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/UpdateItemMaster.css";
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
  EventSeachItemMaster,
  EventUpdateItemMaster,
  UserLogin,
  EventGetAllItemMaster,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import LoadingModal from "../CommonPage/LoadingCommon";
import { useNavigate } from "react-router-dom";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { ItemMasterReducer } from "../ReduxCommon/ReducerCommon/ReducerItemMaster";
import {
  HandleSeachItemMasterUpdate,
  HandleGetAllItemMaster,
  HandleUpdateBaseItemMaster,
} from "../ApiLablary/ItemMasterApi";
import {
  InitializaDataSelect,
  DispayItemForm,
  ValidationItemMasterUpdate,
  ValidationCharacterItemMasterUpdate,
} from "../Validations/ValidationUpdateItemMaster";
import { Update, UpdateBase_ItemMaster } from "../Contants/DataContant";

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const btnUpdate = useRef();

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  // Get List ItemMaster Create
  const ListItemMasterMain = useSelector(
    (item) => item.itemMasterData.ListItemMaster
  );

  // Show Store Select
  const [state_ListStore, SetListStore] = useState([]);
  const [state_DefaulStore, SetDefaulStore] = useState("0");

  // Show Author Select
  const [state_ListAuthor, SetListAuthor] = useState([]);
  const [state_DefaulAuthor, SetDefaultAuthor] = useState("0");

  // Show Publishing Companys Select
  const [state_ListPublishingCompany, SetPublishingCompany] = useState([]);
  const [state_DefaultPublishingCompany, SetDefaultPublishingCompany] =
    useState("0");

  // Show Category Select
  const [state_ListCategory, SetListCategory] = useState([]);
  const [state_DefaultCategory, SetDefaultCategory] = useState("0");

  // Show And Hide Dialog Choose ItemMaster
  const [showDialogItemMaster, setShowDialogItemMaster] = useState(false);
  // State get All ItemMaster When Seach
  const [state_ListItemMaster, SetListItemMaster] = useState([]);
  // Message waining
  const [state_MessageWaining, SetMessageWaining] = useState("");

  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);

  // Create ItemMaster
  const [state_ItemCode, SetItemCode] = useState("");
  const [state_Description, SetDescription] = useState("");
  const [state_DescriptionLong, SetDescriptionLong] = useState("");
  const [state_DescriptionShort, SetDescriptionShort] = useState("");
  const [state_Quantity, SetQuantity] = useState("");
  const [state_Size, SetSize] = useState("");
  const [state_Note, SetNote] = useState("");
  const [state_ImageDefault, SetImageDefault] = useState("");

  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventUpdateItemMaster);

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
        dispatch(OldURLReducer.actions.AddUrl("/updateitemmaster"));
        window.localStorage.setItem("oldURL", "/updateitemmaster");
        // Setting Title Page
        document.title = "Update Item Maters";
        SetListStore([]);
        SetListAuthor([]);
        SetPublishingCompany([]);
        SetListCategory([]);
        // Reset form
        DispayItemForm(0);
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
              response.ListCategory,
              response.ListPublishingCompany
            );
            // List Select Store
            SetListStore(initializaDataSelect.listStore);
            // List Select Author
            SetListAuthor(initializaDataSelect.listAuthor);
            // List Select PublishingCompany
            SetPublishingCompany(initializaDataSelect.listPublishingCompany);
            // List Select Category
            SetListCategory(initializaDataSelect.listCategory);
            document.getElementById("Btn_ItemCode").focus();
          } else {
            SetListStore([]);
            SetMessageError(response.MessageError);
          }
        }
        InitializaData();
      }
      btnUpdate.current.disabled = true;
      // reset List ItemMaster in Redux
      dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
    };
    CheckTokenAndRole();
  }, []);

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  // Handle Select Store
  const HandleSelectStore = (e, type) => {
    if (type === "Type01") {
      // Select store for seach ItemMaster By StoreCode
      SetDefaulStore(e);
    } else {
      // Update StoreCode for ItemMaster
      if (e === 0 || e === "0") {
        toast.error("Please Choose A Store!");
        SetDefaulStore(e);
      } else {
        SetDefaulStore(e);
      }
    }
    return;
  };

  // Handle Select Author
  const HandleSelectAuthor = (e) => {
    if (e === 0 || e === "0") {
      toast.error("Please Choose A Author!");
      SetDefaultAuthor(e);
    } else {
      SetDefaultAuthor(e);
    }
    return;
  };

  // Handle Select PublishingCompany
  const HandleSelectPublishingCompany = (e) => {
    if (e === 0 || e === "0") {
      toast.error("Please Choose A Publishing Company!");
      SetDefaultPublishingCompany(e);
    } else {
      SetDefaultPublishingCompany(e);
    }
    return;
  };

  // Handle Select Category
  const HandleSelectCategory = (e) => {
    if (e === 0 || e === "0") {
      toast.error("Please Choose A Category!");
      SetDefaultCategory(e);
    } else {
      SetDefaultCategory(e);
    }
    return;
  };

  // Handle Click Row Item In Table
  const HandleClickRowItem = (itemcode, applydate) => {
    SetMessageError("");
    const findItemCode = ListItemMasterMain.find(
      (item) => item.ItemCode === itemcode && item.ApplyDate === applydate
    );

    if (findItemCode !== undefined) {
      btnUpdate.current.disabled = false;
      DispayItemForm(1);
      document.getElementById("Btn_ItemCode").disabled = true;
      // Set Data in Form
      SetItemCode(findItemCode.ItemCode);
      SetDescription(findItemCode.Description);
      SetDescriptionLong(findItemCode.DescriptionLong);
      SetDescriptionShort(findItemCode.DescriptionShort);
      SetQuantity(findItemCode.Quantity);
      SetSize(findItemCode.size);
      SetNote(findItemCode.Note);
      SetMessageError(findItemCode.ApplyDate);
      // Set Select Defaul
      SetDefaulStore(findItemCode.StoreCode);
      SetDefaultAuthor(findItemCode.AuthorID);
      SetDefaultCategory(findItemCode.CategoryItemMasterID);
      SetDefaultPublishingCompany(findItemCode.PublishingCompanyID);
      SetImageDefault(findItemCode.ImageItemMaster.UrlImageDefault);
    } else {
      SetMessageError("Not Find ItemCode, Please Try Again!");
    }
  };

  // Handle Seach ItemCode
  const HandleSeachItemCodeUI = async (itemCode, typeSent, storecode) => {
    SetMessageError("");
    // Validation ItemCode Is Null
    if (itemCode === null || itemCode === undefined || itemCode === "") {
      SetMessageError("ItemCode Not Null!");
      document.getElementById("Btn_ItemCode").focus();
    } else {
      if (storecode === "0" || storecode === undefined) {
        SetMessageError("Please Choose A Store!");
      } else {
        // Hide Dialog Get All ItemMaster
        if (typeSent === "TypeSent02") {
          setShowDialogItemMaster(false);
        }
        // Show loading dialog
        SetShow(true);
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
        formData.append("KeySeach", itemCode);
        formData.append("CompanyCode", CompanyCode);
        formData.append("StoreCode", storecode);
        formData.append("ListItemMaster", []);

        // Call Api Get ItemMaster By ItemCode
        const resultData = await HandleSeachItemMasterUpdate(formData);

        // Hide loading Dialog
        SetShow(false);

        // Result
        if (resultData.Status === false) {
          SetItemCode("");
          SetMessageError(resultData.MessageError);
          document.getElementById("Btn_ItemCode").focus();
          SetDefaulStore("0");
        } else {
          SetItemCode("");
          document.getElementById("Btn_ItemCode").focus();
          SetDefaulStore("0");
          dispatch(
            ItemMasterReducer.actions.SeachItemMaster(resultData.ListItemMaster)
          );
        }
      }
    }
    return;
  };

  // Handle Show Dialog Get All ItemMaster UI
  const HandleShowDialogGetAllItemMasterUI = async (e) => {
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");
    setShowDialogItemMaster(true);
    SetListItemMaster([]);
  };

  // Handle GetAll ItemMaster
  const HandleGetAllItemMasterUI = async (e) => {
    SetMessageError("");
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventGetAllItemMaster);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("StoreCode", state_DefaulStore);
    formData.append("CompanyCode", CompanyCode);

    // Call Api
    const result = await HandleGetAllItemMaster(formData);
    if (result.Status === true) {
      if (result.TotalItemMaster === 0) {
        SetMessageWaining(result.MessageError);
      } else {
        SetMessageWaining(result.TotalItemMaster);
      }
      // render list itemMaster In UI
      SetListItemMaster(result.ListItemMaster);
    } else {
      SetMessageError(result.MessageError);
    }
  };

  // Handle Close Dialog Filter ItemMaster
  const HandleCloseDialogFilterItemMaster = (e) => {
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");

    SetMessageWaining("");
    SetMessageError("");
    setShowDialogItemMaster(false);
    SetListItemMaster([]);
  };

  // Handle Update ItemMaster
  const HandleUpdateItemMasterUI = (itemcode, applydate) => {
    if (itemcode === null || itemcode === "" || itemcode === undefined) {
      toast.error("ItemCode Is Not Null!");
      return;
    }
    // VALIDATION DATA ITEMMASTER
    var itemMaster_Vali = {
      ItemCode: itemcode,
      Applydate: applydate,
      Description: state_Description,
      DescriptionLong: state_DescriptionLong,
      DescriptionShort: state_DescriptionShort,
      Quantity: state_Quantity,
      size: state_Size,
      Note: state_Note,
      StoreCode: state_DefaulStore,
      AuthorID: state_DefaulAuthor,
      CategoryItemMasterID: state_DefaultCategory,
      PublishingCompanyID: state_DefaultPublishingCompany,
      TypeOf: Update,
    };

    // Validation Class 1
    const resultVali = ValidationItemMasterUpdate(itemMaster_Vali);
    if (resultVali.Status === false) {
      // Error Fail Validation
      toast.error(resultVali.MessageError);
      document.getElementById(resultVali.IdElement).focus();
      return;
    }

    // Validation Class 2
    const resultValiCharacter =
      ValidationCharacterItemMasterUpdate(itemMaster_Vali);
    if (resultValiCharacter.Status === false) {
      // Error Fail Validation
      toast.error(resultValiCharacter.MessageError);
      document.getElementById(resultValiCharacter.IdElement).focus();
      return;
    }

    // VALIDATION ITEMMASTER SUCCESS UPDATE ITEMMASTER In REDUX
    dispatch(ItemMasterReducer.actions.UpdateItemMasterShort(itemMaster_Vali));
    toast.success(
      "Update ItemCode: " +
        itemcode +
        " , Have Applydate: " +
        applydate +
        " Success"
    );
    // Reset
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");
    SetDefaultAuthor("0");
    SetDefaultCategory("0");
    SetDefaultPublishingCompany("0");

    // Set Data in Form
    DispayItemForm(0);
    btnUpdate.current.disabled = true;
    document.getElementById("Btn_ItemCode").disabled = false;
    document.getElementById("Btn_ItemCode").focus();
    SetItemCode("");
    SetDescription("");
    SetDescriptionLong("");
    SetDescriptionShort("");
    SetQuantity("");
    SetSize("");
    SetNote("");
    SetMessageError("");
    SetImageDefault("");
  };

  // Handle Cancel ItemMaster
  const HandleCancelItemMasterUI = (e) => {
    // Reset
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");
    SetDefaultAuthor("0");
    SetDefaultCategory("0");
    SetDefaultPublishingCompany("0");

    // Set Data in Form
    DispayItemForm(0);
    btnUpdate.current.disabled = true;
    document.getElementById("Btn_ItemCode").disabled = false;
    document.getElementById("Btn_ItemCode").focus();
    SetItemCode("");
    SetDescription("");
    SetDescriptionLong("");
    SetDescriptionShort("");
    SetQuantity("");
    SetSize("");
    SetNote("");
    SetMessageError("");
  };

  // Handle Confirm ItemMaster
  const HandleConfirmItemMasterUI = async (e) => {
    // create new list itemMaster Update
    const listUpdateItemMaster = [];
    // Get Data In List Redux
    ListItemMasterMain.forEach(function (item) {
      if (item.TypeOf === Update) {
        const itemMaster = {
          CompanyCode: item.CompanyCode,
          StoreCode: item.StoreCode,
          ItemCode: item.ItemCode,
          ApplyDate: item.ApplyDate,
          Description: item.Description,
          DescriptionShort: item.DescriptionShort,
          DescriptionLong: item.DescriptionLong,
          CategoryItemMasterID: item.CategoryItemMasterID,
          AuthorID: item.AuthorID,
          PublishingCompanyID: item.PublishingCompanyID,
          Note: item.Note,
          size: item.size,
          Quantity: item.Quantity,
          UserID: window.localStorage.getItem("UserID"),
        };
        listUpdateItemMaster.push(itemMaster);
      }
    });

    if (listUpdateItemMaster.length !== 0) {
      // Conver Array to Json
      var jsonItemMasterUpdate = JSON.stringify(listUpdateItemMaster);
      // Get Token
      var token = GetCookies(UserLogin);
      // Get EventCode
      var eventCode = ConcatStringEvent(FistCode, EventUpdateItemMaster);
      // Setting Data Seach Area
      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);
      formData.append("TotalItemMaster", 0);
      formData.append("MessageError", null);
      formData.append("Status", true);
      formData.append("KeySeach", jsonItemMasterUpdate);
      formData.append("CompanyCode", CompanyCode);
      formData.append("StoreCode", null);
      formData.append("OTPControl", UpdateBase_ItemMaster);
      formData.append("ListItemMaster", []);

      // Call Api
      SetShow(true);
      const resultUpdate = await HandleUpdateBaseItemMaster(formData);
      SetShow(false);

      if (resultUpdate.Status === false) {
        // Update Fail
        SetMessageError(resultUpdate.MessageError);
      } else {
        // Update Success
        toast.success("Update ItemMaster Success!");
      }
    }

    // Set Data in Form
    DispayItemForm(0);
    btnUpdate.current.disabled = true;
    document.getElementById("Btn_ItemCode").disabled = false;
    document.getElementById("Btn_ItemCode").focus();
    SetItemCode("");
    SetDescription("");
    SetDescriptionLong("");
    SetDescriptionShort("");
    SetQuantity("");
    SetSize("");
    SetNote("");
    SetImageDefault("");
    // reset List ItemMaster in Redux
    dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
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
        | Update Item Master
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
                variant="outline-primary"
                onClick={(e) => HandleShowDialogGetAllItemMasterUI()}
              >
                <FontAwesomeIcon icon={faEllipsis} />
              </Button>
              <Button
                variant="outline-secondary"
                onClick={(e) =>
                  HandleSeachItemCodeUI(
                    state_ItemCode,
                    "TypeSent01",
                    state_DefaulStore
                  )
                }
              >
                Seach
              </Button>
            </InputGroup>

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
          </Form.Group>
        </Col>
        <Col xs={4}>
          <Form.Group>
            {/* input Store */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore mb-3"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value, "Type02")}
            >
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>

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

            {/* input Publishing CompanyID */}
            <p className="titleItem">
              Publishing Company <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              value={state_DefaultPublishingCompany}
              onChange={(e) => HandleSelectPublishingCompany(e.target.value)}
              id="Btn_DisplayPublishingCompany"
            >
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
                style={{ height: "110px" }}
                onChange={(e) => SetNote(e.target.value)}
                value={state_Note}
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={2}>
          <Form.Group>
            {state_ImageDefault !== null && (
              <img
                className="imgDefault"
                alt={state_ImageDefault}
                src={state_ImageDefault}
                border="0"
              />
            )}
          </Form.Group>
          <Form.Group>
            <InputGroup className="mb-12">
              <Button
                variant="outline-primary"
                onClick={(e) =>
                  HandleUpdateItemMasterUI(state_ItemCode, state_MessageError)
                }
                ref={btnUpdate}
              >
                <FontAwesomeIcon icon={faPenToSquare} /> Update
              </Button>
              <Button
                variant="outline-danger"
                onClick={(e) => HandleCancelItemMasterUI()}
              >
                <FontAwesomeIcon icon={faBan} /> Cancel
              </Button>
            </InputGroup>
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
                {ListItemMasterMain.map((item) => (
                  <tr
                    key={item.Id}
                    onClick={(e) =>
                      HandleClickRowItem(item.ItemCode, item.ApplyDate)
                    }
                  >
                    <td>{item.ItemCode}</td>
                    <td>{item.StoreCode}</td>
                    <td>{item.Quantity}</td>
                    <td>{item.CategoryItemMasterID}</td>
                    <td>{item.AuthorID}</td>
                    <td>{item.priceSale}</td>
                    <td>{item.PublishingCompanyID}</td>
                    <td>{item.Description}</td>
                    {(item.TypeOf === Update && (
                      <td style={{ color: "red" }}>{item.TypeOf}</td>
                    )) ||
                      (item.TypeOf === null && (
                        <td style={{ color: "blue" }}>---</td>
                      ))}
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="alinebuttonsetting">
        {ListItemMasterMain.length !== 0 && (
          <Button
            variant="success"
            className="btn_setting"
            onClick={(e) => HandleConfirmItemMasterUI()}
          >
            <FontAwesomeIcon icon={faSquareCheck} /> Confirm
          </Button>
        )}
      </p>
      {/* Show And Hide Laoding Data */}
      {state_Show && <LoadingModal />}
      {/* Dialog list itemMaster */}
      <Modal show={showDialogItemMaster}>
        <Modal.Header className="backroundModal">
          <InputGroup className="mb-3">
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore mb-3"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value, "Type01")}
            >
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>
            <Button
              className="fuilterItemMaster"
              variant="outline-primary"
              onClick={(e) => HandleGetAllItemMasterUI()}
            >
              Filter
            </Button>
          </InputGroup>
        </Modal.Header>
        <Modal.Body className="backroundModal sizeBody">
          <p className="MessageWaining">{state_MessageWaining}</p>
          <Table bordered hover>
            <tbody>
              {state_ListItemMaster.map((item) => (
                <tr key={item.ItemCode}>
                  <td>
                    <p className="buttonChoose">{item.ItemCode} </p>
                  </td>
                  <td>
                    <p className="buttonChoose">{item.Description}</p>
                  </td>
                  <td>
                    <p className="buttonChoose">
                      <Button
                        variant="primary"
                        onClick={(e) =>
                          HandleSeachItemCodeUI(
                            item.ItemCode,
                            "TypeSent02",
                            state_DefaulStore
                          )
                        }
                      >
                        Choose
                      </Button>
                    </p>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Modal.Body>
        <Modal.Footer className="backroundModal">
          <Button
            variant="secondary"
            onClick={() => HandleCloseDialogFilterItemMaster()}
          >
            Close
          </Button>
        </Modal.Footer>
      </Modal>
      <ToastContainer />
    </Container>
  );
}

export default CreateItemMaster;
