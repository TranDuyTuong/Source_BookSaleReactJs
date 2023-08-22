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
  faStore,
  faEye,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/Area.css";
import { HandleSeachStore } from "../ApiLablary/StoreApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventSeachStore,
  EventConfirmArea,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { StoreReducer } from "../ReduxCommon/ReducerCommon/ReducerStore";
import { Create, Update, Delete, Revert } from "../Contants/DataContant";
import LoadingModal from "../CommonPage/LoadingCommon";
import moment from "moment";

// Main Function
function Store() {
  // dispatch reducer
  const dispatch = useDispatch();
  // Call list area in Redux
  const listStoreResult = useSelector((item) => item.storeData.ListStore);

  // State Seach Store
  const [seachStore, setSeachStore] = useState("");
  const [messageError, setMessageError] = useState("");

  useEffect(() => {
    // Setting Title Page
    document.title = "Store";
    var datess = new Date("2023-08-20T16:20:29.2938759");
    alert(moment(datess).format("YYYY-MM-DD"));
  }, []);

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
      result.ListStore.forEach(function (fruit) {
        alert(fruit.DateCreate); // Apple, Orange, Banna, Mango
      });
      // Save Store List In To Redux
      //dispatch(StoreReducer.actions.SeachStore(result.ListStore));
      // Seach Success
      setMessageError(result.MessageError);
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
                  <Button variant="primary" className="btnOption">
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
                        <td style={{ color: "blue" }}>{item.StoreCode}</td>
                        <td style={{ color: "blue" }}>{item.Description}</td>
                        <td style={{ color: "blue" }}>{item.DateCreate}</td>
                        <td style={{ color: "blue" }}>{item.LastUpdateDate}</td>
                        <td style={{ color: "blue" }}>{Create}</td>
                        <td>
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
                        <td style={{ color: "red" }}>{item.StoreCode}</td>
                        <td style={{ color: "red" }}>{item.Description}</td>
                        <td style={{ color: "red" }}>{item.DateCreate}</td>
                        <td style={{ color: "red" }}>{item.LastUpdateDate}</td>
                        <td style={{ color: "red" }}>{Update}</td>
                        <td>
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
                        <td>{item.StoreCode}</td>
                        <td>{item.Description}</td>
                        <td>{item.DateCreate}</td>
                        <td>{item.LastUpdateDate}</td>
                        <td>{Delete}</td>
                        <td>
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
                        <td>{item.StoreCode}</td>
                        <td>{item.Description}</td>
                        <td>{item.DateCreate}</td>
                        <td>{item.LastUpdateDate}</td>
                        <td></td>
                        <td>
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
    </Container>
  );
}

export default Store;
