import React, { useState, useEffect } from "react";
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
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/Area.css";
import { HandleSeachArea, HandleConfirmArea } from "../ApiLablary/AreaApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventHome,
  EventConfirmArea,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";
import { Create, Update, Delete, Revert } from "../Contants/DataContant";
import {
  titleCreate,
  messageNulAreaCode,
  messageNullDescriptionAreaCode,
  titleUpdate,
  messageAreaCodealreadyexist,
  titleDelete,
  messageErrorNotFindAreaCode,
  titleRevert,
  messageConfirmSuccess,
} from "../MessageCommon/Message";
import LoadingModal from "../CommonPage/LoadingCommon";

// Style Css for Table
const tdStyle = {
  color: "gray",
  "text-decoration": "line-through #ff0000",
};

// Main Function
function Area() {
  // dispatch reducer
  const dispatch = useDispatch();

  // Show Dialog Add, Update, Confirm
  const [show, setShow] = useState(false);

  // Show DiaLod Loading
  const [showLoadingDiaLog, SetShowLoadingDiaLog] = useState(false);

  // TypeOf Dialog Setting
  const [typeOfDialog, setTypeOfDialog] = useState();

  // Set Title DiaLog
  const [titleDialog, setDialog] = useState();

  // seach
  const [seachArea, setSeachArea] = useState("");

  // message Error
  const [messageError, setMessageError] = useState("");

  // Area Form
  const [areaeCode, setAreaCode] = useState("");
  const [description, setDescription] = useState("");
  const [messageErrorForm, setMessageErrorForm] = useState("");
  const [oldTypeOf, setOldTypeOf] = useState("");

  // Call list area in Redux
  const listAreaResult = useSelector((item) => item.areaData.ListArea);

  useEffect(() => {
    // Setting Title Page
    document.title = "Area";
    // disabled button Confirm
    document.getElementById("btn_Confirm").disabled = true;
  }, []);

  // Handle Seach Area
  const HandleSeachAreaUI = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventHome);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalArea", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", seachArea);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListArea", []);

    // Handle Call Api Seach Area
    var result = await HandleSeachArea(formData);
    if (result.Status === false) {
      // Seach Fail
      setMessageError(result.MessageError);
    } else {
      // Save Area List In To Redux
      dispatch(AreaReducer.actions.SeachArea(result.ListArea));
      // Seach Success
      setMessageError(result.MessageError);
    }
  };

  // Handle Create Area
  const HandleAddAreaUI = (e) => {
    setTypeOfDialog(Create);
    setDialog(titleCreate);
    setShow(true);
  };
  // Handle Close DiaLog
  const handleCloseDiaLogUI = (e) => {
    setAreaCode("");
    setDescription("");
    setMessageErrorForm("");
    setShow(false);
  };

  // Handle Update Area
  const HandleUpdateAreaUI = (areaCode, description) => {
    setAreaCode(areaCode);
    setDescription(description);
    setTypeOfDialog(Update);
    setDialog(titleUpdate);
    setShow(true);
  };

  // Handle Delete Area
  const HandleDeleteAreaUI = (areaCode) => {
    // Find area want delete in ListArea
    const area = listAreaResult.find((item) => item.AreaCode === areaCode);
    if (area !== undefined) {
      // Find area
      setOldTypeOf(area.TypeOf);
      setAreaCode(area.AreaCode);
      setDescription(area.Description);
      setTypeOfDialog(Delete);
      setDialog(titleDelete);
      setShow(true);
    } else {
      alert(messageErrorNotFindAreaCode);
    }
  };

  // Handle Revert Area Delete
  const HandleRevertAreaUI = (areaCode) => {
    // Find area want revert affter delete in ListArea
    const area = listAreaResult.find((item) => item.AreaCode === areaCode);
    if (area !== undefined) {
      // Find area
      setOldTypeOf(null);
      setAreaCode(area.AreaCode);
      setDescription(area.Description);
      setTypeOfDialog(Revert);
      setDialog(titleRevert);
      setShow(true);
    } else {
      alert(messageErrorNotFindAreaCode);
    }
  };

  // Handle Confirm List Area
  const HandleConfirmUI = async (e) => {
    // Show dialog Loading
    SetShowLoadingDiaLog(true);

    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventConfirmArea);
    // Set List Area Have Update
    var listConfirmArea = [];
    for (var i = 0; listAreaResult.length > i; i++) {
      switch (listAreaResult[i].TypeOf) {
        case Create:
          var c_areaData = {
            CompanyCode: CompanyCode,
            AreaCode: listAreaResult[i].AreaCode,
            Description: listAreaResult[i].Description,
            TypeOf: Create,
            OldType: null,
          };
          listConfirmArea.push(c_areaData);
          break;
        case Update:
          var u_areaData = {
            CompanyCode: CompanyCode,
            AreaCode: listAreaResult[i].AreaCode,
            Description: listAreaResult[i].Description,
            TypeOf: Update,
            OldType: null,
          };
          listConfirmArea.push(u_areaData);
          break;
        case Delete:
          var d_areaData = {
            CompanyCode: CompanyCode,
            AreaCode: listAreaResult[i].AreaCode,
            Description: listAreaResult[i].Description,
            TypeOf: Delete,
            OldType: null,
          };
          listConfirmArea.push(d_areaData);
          break;
        default:
          break;
      }
    }
    var converArrayToJsonArea = JSON.stringify(listConfirmArea);
    // Setting Data Confirm Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalArea", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", converArrayToJsonArea);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListArea", []);
    // Handle Call Api Confirm Area
    var result = await HandleConfirmArea(formData);

    // Hid Dialog modal Loading
    SetShowLoadingDiaLog(false);

    if (result.Status === true) {
      alert(messageConfirmSuccess);
      // Set list Area In Redux is []
      dispatch(AreaReducer.actions.SeachArea([]));
    } else {
      setMessageError(result.MessageError);
    }
  };

  // Handle Submit
  const HandleSubmitDiaLogUI = (e) => {
    setMessageErrorForm("");
    // Check Null AreaCode
    if (areaeCode == null || areaeCode === "" || areaeCode === undefined) {
      setMessageErrorForm(messageNulAreaCode);
      document.getElementById("txtFocusAreaCode").focus();
      return;
    }
    // Check Null Description
    if (
      description == null ||
      description === "" ||
      description === undefined
    ) {
      setMessageErrorForm(messageNullDescriptionAreaCode);
      document.getElementById("txtFocusDescription").focus();
      return;
    }

    // Add area into reducer
    switch (typeOfDialog) {
      case Create:
        // Create
        var createArea = {
          CompanyCode: CompanyCode,
          AreaCode: areaeCode,
          Description: description,
          TypeOf: Create,
          OldType: null,
        };
        // Check AreaCode exist in list area current
        const areaCodeExist = listAreaResult.find(
          (item) => item.AreaCode === createArea.AreaCode
        );
        if (areaCodeExist !== undefined) {
          // Find areacode in list area
          setAreaCode("");
          setDescription("");
          setMessageErrorForm(messageAreaCodealreadyexist);
          document.getElementById("txtFocusAreaCode").focus();
          return;
        } else {
          // Add Area into List Area of Redux
          dispatch(AreaReducer.actions.AddArea(createArea));
        }
        break;
      case Update:
        // Update
        var updateArea = {
          CompanyCode: CompanyCode,
          AreaCode: areaeCode,
          Description: description,
          TypeOf: Update,
          OldType: null,
        };
        // Update Area into List Area of Redux
        dispatch(AreaReducer.actions.UpdateArea(updateArea));
        break;
      case Delete:
        // Delete
        var deleteArea = {
          AreaCode: areaeCode,
          TypeOf: Delete,
          OldType: oldTypeOf,
        };
        // Delete Area into List Area of Redux
        dispatch(AreaReducer.actions.DeleteArea(deleteArea));
        break;
      case Revert:
        // Revert
        var revertArea = {
          AreaCode: areaeCode,
        };
        // Revert Area into List Area of redux
        dispatch(AreaReducer.actions.RevertArea(revertArea));
        break;
      default:
        break;
    }
    setAreaCode("");
    setDescription("");
    setMessageErrorForm("");
    setShow(false);
    // Activer button Confirm
    document.getElementById("btn_Confirm").disabled = false;
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">Area</h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" controlId="validationCustom01">
                <Form.Control
                  type="text"
                  placeholder="Area Code..."
                  onChange={(e) => setSeachArea(e.target.value)}
                  value={seachArea}
                />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="button" onClick={() => HandleSeachAreaUI()}>
                  <FontAwesomeIcon icon={faSearch} /> Seach
                </Button>
              </Form.Group>
              <Form.Group as={Col} md="7" controlId="validationCustom02">
                <p className="btnMain">
                  <Button
                    variant="primary"
                    className="btnOption"
                    onClick={() => HandleAddAreaUI()}
                  >
                    <FontAwesomeIcon icon={faPlusSquare} /> Add
                  </Button>
                  <Button
                    variant="success"
                    className="btnOption"
                    id="btn_Confirm"
                    onClick={() => HandleConfirmUI()}
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
                  <th className="firsColum">CompanyCode</th>
                  <th>AreaCore</th>
                  <th>Description</th>
                  <th>Status</th>
                  <th className="lastColum">Option</th>
                </tr>
              </thead>
              <tbody>
                {listAreaResult.map(
                  (item) =>
                    (item.TypeOf === Create && (
                      <tr key={item.AreaCode} className="trChildItem">
                        <td className="firsColum" style={{ color: "blue" }}>
                          {item.CompanyCode}
                        </td>
                        <td style={{ color: "blue" }}>{item.AreaCode}</td>
                        <td style={{ color: "blue" }}>{item.Description}</td>
                        <td style={{ color: "blue" }}>{Create}</td>
                        <td className="lastColum">
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={(e) =>
                              HandleUpdateAreaUI(
                                item.AreaCode,
                                item.Description
                              )
                            }
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={(e) => HandleDeleteAreaUI(item.AreaCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === Update && (
                      <tr key={item.AreaCode} className="trChildItem">
                        <td className="firsColum" style={{ color: "red" }}>
                          {item.CompanyCode}
                        </td>
                        <td style={{ color: "red" }}>{item.AreaCode}</td>
                        <td style={{ color: "red" }}>{item.Description}</td>
                        <td style={{ color: "red" }}>{Update}</td>
                        <td className="lastColum">
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={(e) =>
                              HandleUpdateAreaUI(
                                item.AreaCode,
                                item.Description
                              )
                            }
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={(e) => HandleDeleteAreaUI(item.AreaCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === Delete && (
                      <tr key={item.AreaCode} className="trChildItem">
                        <td className="firsColum" style={tdStyle}>
                          {item.CompanyCode}
                        </td>
                        <td style={tdStyle}>{item.AreaCode}</td>
                        <td style={tdStyle}>{item.Description}</td>
                        <td style={tdStyle}>{Delete}</td>
                        <td style={tdStyle}>
                          <Button
                            variant="secondary"
                            className="btnOption"
                            onClick={(e) => HandleRevertAreaUI(item.AreaCode)}
                          >
                            <FontAwesomeIcon icon={faClockRotateLeft} /> Revert
                          </Button>
                        </td>
                      </tr>
                    )) ||
                    (item.TypeOf === null && (
                      <tr key={item.AreaCode} className="trChildItem">
                        <td className="firsColum">{item.CompanyCode}</td>
                        <td>{item.AreaCode}</td>
                        <td>{item.Description}</td>
                        <td></td>
                        <td className="lastColum">
                          <Button
                            variant="warning"
                            className="btnOption"
                            onClick={(e) =>
                              HandleUpdateAreaUI(
                                item.AreaCode,
                                item.Description
                              )
                            }
                          >
                            <FontAwesomeIcon icon={faEdit} /> Update
                          </Button>
                          <Button
                            variant="danger"
                            className="btnOption"
                            onClick={(e) => HandleDeleteAreaUI(item.AreaCode)}
                          >
                            <FontAwesomeIcon icon={faTrashAlt} /> Delete
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
                <Form.Label className="labelForm">CompanyCode</Form.Label>
                <Form.Control disabled type="text" value={CompanyCode} />
              </Form.Group>

              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">AreaCode *</Form.Label>
                <Form.Control
                  type="text"
                  value={areaeCode}
                  id="txtFocusAreaCode"
                  onChange={(e) => setAreaCode(e.target.value)}
                  placeholder="Enter AreaCode..."
                />
              </Form.Group>

              <Form.Group as={Col} md="12">
                <Form.Label className="labelForm">Description *</Form.Label>
                <Form.Control
                  type="text"
                  id="txtFocusDescription"
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                  placeholder="Enter Description..."
                />
              </Form.Group>
            </div>
          )) ||
            (typeOfDialog === Update && (
              <div>
                <p className="errorMessage">{messageErrorForm}</p>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">CompanyCode</Form.Label>
                  <Form.Control disabled type="text" value={CompanyCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">AreaCode *</Form.Label>
                  <Form.Control disabled type="text" value={areaeCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Description *</Form.Label>
                  <Form.Control
                    type="text"
                    id="txtFocusDescription"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    placeholder="Enter Description..."
                  />
                </Form.Group>
              </div>
            )) ||
            (typeOfDialog === Delete && (
              <div>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">CompanyCode</Form.Label>
                  <Form.Control disabled type="text" value={CompanyCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">AreaCode *</Form.Label>
                  <Form.Control disabled type="text" value={areaeCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Description *</Form.Label>
                  <Form.Control disabled type="text" value={description} />
                </Form.Group>
              </div>
            )) ||
            (typeOfDialog === Revert && (
              <div>
                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">CompanyCode</Form.Label>
                  <Form.Control disabled type="text" value={CompanyCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">AreaCode *</Form.Label>
                  <Form.Control disabled type="text" value={areaeCode} />
                </Form.Group>

                <Form.Group as={Col} md="12">
                  <Form.Label className="labelForm">Description *</Form.Label>
                  <Form.Control disabled type="text" value={description} />
                </Form.Group>
              </div>
            ))}
        </Modal.Body>
        <Modal.Footer className="settingBackround">
          <Button variant="secondary" onClick={(e) => handleCloseDiaLogUI()}>
            Close
          </Button>
          <Button variant="primary" onClick={(e) => HandleSubmitDiaLogUI()}>
            <FontAwesomeIcon icon={faPlusSquare} /> Ok
          </Button>
        </Modal.Footer>
      </Modal>
      {showLoadingDiaLog && <LoadingModal />}
    </Container>
  );
}

export default Area;
