import React, { useEffect, useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import jwt_decode from "jwt-decode";
import "../Styles/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSignInAlt } from "@fortawesome/free-solid-svg-icons";
import {
  ValidationInput,
  RemoveCookies,
  LenghtPassword,
  ConcatStringEvent,
  CreateCookies,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin, FistCode, EventLogin } from "../ObjectCommon/EventCommon";
import { LoginUser, ResultLogin } from "../ObjectCommon/Object";
import { postDataLoginAPI } from "../ApiLablary/LoginApi";
import { messageCreateCookieFail } from "../MessageCommon/Message";

// Main Function
function Login() {
  // Title Page
  document.title = "Login System";

  // Reload Page
  useEffect(() => {
    // Focus input email
    document.getElementById("idEmail").focus();
    // Clear Local Storage
    localStorage.clear();
    // Remove Cookie Curent
    RemoveCookies(UserLogin);
    // Clear time check ExpirationDate
    clearInterval(1000);
  }, []);

  // Setting Email And Password
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  // Submit Hander form
  const onSubmitHander = async (e) => {
    // Call function check null email and password
    var ischeckNull = ValidationInput(email, password);

    if (ischeckNull.Status === false) {
      setError(ischeckNull.Message);
      // Check Type Error
      switch (ischeckNull.Type) {
        case 1:
          // Forcus Email Input
          document.getElementById("idEmail").focus();
          document.getElementById("idEmail").style.border = "3px solid red";
          document.getElementById("idPassword").style.border =
            "3px solid rgba(43, 121, 236, 0.658)";
          break;

        case 2:
          // Forcus Password Imput
          document.getElementById("idPassword").focus();
          document.getElementById("idPassword").style.border = "3px solid red";
          document.getElementById("idEmail").style.border =
            "3px solid rgba(43, 121, 236, 0.658)";
          break;

        default:
          break;
      }
      e.preventDefault();
    } else {
      // Check Lenght password
      var isCheckLenghtPassword = LenghtPassword(password);

      if (isCheckLenghtPassword === false) {
        setError(isCheckLenghtPassword.Message);
        document.getElementById("idPassword").focus();
        document.getElementById("idPassword").style.border = "3px solid red";
        document.getElementById("idEmail").style.border =
          "3px solid rgba(43, 121, 236, 0.658)";
        document.getElementById("idPassword").value("");
        e.preventDefault();
      } else {
        // Concat string event
        var stringEvent = ConcatStringEvent(FistCode, EventLogin);

        // Set Infomation Login
        var info = LoginUser;
        info.Email = email;
        info.Password = password;
        info.RememberMe = true;
        info.EventCode = stringEvent;
        // Call Api
        var result = await fetchData(info);
        // Check result
        if (result.Status === false) {
          setError(result.Message);
        } else {
          var queryString = window.location.origin;
          window.location.href = queryString + "/home";
        }
        e.preventDefault();
      }
    }
  };

  return (
    <Container>
      <Row>
        {/* nofitication message error when submit */}
        <p className="errorMessage">{error}</p>

        <Form className="form">
          <p className="titleLogin"> Login System </p>
          <Form.Group className="mb-3">
            <Form.Control
              className="input-title"
              type="email"
              placeholder="Enter email ..."
              id="idEmail"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Control
              className="input-title"
              type="password"
              placeholder="Password ..."
              id="idPassword"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </Form.Group>

          <p className="alinebutton">
            <Button
              className="btn-login"
              variant="primary"
              type="button"
              onClick={onSubmitHander}
            >
              <FontAwesomeIcon icon={faSignInAlt} /> Login
            </Button>
          </p>
        </Form>
      </Row>
    </Container>
  );
}

// Call Api
const fetchData = async (info) => {
  var login = new FormData();
  login.append("Email", info.Email);
  login.append("Password", info.Password);
  login.append("RememberMe", info.RememberMe);
  login.append("EventCode", info.EventCode);
  const data = await postDataLoginAPI(login);
  // check result login
  var result = ResultLogin;

  if (data.Status === true) {
    // Read Value Token
    const tokenValue = jwt_decode(data.Token);

    // Create Cookie for Employer Login save in local
    var cookieResult = CreateCookies(UserLogin, data.Token);

    if (cookieResult === true) {
      // Create Success save infomation Employer into Local Storage
      window.localStorage.setItem("Employer", tokenValue.employerName);
      window.localStorage.setItem("RoleEmployer", tokenValue.roleID);
      window.localStorage.setItem("DescriptionRole", tokenValue.nameRole);
      window.localStorage.setItem("ExpirationDate", tokenValue.experiedDate);
      window.localStorage.setItem("UserID", tokenValue.userID);
      // Login Success
      result.Status = data.Status;
    } else {
      // Show Message Error
      result.Status = false;
      result.Message = messageCreateCookieFail;
    }
  } else {
    // Login Fail
    result.Status = data.Status;
    result.Message = data.Message;
  }

  return result;
};

export default Login;
