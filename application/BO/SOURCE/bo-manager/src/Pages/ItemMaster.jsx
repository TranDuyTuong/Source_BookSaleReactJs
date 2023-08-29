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
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import { CompanyCode, FistCode } from "../ObjectCommon/EventCommon";
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
  }, []);

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
          <Form.Select className="selectstore">
            <option>Select Store</option>
            <option value="1">One</option>
            <option value="2">Two</option>
            <option value="3">Three</option>
          </Form.Select>
        </Col>
        <Col xs={7}>
          <p className="alinebuttonsetting">
            <Button variant="primary" className="btn_setting">
              <FontAwesomeIcon icon={faPlus} /> Add
            </Button>
            <Button
              variant="danger"
              className="btn_setting"
              ref={ref_btnDetail}
            >
              <FontAwesomeIcon icon={faEye} /> Detail
            </Button>
            <Button
              variant="warning"
              className="btn_setting"
              ref={ref_btnUpdate}
            >
              <FontAwesomeIcon icon={faPenToSquare} /> Update
            </Button>
            <Button variant="info" className="btn_setting" ref={ref_btnCopy}>
              <FontAwesomeIcon icon={faCopy} /> Copy
            </Button>
            <Button
              variant="secondary"
              className="btn_setting"
              ref={ref_btnUpdatePrice}
            >
              <FontAwesomeIcon icon={faTags} /> Update Price
            </Button>
            <Button variant="dark" className="btn_setting" ref={ref_btnDowload}>
              <FontAwesomeIcon icon={faFileArrowDown} /> Dowload
            </Button>
            <Button
              variant="success"
              className="btn_setting"
              ref={ref_btnConfirm}
            >
              <FontAwesomeIcon icon={faSquareCheck} /> Confirm
            </Button>
          </p>
        </Col>
      </Row>
      <p className="alineStoreTitle">
        Store: <b>0001</b>
      </p>
      <p className="messageError">more than 100 recod</p>
      <Row>
        <Col>
          <div className="customtable">
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
    </Container>
  );
}

export default ItemMaster;
