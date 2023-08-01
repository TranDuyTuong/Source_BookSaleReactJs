import React, { useEffect, useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import "../Styles/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSignInAlt,
  faTriangleExclamation,
} from "@fortawesome/free-solid-svg-icons";
import {
  ValidationInput,
  RemoveCookies,
  LenghtPassword,
  ConcatStringEvent,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin, FistCode, EventLogin } from "../ObjectCommon/EventCommon";
import { LoginUser } from "../ObjectCommon/Object";

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
  const onSubmitHander = (e) => {
    // Call function check null email and password
    var ischeckNull = ValidationInput(email, password);

    // Icon Error
    var iconError = "<FontAwesomeIcon icon={" + faTriangleExclamation + "} />";

    if (ischeckNull.Status === false) {
      setError(iconError + " " + ischeckNull.Message);
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
        setError(iconError + " " + isCheckLenghtPassword.Message);
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
        var result = LoginUser;
        result.Email = email;
        result.Password = password;
        result.RememberMe = true;
        result.EventCode = stringEvent;

        // Conver Object to json
        var jsonresult = JSON.stringify(result);
        // Call Api
      }
    }
  };

  return (
    <Container>
      <Row>
        {/* nofitication message error when submit */}
        <p className="errorMessage">{error}</p>

        <Form className="form" onSubmit={onSubmitHander}>
          <p className="title"> Login System </p>
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
            <Button className="btn-login" variant="primary" type="submit">
              <FontAwesomeIcon icon={faSignInAlt} /> Login
            </Button>
          </p>
        </Form>
      </Row>
    </Container>
  );
}

export default Login;
