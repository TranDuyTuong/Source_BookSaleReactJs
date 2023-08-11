import React, { useState, useEffect } from "react";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
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
  // Get Staff Login
  const [sessionExpiration, getSessionExpiration] = useState("");
  const [roleName, getRoleName] = useState("");
  const [userName, getUserName] = useState("");

  useEffect(() => {
    getSessionExpiration(window.localStorage.getItem("ExpirationDate"));
    getRoleName(window.localStorage.getItem("DescriptionRole"));
    getUserName(window.localStorage.getItem("Employer"));
  }, []);

  return (
    <div className="header">
      <Row>
        <Col xs={3}>
          <p className="title">BOOK MANAGEMENT</p>
        </Col>
        <Col>
          <p className="infoUser">
            <span className="positionInfo">
              <FontAwesomeIcon icon={faClock} /> Phiên Hết Hạn:{" "}
              {sessionExpiration}
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faRectangleList} /> Cấp Độ: {roleName}
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faUser} /> {userName}
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
