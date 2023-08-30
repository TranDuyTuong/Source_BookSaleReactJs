import React, { useEffect, useState } from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import {
  ListButtonMain,
  ListButtonFunction,
  ListButtonSystem,
} from "../Contants/DataContant";
import { useNavigate } from "react-router-dom";
import "../Styles/Menu.css";
import { HandleValidationRole } from "../ApiLablary/ValidationApi";
import { FistCode } from "../ObjectCommon/EventCommon";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";

// Main Function
function Menu() {
  const navigate = useNavigate();

  // Message Error Limit Role User
  const [messageLimitRole, setMessageLimitRole] = useState("");

  // Readloading page
  useEffect(() => {
    document.title = "Menu";
  }, []);

  // Handle Redirect screen
  const HandleRedirect = async (urlRedirect, eventcode) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, eventcode);

    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    // Call Api Check Role
    const result = await HandleValidationRole(formData);

    if (result.Status === true) {
      // Use Was Limit Role
      setMessageLimitRole(result.Message);
    } else {
      // Use Not Limit Role
      navigate(urlRedirect);
    }
    return;
  };
  return (
    <Container fluid className="fixedPotionArea">
      <Row>
        <p className="errorLimitRole">{messageLimitRole}</p>
        <Col xs={4}>
          <p className="titleMenuButton">Main</p>
          {ListButtonMain.map((item) => (
            <Button
              className="buttonredirect"
              key={item.id}
              variant={item.stylebutton}
              onClick={(e) => HandleRedirect(item.buttonUrl, item.eventCode)}
            >
              {item.buttonName}
            </Button>
          ))}
        </Col>
        <Col xs={4}>
          <p className="titleMenuButton">Function</p>
          {ListButtonFunction.map((item) => (
            <Button
              className="buttonredirect"
              key={item.id}
              variant={item.stylebutton}
              onClick={(e) => HandleRedirect(item.buttonUrl, item.eventCode)}
            >
              {item.buttonName}
            </Button>
          ))}
        </Col>
        <Col xs={4}>
          <p className="titleMenuButton">System</p>
          {ListButtonSystem.map((item) => (
            <Button
              className="buttonredirect"
              key={item.id}
              variant={item.stylebutton}
              onClick={(e) => HandleRedirect(item.buttonUrl, item.eventCode)}
            >
              {item.buttonName}
            </Button>
          ))}
        </Col>
      </Row>
    </Container>
  );
}

export default Menu;
