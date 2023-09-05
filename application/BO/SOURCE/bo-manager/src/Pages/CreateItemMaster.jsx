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

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  let ListImageAdd = [];

  // State Form Create ItemMaster
  const [state_ItemCode, SetItemCode] = useState("");

  // Setting Button
  const btn_Update = useRef(null);
  const btn_Confirm = useRef(null);
  const Btn_DisplayApplydate = useRef(null);
  const Btn_DisplayPriceOrigin = useRef(null);
  const Btn_DisplayPriceSale = useRef(null);

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);

  // Show Store Select
  const [state_ListStore, SetListSotre] = useState([]);
  // Show Author Select
  const [state_ListAuthor, SetListAuthor] = useState([]);
  // Show Publishing Companys Select
  const [state_ListPublishingCompany, SetPublishingCompany] = useState([]);
  // Show Category Select
  const [state_ListCategory, SetCategory] = useState([]);
  // Show And Hide Dialog Add Image
  const [showDialog, setShowDialog] = useState(false);

  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);
  // Url Image
  const [state_Url, SetUrl] = useState("");
  const [state_UrlDefault, SetUrlDefault] = useState("");

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
            SetListSotre(response.ListStore);
            SetListAuthor(response.ListAuthor);
            SetPublishingCompany(response.ListPublishingCompany);
            SetCategory(response.ListCategory);

            // Set Array Null In List ItemMaster When Initializa Data
            dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
          } else {
            SetMessageError(response.MessageError);
          }

          // disabled button
          btn_Update.current.disabled = true;
          btn_Confirm.current.disabled = true;

          document.getElementById("Btn_DisplayApplydate").disabled = true;
          document.getElementById("Btn_DisplayPriceOrigin").disabled = true;
          document.getElementById("Btn_DisplayPriceSale").disabled = true;
          document.getElementById("Btn_DisplayDescription").disabled = true;
          document.getElementById("Btn_DisplayDescriptionLong").disabled = true;
          document.getElementById(
            "Btn_DisplayDescriptionShort"
          ).disabled = true;
          document.getElementById("Btn_DisplayStore").disabled = true;
          document.getElementById("Btn_DisplayQuantity").disabled = true;
          document.getElementById("Btn_DisplayCategory").disabled = true;
          document.getElementById(
            "Btn_DisplayPublishingCompany"
          ).disabled = true;
          document.getElementById("Btn_DisplayAuthor").disabled = true;
          document.getElementById("Btn_DisplaySize").disabled = true;
          document.getElementById("Btn_DisplayNote").disabled = true;

          ListImageAdd = [];
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
    } else {
    }
  };

  // Handle Show Dialog Add Image Item
  const HandleAddImageItem = (e) => {
    setShowDialog(true);
  };

  // Handle Add New Image in List Image
  const HandleAddNewImage = (e) => {
    alert(state_Url);
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

    // Call Api check itemMaster code
    const resultValidaion = await HandleValidationItemCode(formData);

    if (resultValidaion.Status === true) {
      SetMessageError("");
      // Can use this itemcode
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
    } else {
      SetMessageError(resultValidaion.MessageError);
      // Don't use this itemcode
      document.getElementById("Btn_DisplayApplydate").disabled = true;
      document.getElementById("Btn_DisplayPriceOrigin").disabled = true;
      document.getElementById("Btn_DisplayPriceSale").disabled = true;
      document.getElementById("Btn_DisplayDescription").disabled = true;
      document.getElementById("Btn_DisplayDescriptionLong").disabled = true;
      document.getElementById("Btn_DisplayDescriptionShort").disabled = true;
      document.getElementById("Btn_DisplayStore").disabled = true;
      document.getElementById("Btn_DisplayQuantity").dispatch = true;
      document.getElementById("Btn_DisplayCategory").disabled = true;
      document.getElementById("Btn_DisplayAuthor").disabled = true;
      document.getElementById("Btn_DisplayPublishingCompany").disabled = true;
      document.getElementById("Btn_DisplaySize").disabled = true;
      document.getElementById("Btn_DisplayNote").disabled = true;
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
              />
            </InputGroup>

            {/* input Store */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore"
              onChange={(e) => HandleSelectStore(e.target.value)}
            >
              <option defaultChecked value="0">
                Select Store
              </option>
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
              />
            </InputGroup>

            {/* input Category */}
            <p className="titleItem">
              Category <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectStore(e.target.value)}
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
              onChange={(e) => HandleSelectStore(e.target.value)}
              id="Btn_DisplayAuthor"
            >
              <option defaultChecked value="0">
                Select Author
              </option>
              {state_ListAuthor.map((item) => (
                <option key={item.AuthorID} value={item.AuthorID}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>

            {/* input Publishing CompanyID */}
            <p className="titleItem">
              Publishing Company <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectStore(e.target.value)}
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
              />
            </InputGroup>

            {/* input image url */}
            <p className="titleItem">Url Image</p>
            <InputGroup className="mb-3">
              <Button
                variant="secondary"
                onClick={() => HandleAddImageItem()}
                style={{ width: "inherit" }}
              >
                <FontAwesomeIcon icon={faImages} />
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
                  <th>Apply Date</th>
                  <th>Store</th>
                  <th>Quantity</th>
                  <th>Category</th>
                  <th>Author</th>
                  <th>PriceSale</th>
                  <th>Quantity</th>
                  <th>Description</th>
                </tr>
              </thead>
              <tbody></tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="alinebuttonsetting">
        <Button variant="primary" className="btn_setting">
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
          <InputGroup className="mb-3">
            <Form.Control
              placeholder="Enter Url Image Default ..."
              type="text"
              onChange={(e) => SetUrlDefault(e.target.value)}
            />
          </InputGroup>

          <InputGroup className="mb-3">
            <Form.Control
              placeholder="Enter Url Image ..."
              as="textarea"
              style={{ height: "100px", "white-space": "pre" }}
              onChange={(e) => SetUrl(e.target.value)}
            />
          </InputGroup>
        </Modal.Body>
        <Modal.Footer style={{ background: "white" }}>
          <Button variant="secondary">Close</Button>
          <Button variant="primary" onClick={() => HandleAddNewImage()}>
            Save
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default CreateItemMaster;
