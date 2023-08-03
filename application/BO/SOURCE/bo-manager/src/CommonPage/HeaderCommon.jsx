import React, { useState } from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Nav from "react-bootstrap/Nav";
import "../Styles/HeaderCommon.css";
import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faClock,
  faRectangleList,
  faUser,
  faRightFromBracket,
} from "@fortawesome/free-solid-svg-icons";

// Main function
function HeaderCommon() {
  return (
    <div className="header">
      <Row>
        <Col xs={3}>
          <p className="title">BOOK MANAGEMENT</p> sss
        </Col>
        <Col>
          <p className="infoUser">
            <span className="positionInfo">
              <FontAwesomeIcon icon={faClock} /> Phiên Hết Hạn: 07/23/2023
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faRectangleList} /> Cấp Độ: Admin
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faUser} /> Nguyen Van A
            </span>
            <span className="positionInfo">
              <Button variant="outline-light">
                <FontAwesomeIcon icon={faRightFromBracket} /> SignOut
              </Button>
            </span>
          </p>
        </Col>
      </Row>
    </div>
  );
}

export default HeaderCommon;
