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
import { HandleSeachStore, HandleConfirmStore } from "../ApiLablary/StoreApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventSeachStore,
  EventConfirmStore,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { StoreReducer } from "../ReduxCommon/ReducerCommon/ReducerStore";
import {
  Create,
  Update,
  Delete,
  Revert,
  Detail,
} from "../Contants/DataContant";
import moment from "moment";
import {
  titleCreate,
  titleDelete,
  titleRevert,
  titleUpdate,
  titleDetail,
} from "../MessageCommon/Message";
import LoadingModal from "../CommonPage/LoadingCommon";

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
    oldDataType: null,
  };
  // Find StoreCode in List StoreCode
  const findStoreCode = listStore.find(
    (store) => store.StoreCode === storecode
  );

  if (findStoreCode !== undefined) {
    result.statusExist = false;
    result.messageExist =
      "Exist StoreCode In System, Please Choose Anoder StoreCode!";
    result.oldDataType = findStoreCode.TypeOf;
  } else {
    result.statusExist = true;
    result.messageExist = "Not Exist StoreCode In System, Please Check Again!";
  }

  return result;
};

// Main Function
function Store() {
  // dispatch reducer
  const dispatch = useDispatch();
  // Call list area in Redux
  const listStoreResult = useSelector((item) => item.storeData.ListStore);
  // TypeOf Dialog Setting
  const [typeOfDialog, setTypeOfDialog] = useState(null);
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
  const [state_LastUpdateDate, setLastUpdateDate] = useState("");

  // Message validation Form when Submit, Create - Update - Delete - Revert
  const [messageErrorForm, setMessageErrorForm] = useState("");

  // Show and hide DiaLog Loading
  const [loading, setLoading] = useState(false);

  // Forcus Element
  const ref_StoreCode = useRef(null);

  useEffect(() => {
    // Setting Title Page
    document.title = "Store";
    // Get Current Date
    const currentDate = new Date();
    setDateCreate(moment(currentDate).format("YYYY-MM-DD"));
    // Set listStore in redux when initialization
    HandleInitializaStore();
    // Display Button Confirm
    document.getElementById("bnt_Confirm").disabled = true;
  }, []);

  // Handle set data area when initialization
  const HandleInitializaStore = () => {
    // Save Store List In To Redux
    dispatch(StoreReducer.actions.SeachStore([]));
  };

  // Focus item create, update, delete
  useEffect(() => {
    if (show === true) {
      if (typeOfDialog === Create) {
        if (state_Description === "" && state_Address === "") {
          ref_StoreCode.current.focus();
        }
      }
    }
  });

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

    // Handle Call Api Seach Store
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
            item.LastUpdateDate === null ? "--" : item.LastUpdateDate,
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

  // Handle Update Store
  const HandleUpdateUI = (storeCode) => {
    // Get store by storecode in liststore
    const store = listStoreResult.find((item) => item.StoreCode === storeCode);

    if (store !== undefined) {
      setTypeOfDialog(Update);
      setShow(true);
      setTitleDialog(titleUpdate);
      setStoreCode(store.StoreCode);
      setDescription(store.Description);
      setAddress(store.Address);
      setDateCreate(store.DateCreate);
    } else {
      alert("Not Find Store You Want Update, Please Check Again!");
    }
  };

  // Handle Delete Store
  const HandleDeleteUI = (storeCode) => {
    // Get store by storecode in liststore
    const store = listStoreResult.find((item) => item.StoreCode === storeCode);

    if (store !== undefined) {
      setTypeOfDialog(Delete);
      setShow(true);
      setTitleDialog(titleDelete);
      setStoreCode(store.StoreCode);
      setDescription(store.Description);
      setAddress(store.Address);
      setDateCreate(store.DateCreate);
    } else {
      alert("Not Find Store You Want Delete, Please Check Again!");
    }
  };

  // Handle Revert Store
  const HandleRevertUI = (storeCode) => {
    // Get store by storecode in liststore
    const store = listStoreResult.find((item) => item.StoreCode === storeCode);

    if (store !== undefined) {
      setTypeOfDialog(Revert);
      setShow(true);
      setTitleDialog(titleRevert);
      setStoreCode(store.StoreCode);
      setDescription(store.Description);
      setAddress(store.Address);
      setDateCreate(store.DateCreate);
    } else {
      alert("Not Find Store You Want Revert, Please Check Again!");
    }
  };

  // Handle Detail Store
  const HandleDetailUI = (storeCode) => {
    // Get store by storecode in liststore
    const store = listStoreResult.find((item) => item.StoreCode === storeCode);

    if (store !== undefined) {
      setTypeOfDialog(Detail);
      setShow(true);
      setTitleDialog(titleDetail);
      setStoreCode(store.StoreCode);
      setDescription(store.Description);
      setAddress(store.Address);
      setDateCreate(store.DateCreate);
      if (store.LastUpdateDate !== "--") {
        setLastUpdateDate(moment(store.LastUpdateDate).format("YYYY-MM-DD"));
      } else {
        setLastUpdateDate("Don't Have Data Last Update Date");
      }
    } else {
      alert("Not Find Store You Want View Detail, Please Check Again!");
    }
  };

  // Handle Confirm Store
  const HandleConfirmStoreUI = async (e) => {
    //Show Loading
    setLoading(true);
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventConfirmStore);
    // Conver ListStore to string
    const listStoreConfirm = [];
    for (var i = 0; listStoreResult.length > i; i++) {
      switch (listStoreResult[i].TypeOf) {
        case Create:
          const createStore = {
            StoreCode: listStoreResult[i].StoreCode,
            Description: listStoreResult[i].Description,
            DateCreate: listStoreResult[i].DateCreate,
            LastUpdateDate: listStoreResult[i].LastUpdateDate,
            Address: listStoreResult[i].Address,
            TypeOf: Create,
            OldType: null,
          };
          listStoreConfirm.push(createStore);
          break;
        case Update:
          const updateStore = {
            StoreCode: listStoreResult[i].StoreCode,
            Description: listStoreResult[i].Description,
            DateCreate: listStoreResult[i].DateCreate,
            LastUpdateDate: listStoreResult[i].LastUpdateDate,
            Address: listStoreResult[i].Address,
            TypeOf: Update,
            OldType: null,
          };
          listStoreConfirm.push(updateStore);
          break;
        case Delete:
          const deleteStore = {
            StoreCode: listStoreResult[i].StoreCode,
            Description: listStoreResult[i].Description,
            DateCreate: listStoreResult[i].DateCreate,
            LastUpdateDate: listStoreResult[i].LastUpdateDate,
            Address: listStoreResult[i].Address,
            TypeOf: Delete,
            OldType: null,
          };
          listStoreConfirm.push(deleteStore);
          break;
        default:
          break;
      }
    }

    // Conver Array to Json
    var converArrayToJsonStore = JSON.stringify(listStoreConfirm);

    // Setting Data Confirm Store
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalStore", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", converArrayToJsonStore);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListStore", []);

    // Handle Call Api Confrim Store
    var result = await HandleConfirmStore(formData);

    // Hide Dialog Loading
    setLoading(false);

    if (result.Status === false) {
      // Confirm Store Error
      setMessageError(result.MessageError);
    } else {
      // Confirm Store Success
      // Setting Data Seach Store
      var formDataSeach = new FormData();
      formDataSeach.append("Token", token);
      formDataSeach.append("UserID", window.localStorage.getItem("UserID"));
      formDataSeach.append(
        "RoleID",
        window.localStorage.getItem("RoleEmployer")
      );
      formDataSeach.append("EventCode", eventCode);
      formDataSeach.append("TotalStore", 0);
      formDataSeach.append("MessageError", null);
      formDataSeach.append("Status", true);
      formDataSeach.append("KeySeach", "");
      formDataSeach.append("CompanyCode", CompanyCode);
      formDataSeach.append("ListStore", []);

      // Handle Call Api Seach Store
      var resultSeach = await HandleSeachStore(formDataSeach);
      // Auto Seach Store
      const listStore = [];

      resultSeach.ListStore.forEach(function (item) {
        const store = {
          StoreCode: item.StoreCode,
          Description: item.Description,
          DateCreate: moment(item.DateCreate).format("YYYY-MM-DD"),
          LastUpdateDate:
            item.LastUpdateDate === null ? "--" : item.LastUpdateDate,
          Address: item.Address,
          TypeOf: null,
          OldType: null,
        };
        listStore.push(store);
      });
      // Save Store List In To Redux
      dispatch(StoreReducer.actions.SeachStore(listStore));
    }
    return;
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
            // Error StoreCode Exsit in System
            document.getElementById("txtFocusStoreCode").focus();
            setStoreCode("");
            setMessageErrorForm(checkExistStoreCode.messageExist);
            return;
          } else {
            const storeCreate = {
              StoreCode: state_StoreCode,
              Description: state_Description,
              DateCreate: state_DateCreate,
              LastUpdateDate: null,
              Address: state_Address,
              TypeOf: Create,
              OldType: null,
            };
            // Save Store Create Into Redux
            dispatch(StoreReducer.actions.AddStore(storeCreate));
          }
          break;
        case Update:
          // Check ExistStoreCode
          const checkUpdateStoreCode = ValidationStoreCodeExist(
            state_StoreCode,
            listStoreResult
          );

          if (checkUpdateStoreCode.statusExist === true) {
            // Not Exist StoreCode In System
            setMessageErrorForm(checkUpdateStoreCode.messageExist);
            return;
          } else {
            const storeUpdate = {
              StoreCode: state_StoreCode,
              Description: state_Description,
              DateCreate: state_DateCreate,
              Address: state_Address,
              TypeOf: Update,
              OldType: null,
            };
            // Save Store Create Into Redux
            dispatch(StoreReducer.actions.UpdateStore(storeUpdate));
          }
          break;
        case Delete:
          // Check Delete StoreCode
          const checkDeleteStoreCode = ValidationStoreCodeExist(
            state_StoreCode,
            listStoreResult
          );

          if (checkDeleteStoreCode.statusExist === true) {
            // Not Exist StoreCode In System
            setMessageErrorForm(checkUpdateStoreCode.messageExist);
            return;
          } else {
            const storeDelete = {
              StoreCode: state_StoreCode,
              Description: state_Description,
              DateCreate: state_DateCreate,
              Address: state_Address,
              TypeOf: Delete,
              OldType: checkDeleteStoreCode.oldDataType,
            };
            // Save Store Delete Into Redux
            dispatch(StoreReducer.actions.DeleteStore(storeDelete));
          }
          break;
        case Revert:
          // Check Revert StoreCode
          const checkRevertStoreCode = ValidationStoreCodeExist(
            state_StoreCode,
            listStoreResult
          );

          if (checkRevertStoreCode.statusExist === true) {
            // Not Exist StoreCode In System
            setMessageErrorForm(checkUpdateStoreCode.messageExist);
            return;
          } else {
            const storeRevert = {
              StoreCode: state_StoreCode,
            };
            // Save Store Delete Into Redux
            dispatch(StoreReducer.actions.RevertStore(storeRevert));
          }
          break;
        default:
          // View Detail Close DiaLog Setting
          setTypeOfDialog(null);
          setShow(false);
          setMessageErrorForm("");
          return;
      }
      // Close DiaLog Setting
      setTypeOfDialog(null);
      setShow(false);
      setMessageErrorForm("");
      // anable Button Confirm
      document.getElementById("bnt_Confirm").disabled = false;
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
                    id="bnt_Confirm"
                    onClick={() => HandleConfirmStoreUI()}
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
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={() => HandleUpdateUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={() => HandleDeleteUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button
                            variant="info"
                            className="btnOption"
                            onClick={() => HandleDetailUI(item.StoreCode)}
                          >
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
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={() => HandleUpdateUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={() => HandleDeleteUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button
                            variant="info"
                            className="btnOption"
                            onClick={() => HandleDetailUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faEye} /> Detail
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === Delete && (
                      <tr key={item.StoreCode} className="trChildItem">
                        <td className="firsColum" style={{ color: "gray" }}>
                          {item.StoreCode}
                        </td>
                        <td style={{ color: "gray" }}>{item.Description}</td>
                        <td style={{ color: "gray" }}>{item.DateCreate}</td>
                        <td style={{ color: "gray" }}>{item.LastUpdateDate}</td>
                        <td style={{ color: "gray" }}>{Delete}</td>
                        <td className="lastColum">
                          <Button
                            variant="secondary"
                            className="btnOption"
                            onClick={() => HandleRevertUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faClockRotateLeft} /> Revert
                          </Button>
                          <Button
                            variant="info"
                            className="btnOption"
                            onClick={() => HandleDetailUI(item.StoreCode)}
                          >
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
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={() => HandleUpdateUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={() => HandleDeleteUI(item.StoreCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                          <Button
                            variant="info"
                            className="btnOption"
                            onClick={() => HandleDetailUI(item.StoreCode)}
                          >
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
          {(typeOfDialog === Create && (
            <div>
              <p className="errorMessage">{messageErrorForm}</p>
              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">
                  Store Code <span className="requestData">*</span>
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
                  Date Create <span className="requestData">*</span>
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
          )) ||
            (typeOfDialog === Update && (
              <div>
                <p className="errorMessage">{messageErrorForm}</p>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Store Code</Form.Label>
                  <Form.Control
                    type="number"
                    value={state_StoreCode}
                    disabled
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
                    Date Create <span className="requestData">*</span>
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
            )) ||
            (typeOfDialog === Delete && (
              <div>
                <p className="errorMessage">{messageErrorForm}</p>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Store Code</Form.Label>
                  <Form.Control
                    type="number"
                    value={state_StoreCode}
                    disabled
                  />
                </Form.Group>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Description <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control
                    value={state_Description}
                    type="text"
                    disabled
                  />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Date Create <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control disabled type="date" value={state_DateCreate} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Address <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control value={state_Address} type="text" disabled />
                </Form.Group>
              </div>
            )) ||
            (typeOfDialog === Revert && (
              <div>
                <p className="errorMessage">{messageErrorForm}</p>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Store Code</Form.Label>
                  <Form.Control
                    type="number"
                    value={state_StoreCode}
                    disabled
                  />
                </Form.Group>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Description <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control
                    value={state_Description}
                    type="text"
                    disabled
                  />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Date Create <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control disabled type="date" value={state_DateCreate} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Address <span className="requestData">*</span>
                  </Form.Label>
                  <Form.Control value={state_Address} type="text" disabled />
                </Form.Group>
              </div>
            )) ||
            (typeOfDialog === Detail && (
              <div>
                <p className="errorMessage">{messageErrorForm}</p>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">StoreCode</Form.Label>
                  <Form.Control
                    type="number"
                    value={state_StoreCode}
                    disabled
                  />
                </Form.Group>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Description</Form.Label>
                  <Form.Control
                    value={state_Description}
                    type="text"
                    disabled
                  />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Date Create</Form.Label>
                  <Form.Control disabled type="date" value={state_DateCreate} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">
                    Last Update Date
                  </Form.Label>
                  <Form.Control
                    disabled
                    type="text"
                    value={state_LastUpdateDate}
                  />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Address</Form.Label>
                  <Form.Control
                    as="textarea"
                    style={{ height: "100px" }}
                    value={state_Address}
                    type="text"
                    disabled
                  />
                </Form.Group>
              </div>
            ))}
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
      {/* DiaLog Loading Data */}
      {loading === true && <LoadingModal />}
    </Container>
  );
}

export default Store;
