import React, { useState, useEffect, useRef } from "react";
import "../Styles/CreateItemMaster.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import Table from "react-bootstrap/Table";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPlus,
  faPenToSquare,
  faEye,
  faSquareCheck,
  faSquareCaretLeft,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/ItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetAllStore,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import {
  CompanyCode,
  FistCode,
  EventInitializaItemMaster,
  EventItemMaster,
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

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Setting Button
  const btn_Update = useRef(null);
  const btn_Confirm = useRef(null);

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);

  // Show Store Select
  const [state_ListStore, SetListSotre] = useState([]);
  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);

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
          const response = await HandleGetAllStore(formData);
          if (response.Status === true) {
            SetListSotre(response.ListStore);
            // Set Array Null In List ItemMaster When Initializa Data
            dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
          } else {
            SetMessageError(response.MessageError);
          }

          // disabled button
          btn_Update.current.disabled = true;
          btn_Confirm.current.disabled = true;
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
                placeholder="Enter ItemCode ..."
                aria-describedby="basic-addon2"
              />
              <Button variant="outline-secondary">Seach</Button>
            </InputGroup>

            {/* input Applydate */}
            <p className="titleItem">
              Apply Date <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control type="Date" aria-describedby="basic-addon2" />
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
              />
            </InputGroup>

            {/* input Store */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <Form.Select
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
              />
            </InputGroup>

            {/* input Category */}
            <p className="titleItem">
              Category <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              onChange={(e) => HandleSelectStore(e.target.value)}
            >
              <option defaultChecked value="0">
                Select Category
              </option>
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
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
            >
              <option defaultChecked value="0">
                Select Author
              </option>
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
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
            >
              <option defaultChecked value="0">
                Select Publishing Company
              </option>
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
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
                placeholder="Enter Size ..."
                aria-describedby="basic-addon2"
              />
            </InputGroup>

            {/* input Note */}
            <p className="titleItem">Note</p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Note ..."
                as="textarea"
                style={{ height: "50px" }}
              />
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
    </Container>
  );
}

export default CreateItemMaster;
