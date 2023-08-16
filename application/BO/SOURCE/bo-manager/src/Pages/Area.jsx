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
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/Area.css";
import { HandleSeachArea } from "../ApiLablary/AreaApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import { CompanyCode, FistCode, EventHome } from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";
import { Create, Update } from "../Contants/DataContant";
import {
  titleCreate,
  messageNulAreaCode,
  messageNullDescriptionAreaCode,
} from "../MessageCommon/Message";

// Main Function
function Area() {
  // dispatch reducer
  const dispatch = useDispatch();

  // Show Dialog Add, Update, Confirm
  const [show, setShow] = useState(false);

  // TypeOf Dialog Setting
  const [typeOfDialog, setTypeOfDialog] = useState();

  // Set Title DiaLog
  const [titleDialog, setDialog] = useState();

  // seach
  const [seachArea, setSeachArea] = useState("");

  // message Error
  const [messageError, setMessageError] = useState("");

  // Area Form
  const [areaeCode, setAreaCode] = useState();
  const [description, setDescription] = useState();
  const [messageErrorForm, setMessageErrorForm] = useState("");

  // Call list area in Redux
  const listAreaResult = useSelector((item) => item.areaData.ListArea);

  useEffect(() => {
    // Setting Title Page
    document.title = "Area";
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
                  <Button disabled variant="success" className="btnOption">
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
                  <th className="lastColum">Option</th>
                </tr>
              </thead>
              <tbody>
                {listAreaResult.map((item) => (
                  <tr key={item.AreaCode} className="trChildItem">
                    <td className="firsColum">{item.CompanyCode}</td>
                    <td>{item.AreaCode}</td>
                    <td>{item.Description}</td>
                    <td className="lastColum">
                      <Button variant="warning" className="btnOption">
                        <FontAwesomeIcon icon={faEdit} /> Update
                      </Button>
                      <Button variant="danger" className="btnOption">
                        <FontAwesomeIcon icon={faTrashAlt} /> Delete
                      </Button>
                    </td>
                  </tr>
                ))}
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
              <Form.Group as={Col} md="4" controlId="validationCustom01">
                <Form.Label>Update</Form.Label>
                <Form.Control
                  required
                  type="text"
                  placeholder="First name"
                  defaultValue="Mark"
                />
                <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
              </Form.Group>
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
    </Container>
  );
}

export default Area;
