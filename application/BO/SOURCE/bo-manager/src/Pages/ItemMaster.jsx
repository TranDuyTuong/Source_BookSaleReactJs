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
import { faBook } from "@fortawesome/free-solid-svg-icons";
import "../Styles/Area.css";
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
  useEffect(() => {
    // Setting Title Page
    document.title = "Item Maters";
  }, []);

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <FontAwesomeIcon icon={faBook} /> Item Master
      </h3>
    </Container>
  );
}

export default ItemMaster;
