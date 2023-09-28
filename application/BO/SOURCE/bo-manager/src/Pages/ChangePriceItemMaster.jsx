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
import "../Styles/ChangePriceItemMaster.css";
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
        toast.error(resultCheckRole.Message);
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
        document.title = "Change Price Item Maters";
        SetListStore([]);
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
              response.ListStore
            );
            // List Select Store
            SetListStore(initializaDataSelect.listStore);

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
  const HandleSelectStore = (e) => {
    // Update StoreCode for ItemMaster
    if (e === 0 || e === "0") {
      toast.error("Please Choose A Store!");
      SetDefaulStore(e);
    } else {
      SetDefaulStore(e);
    }
    return;
  };

  // Handle Seach ItemCode
  const HandleSeachItemCodeUI = async (itemCode, storecode) => {
    SetMessageError("");
    // Validation ItemCode Is Null
    if (itemCode === null || itemCode === undefined || itemCode === "") {
      SetMessageError("ItemCode Not Null!");
      document.getElementById("Btn_ItemCode").focus();
    } else {
      if (storecode === "0" || storecode === undefined) {
        SetMessageError("Please Choose A Store!");
      } else {
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
          </Form.Group>
        </Col>
        <Col xs={4}></Col>
        <Col xs={3}></Col>
        <Col xs={2}></Col>
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
                  <th>Apply Date</th>
                  <th>Description</th>
                  <th>Price Origin</th>
                  <th>Price Sale</th>
                  <th>Percent Discount</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody></tbody>
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
