import React, { useState, useEffect, useRef } from "react";
import "../Styles/Home.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSearch,
  faEdit,
  faTrashAlt,
  faPlusSquare,
  faCheckSquare,
  faClockRotateLeft,
  faStore,
  faEye,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/Store.css";
import { HandleSeachStore } from "../ApiLablary/StoreApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventSeachStore,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { StoreReducer } from "../ReduxCommon/ReducerCommon/ReducerStore";
import { Create, Update, Delete, Revert } from "../Contants/DataContant";
import moment from "moment";
import { titleCreate } from "../MessageCommon/Message";

// Validation Form Create, delete, update, revert Store
const ValidationFormSubmit = (store) => {
  const resultVali = {
    statusResult: true,
    notification: "",
    numberError: "",
  };

  if (
    store.storeCode == null ||
    store.storeCode === "" ||
    store.storeCode === undefined
  ) {
    resultVali.statusResult = false;
    resultVali.notification = "StoreCode Is Not Null, Please Check Again!";
    resultVali.numberError = 1;
  } else if (
    store.description == null ||
    store.description === "" ||
    store.description === undefined
  ) {
    resultVali.statusResult = false;
    resultVali.notification = "Description Is Not Null, Please Check Again!";
    resultVali.numberError = 2;
  } else if (
    store.address == null ||
    store.address === "" ||
    store.address === undefined
  ) {
    resultVali.statusResult = false;
    resultVali.notification = "Address Is Not Null, Please Check Again!";
    resultVali.numberError = 3;
  }
  return resultVali;
};

// Validation StoreCode exist in Redux list storecode
const ValidationStoreCodeExist = (storecode, listStore) => {
  const result = {
    statusExist: "",
    messageExist: "",
  };
  return result;
};

// Main Function
function Store() {
  // dispatch reducer
  const dispatch = useDispatch();
  // Call list area in Redux
  const listStoreResult = useSelector((item) => item.storeData.ListStore);
  // TypeOf Dialog Setting
  const [typeOfDialog, setTypeOfDialog] = useState("");
  // Show And Hide Dialog Setting
  const [show, setShow] = useState(false);
  // Title Dialog
  const [titleDialog, setTitleDialog] = useState("");

  // State Seach Store
  const [seachStore, setSeachStore] = useState("");
  const [messageError, setMessageError] = useState("");
  // State store
  const [state_StoreCode, setStoreCode] = useState("");
  const [state_Description, setDescription] = useState("");
  const [state_DateCreate, setDateCreate] = useState();
  const [state_Address, setAddress] = useState("");

  // Message validation Form when Submit, Create - Update - Delete - Revert
  const [messageErrorForm, setMessageErrorForm] = useState("");

  // Forcus Element
  const ref_StoreCode = useRef(null);

  useEffect(() => {
    // Setting Title Page
    document.title = "Store";
    // Get Current Date
    const currentDate = new Date();
    setDateCreate(moment(currentDate).format("YYYY-MM-DD"));
  }, []);

  // Focus item create, update, delete
  useEffect(() => {
    if (show === true) {
      if (typeOfDialog === Create) {
        ref_StoreCode.current.focus();
      }
    }
  }, typeOfDialog);

  // Handle Seach Store
  const HandleSeachStoreUI = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventSeachStore);
    // Setting Data Seach Store
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalStore", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", seachStore);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListStore", []);

    // Handle Call Api Seach Area
    var result = await HandleSeachStore(formData);
    if (result.Status === false) {
      // Seach Fail
      setMessageError(result.MessageError);
    } else {
      const listStore = [];

      result.ListStore.forEach(function (item) {
        const store = {
          StoreCode: item.StoreCode,
          Description: item.Description,
          DateCreate: moment(item.DateCreate).format("YYYY-MM-DD"),
          LastUpdateDate:
            item.LastUpdateDate === null
              ? "--"
              : moment(item.LastUpdateDate).format("YYYY-MM-DD"),
          Address: item.Address,
          TypeOf: null,
          OldType: null,
        };
        listStore.push(store);
      });
      // Save Store List In To Redux
      dispatch(StoreReducer.actions.SeachStore(listStore));
      // Seach Success
      setMessageError(result.MessageError);
    }
  };

  // Handle Close Dialog Setting
  const HandleCloseDialogUI = (e) => {
    setTypeOfDialog(null);
    setShow(false);
    setMessageErrorForm("");
  };

  // Handle Add Store
  const HandleCreateStoreUI = (e) => {
    setTypeOfDialog(Create);
    setShow(true);
    setTitleDialog(titleCreate);
    setStoreCode("");
    setDescription("");
    setAddress("");
  };

  // Handle Ok Form
  const HandleOkUI = (e) => {
    // Set Data Submit
    const storeItem = {
      storeCode: state_StoreCode,
      description: state_Description,
      datecreate: state_DateCreate,
      address: state_Address,
    };
    // Validation Result
    const resultVali = ValidationFormSubmit(storeItem);

    if (resultVali.statusResult === false) {
      switch (resultVali.numberError) {
        case 1:
          // Error Store Code focus
          document.getElementById("txtFocusStoreCode").focus();
          break;
        case 2:
          // Error Description focus
          document.getElementById("txtFocusDescription").focus();
          break;
        default:
          // Error Address focus
          document.getElementById("txtFocusAddress").focus();
          break;
      }
      setMessageErrorForm(resultVali.notification);
    } else {
      switch (typeOfDialog) {
        case Create:
          // Check ExistStoreCode
          const checkExistStoreCode = ValidationStoreCodeExist(
            state_StoreCode,
            listStoreResult
          );

          if (checkExistStoreCode.statusExist === false) {
          } else {
          }
          break;
        case Update:
          break;
        case Delete:
          break;
        case Revert:
          break;
        default:
          break;
      }
    }
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <FontAwesomeIcon icon={faStore} /> Store
      </h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" controlId="validationCustom01">
                <Form.Control
                  type="text"
                  placeholder="Store Code..."
                  value={seachStore}
                  onChange={(e) => setSeachStore(e.target.value)}
                />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="button" onClick={() => HandleSeachStoreUI()}>
                  <FontAwesomeIcon icon={faSearch} /> Seach
                </Button>
              </Form.Group>
              <Form.Group as={Col} md="7" controlId="validationCustom02">
                <p className="btnMain">
                  <Button
                    variant="primary"
                    className="btnOption"
                    onClick={() => HandleCreateStoreUI()}
                  >
                    <FontAwesomeIcon icon={faPlusSquare} /> Add
                  </Button>
                  <Button
                    variant="success"
                    className="btnOption"
                    id="btn_Confirm"
                  >
                    <FontAwesomeIcon icon={faCheckSquare} /> Confirm
                  </Button>
                </p>
              </Form.Group>
            </Row>
          </Form>
          <p className="notification">{messageError}</p>
        </Col>
      </Row>
      <Row>
        <Col>
          <div className="customtable">
            <Table bordered hover>
              <thead>
                <tr className="headerarea">
                  <th>StoreCode</th>
                  <th>Description</th>
                  <th>Date Create</th>
                  <th>Last Update Date</th>
                  <th>Status</th>
                  <th>Option</th>
                </tr>
              </thead>
              <tbody>
                {listStoreResult.map(
                  (item) =>
                    (item.TypeOf === Create && (
                      <tr key={item.StoreCode}>
                        <td className="firsColum" style={{ color: "blue" }}>
                          {item.StoreCode}
                        </td>
                        <td style={{ color: "blue" }}>{item.Description}</td>
                        <td style={{ color: "blue" }}>{item.DateCreate}</td>
                        <td style={{ color: "blue" }}>{item.LastUpdateDate}</td>
                        <td style={{ color: "blue" }}>{Create}</td>
                        <td className="lastColum">
                          <Button variant="warning" className="btnOption">
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button variant="danger" className="btnOption">
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button variant="info" className="btnOption">
                            <FontAwesomeIcon icon={faEye} /> Detail
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === Update && (
                      <tr key={item.StoreCode}>
                        <td className="firsColum" style={{ color: "red" }}>
                          {item.StoreCode}
                        </td>
                        <td style={{ color: "red" }}>{item.Description}</td>
                        <td style={{ color: "red" }}>{item.DateCreate}</td>
                        <td style={{ color: "red" }}>{item.LastUpdateDate}</td>
                        <td style={{ color: "red" }}>{Update}</td>
                        <td className="lastColum">
                          <Button variant="warning" className="btnOption">
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button variant="danger" className="btnOption">
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button variant="info" className="btnOption">
                            <FontAwesomeIcon icon={faEye} /> Detail
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === Delete && (
                      <tr key={item.StoreCode} className="trChildItem">
                        <td className="firsColum">{item.StoreCode}</td>
                        <td>{item.Description}</td>
                        <td>{item.DateCreate}</td>
                        <td>{item.LastUpdateDate}</td>
                        <td>{Delete}</td>
                        <td className="lastColum">
                          <Button variant="secondary" className="btnOption">
                            <FontAwesomeIcon icon={faClockRotateLeft} /> Revert
                          </Button>
                          <Button variant="info" className="btnOption">
                            <FontAwesomeIcon icon={faEye} /> Detail
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === null && (
                      <tr key={item.StoreCode}>
                        <td className="firsColum">{item.StoreCode}</td>
                        <td>{item.Description}</td>
                        <td>{item.DateCreate}</td>
                        <td>{item.LastUpdateDate}</td>
                        <td></td>
                        <td className="lastColum">
                          <Button variant="warning" className="btnOption">
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button variant="danger" className="btnOption">
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button variant="info" className="btnOption">
                            <FontAwesomeIcon icon={faEye} /> Detail
                          </Button>
                        </td>
                      </tr>
                    ))
                )}
              </tbody>
            </Table>
          </div>
        </Col>
      </Row>
      {/* DiaLog show Add, update, delete, Confirm */}
      <Modal show={show}>
        <Modal.Header className="settingBackround">
          <Modal.Title>{titleDialog}</Modal.Title>
        </Modal.Header>
        <Modal.Body className="settingBackround">
          {typeOfDialog === Create && (
            <div>
              <p className="errorMessage">{messageErrorForm}</p>
              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">
                  StoreCode <span className="requestData">*</span>
                </Form.Label>
                <Form.Control
                  ref={ref_StoreCode}
                  type="number"
                  value={state_StoreCode}
                  id="txtFocusStoreCode"
                  placeholder="Enter StoreCode..."
                  onChange={(e) => setStoreCode(e.target.value)}
                />
              </Form.Group>
              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">
                  Description <span className="requestData">*</span>
                </Form.Label>
                <Form.Control
                  value={state_Description}
                  type="text"
                  id="txtFocusDescription"
                  placeholder="Enter Description..."
                  onChange={(e) => setDescription(e.target.value)}
                />
              </Form.Group>

              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">
                  DateCreate <span className="requestData">*</span>
                </Form.Label>
                <Form.Control disabled type="date" value={state_DateCreate} />
              </Form.Group>

              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">
                  Address <span className="requestData">*</span>
                </Form.Label>
                <Form.Control
                  value={state_Address}
                  type="text"
                  id="txtFocusAddress"
                  placeholder="Enter Address..."
                  onChange={(e) => setAddress(e.target.value)}
                />
              </Form.Group>
            </div>
          )}
        </Modal.Body>
        <Modal.Footer className="settingBackround">
          <Button variant="secondary" onClick={() => HandleCloseDialogUI()}>
            Close
          </Button>
          <Button variant="primary" onClick={() => HandleOkUI()}>
            <FontAwesomeIcon icon={faPlusSquare} /> Ok
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default Store;
