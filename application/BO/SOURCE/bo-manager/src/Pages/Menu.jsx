import React, { useEffect, useState } from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import {
  ListButtonMain,
  ListButtonFunction,
  ListButtonSystem,
} from "../Contants/DataContant";
import { useNavigate } from "react-router-dom";
import "../Styles/Menu.css";
import { HandleValidationRole } from "../ApiLablary/ValidationApi";
import { FistCode, EventMenu } from "../ObjectCommon/EventCommon";
import {
  GetCookies,
  ConcatStringEvent,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";

// Main Function
function Menu() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);

  // Message Error Limit Role User
  const [messageLimitRole, setMessageLimitRole] = useState("");

  // Readloading page
  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventMenu);

      // Set Object check Token Data
      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);

      // Check User Role
      var resultCheckRole = await HandleCheckRoleStaff(formData);
      if (resultCheckRole.Status === false) {
        // var OldURL = window.localStorage.getItem("oldURL");
        alert(resultCheckRole.Message);
        // User Don't have Role
        if (OldUrldata[0] === window.location.origin) {
          // redirect to Login Pgae
          window.location.href = window.location.origin;
        } else {
          // redirect to page before
          navigate(OldUrldata);
        }
      } else {
        // Reomve Old  Url
        window.localStorage.removeItem("oldURL");

        // Create New Url
        dispatch(OldURLReducer.actions.DeleteURL());
        dispatch(OldURLReducer.actions.AddUrl("/menu"));
        window.localStorage.setItem("oldURL", "/menu");

        // Setting Title Page
        document.title = "Menu";
      }
    };
    CheckTokenAndRole();
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

    if (result.Status === false) {
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
