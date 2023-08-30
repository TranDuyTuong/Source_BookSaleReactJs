import React, { useState, useEffect, useRef } from "react";
import "../Styles/Home.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import InputGroup from "react-bootstrap/InputGroup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faBook,
  faPlus,
  faPenToSquare,
  faCopy,
  faTags,
  faEye,
  faSearch,
  faSquareCheck,
  faFileArrowDown,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/ItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetAllStore,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventInitializaItemMaster,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
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
} from "../MessageCommon/Message";
import LoadingModal from "../CommonPage/LoadingCommon";

// Main Function
function ItemMaster() {
  const ref_btnDetail = useRef(null);
  const ref_btnUpdate = useRef(null);
  const ref_btnCopy = useRef(null);
  const ref_btnUpdatePrice = useRef(null);
  const ref_btnDowload = useRef(null);
  const ref_btnConfirm = useRef(null);
  // Show Store Select
  const [state_ListStore, SetListSotre] = useState([]);
  // Message Error
  const [state_MessageError, SetMessageError] = useState("");

  useEffect(() => {
    // Setting Title Page
    document.title = "Item Maters";
    // Display button when initialization data
    ref_btnDetail.current.disabled = true;
    ref_btnUpdate.current.disabled = true;
    ref_btnCopy.current.disabled = true;
    ref_btnUpdatePrice.current.disabled = true;
    ref_btnDowload.current.disabled = true;
    ref_btnConfirm.current.disabled = true;
    // Initializa Item Master, get all store
    async function InitializaData() {
      // Get Token
      var token = GetCookies(UserLogin);
      // Get EventCode
      var eventCode = ConcatStringEvent(FistCode, EventInitializaItemMaster);

      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);
      formData.append("MessageError", null);
      formData.append("Status", true);
      formData.append("CompanyCode", CompanyCode);
      // Call Api Initializa Data
      const response = await HandleGetAllStore(formData);
      if (response.Status === true) {
        SetListSotre(response.ListStore);
      } else {
        SetMessageError(response.MessageError);
      }
    }
    InitializaData();
  }, []);

  // Handle Select Store
  const HandleSelectStore = (e) => {};

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <FontAwesomeIcon icon={faBook} /> Item Master
      </h3>
      <Row>
        <Col xs={3}>
          <InputGroup className="mb-3 inputSeach">
            <Form.Control
              placeholder="Item code..."
              aria-describedby="basic-addon2"
            />
            <Button variant="primary" id="button-addon2">
              <FontAwesomeIcon icon={faSearch} /> Seach
            </Button>
          </InputGroup>
        </Col>
        <Col xs={2}>
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
        </Col>
        <Col xs={7}>
          <p className="aline_settingHeader">
            <Button
              variant="primary"
              className="btn_setting"
              ref={ref_btnUpdatePrice}
            >
              <FontAwesomeIcon icon={faTags} /> Update Price
            </Button>
            <Button
              variant="primary"
              className="btn_setting"
              ref={ref_btnDowload}
            >
              <FontAwesomeIcon icon={faFileArrowDown} /> Dowload
            </Button>
          </p>
        </Col>
      </Row>
      <p className="messageError">{state_MessageError}</p>
      <Row>
        <Col>
          <div className="customtableItemMaster">
            <Table bordered hover>
              <thead>
                <tr>
                  <th>Item Code</th>
                  <th>Apply Date</th>
                  <th>Description</th>
                  <th>PriceOrigin</th>
                  <th>priceSale</th>
                  <th>Quantity</th>
                  <th>Status</th>
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
        <Button variant="danger" className="btn_setting" ref={ref_btnDetail}>
          <FontAwesomeIcon icon={faEye} /> Detail
        </Button>
        <Button variant="warning" className="btn_setting" ref={ref_btnUpdate}>
          <FontAwesomeIcon icon={faPenToSquare} /> Update
        </Button>
        <Button variant="info" className="btn_setting" ref={ref_btnCopy}>
          <FontAwesomeIcon icon={faCopy} /> Copy
        </Button>
        <Button variant="success" className="btn_setting" ref={ref_btnConfirm}>
          <FontAwesomeIcon icon={faSquareCheck} /> Confirm
        </Button>
      </p>
    </Container>
  );
}

export default ItemMaster;
