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
import { FistCode, EventHome } from "../ObjectCommon/EventCommon";
import { CompanyCode } from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";
import { Create } from "../Contants/DataContant";

// Main Function
function Area() {
  // dispatch reducer
  const dispatch = useDispatch();

  // Show Dialog Add, Update, Confirm
  const [show, setShow] = useState(false);

  // TypeOf Dialog Setting
  const [typeOfDialog, setTypeOfDialog] = useState();

  // seach
  const [seachArea, setSeachArea] = useState("");

  // message Error
  const [messageError, setMessageError] = useState("");

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
    setShow(true);
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">Area</h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="4" controlId="validationCustom01">
                <Form.Control
                  type="text"
                  placeholder="Area Code..."
                  onChange={(e) => setSeachArea(e.target.value)}
                  value={seachArea}
                />
              </Form.Group>
              <Form.Group as={Col} md="1" controlId="validationCustom02">
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
        <Modal.Header closeButton>
          <Modal.Title>Modal heading</Modal.Title>
        </Modal.Header>
        <Modal.Body>Woohoo, you are reading this text in a modal!</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary">Close</Button>
          <Button variant="primary">Save Changes</Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default Area;
