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
  CurrencyInputMoney,
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
  HandleGetAllItemMaster,
  HandleSeachItemMasterUpdatePrice,
} from "../ApiLablary/ItemMasterApi";
import { InitializaDataSelect } from "../Validations/ValidationChangePriceItemMaster";
import { Update, UpdateBase_ItemMaster } from "../Contants/DataContant";

// Main Function
function ChangePriceItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  // Get List ItemMaster Create
  const ListItemMasterMain = useSelector(
    (item) => item.itemMasterData.ListItemMaster
  );

  // Show Store Select
  const [state_ListStore, SetListStore] = useState([]);
  const [state_DefaulStore, SetDefaulStore] = useState("0");
  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show Loading Dialog
  const [Show, SetShow] = useState(false);
  const [DialogGetItemMaster, SetDialogGetItemMaster] = useState(false);
  // Show list ItemMaster Affter Fuilter
  const [ListItemMaster, SetListItemMaster] = useState([]);

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
          } else {
            SetListStore([]);
            SetMessageError(response.MessageError);
          }
        }
        InitializaData();
      }
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

  // Show dialog get all ItemMaster
  const HandleShowGetAllItemMaster = (e) => {
    SetDialogGetItemMaster(true);
    SetDefaulStore("0");
  };

  // Handle Fuilter ItemMaster
  const HandleFilterItemMaster = async (e) => {
    if (state_DefaulStore === "0") {
      toast.error("Please Choose A Store!");
    } else {
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
      SetShow(true);
      const result = await HandleGetAllItemMaster(formData);
      SetShow(false);

      if (result.Status === true) {
        if (result.TotalItemMaster === 0) {
          toast.success(result.MessageError);
        }
        // render list itemMaster In UI
        SetListItemMaster(result.ListItemMaster);
      } else {
        toast.error(result.MessageError);
      }
    }
    return;
  };

  // Handle Seach ItemMaster
  const HandleSeachItemCodeUI = async (itemCode, storecode) => {
    SetMessageError("");
    SetDialogGetItemMaster(false);
    // Validation ItemCode Is Null
    if (itemCode === null || itemCode === undefined || itemCode === "") {
      toast.error("ItemCode Not Null!");
    } else {
      if (storecode === "0" || storecode === undefined) {
        toast.error("Please Choose A Store!");
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
        const resultData = await HandleSeachItemMasterUpdatePrice(formData);
        // Hide loading Dialog
        SetShow(false);
        // Result
        if (resultData.Status === false) {
          SetMessageError(resultData.MessageError);
          SetDefaulStore("0");
        } else {
          SetDefaulStore("0");
          dispatch(
            ItemMasterReducer.actions.SeachItemMaster(resultData.ListItemMaster)
          );
        }
      }
    }
    SetDialogGetItemMaster(false);
    return;
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <Button
          type="button"
          variant="light"
          onClick={(e) => HandleBackMenuUI()}
        >
          <FontAwesomeIcon icon={faSquareCaretLeft} /> Back
        </Button>
        | Change Price Item Master
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
                id="Txt_ItemCode"
                placeholder="Enter ItemCode ..."
              />
              <Button
                variant="outline-primary"
                onClick={(e) => HandleShowGetAllItemMaster()}
              >
                <FontAwesomeIcon icon={faEllipsis} />
              </Button>
              <Button variant="outline-secondary">Seach</Button>
            </InputGroup>

            {/* Apply Date */}
            <p className="titleItem">
              Apply Date <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control id="Txt_Applydate" type="datetime-local" />
            </InputGroup>

            {/* Description */}
            <p className="titleItem">
              Description <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Txt_Description"
                type="text"
                placeholder="Enter Description ..."
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={3}>
          <Form.Group>
            {/* corner price */}
            <p className="titleItem">
              Corner Price <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <CurrencyInputMoney
                placeholder="0 VND"
                type="text"
                className="inputPrice"
              />
            </InputGroup>

            {/* price sale */}
            <p className="titleItem">
              Price Sale <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <CurrencyInputMoney
                placeholder="0 VND"
                type="text"
                className="inputPrice"
              />
            </InputGroup>

            {/* percent discount */}
            <p className="titleItem">
              Percent Discount <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Txt_cornerprice"
                type="number"
                placeholder="Enter Percent Discount ..."
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={3}>
          <Form.Group>
            {/* corner price */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Txt_cornerprice"
                type="text"
                placeholder="Store"
              />
            </InputGroup>
            <InputGroup className="mb-3">
              <Button variant="outline-primary" className="btncontrol">
                <FontAwesomeIcon icon={faPenToSquare} /> Update
              </Button>
              <Button variant="outline-danger" className="btncontrol">
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
                  <th>Apply Date</th>
                  <th>Description</th>
                  <th>Corner Price</th>
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
          <Button variant="success" className="btn_setting">
            <FontAwesomeIcon icon={faSquareCheck} /> Confirm
          </Button>
        )}
      </p>
      {/* Show And Hide Laoding Data */}
      {Show && <LoadingModal />}
      {/* Dialog list itemMaster */}
      <Modal show={DialogGetItemMaster}>
        <Modal.Header className="backroundModal">
          <InputGroup className="mb-3">
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore mb-3"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value)}
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
              onClick={(e) => HandleFilterItemMaster(state_DefaulStore)}
            >
              Filter
            </Button>
          </InputGroup>
        </Modal.Header>
        <Modal.Body className="backroundModal sizeBody">
          <Table bordered hover>
            <tbody>
              {ListItemMaster.map((item) => (
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
          <Button variant="secondary">Close</Button>
        </Modal.Footer>
      </Modal>
      <ToastContainer />
    </Container>
  );
}

export default ChangePriceItemMaster;
