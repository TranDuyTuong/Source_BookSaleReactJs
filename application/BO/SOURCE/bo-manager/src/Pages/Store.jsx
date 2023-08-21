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
} from "../MessageCommon/Message";
import LoadingModal from "../CommonPage/LoadingCommon";

// Main Function
function Store() {
  useEffect(() => {
    // Setting Title Page
    document.title = "Store";
  }, []);

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
                <Form.Control type="text" placeholder="Store Code..." />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="button">
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
          <p className="notification"></p>
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
            </Table>
          </div>
        </Col>
      </Row>
      {/* DiaLog show Add, update, delete, Confirm */}
    </Container>
  );
}

export default Store;
