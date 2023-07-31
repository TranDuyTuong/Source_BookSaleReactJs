import React, { useEffect, useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import "../Styles/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSignInAlt } from "@fortawesome/free-solid-svg-icons";
import { validationLogin } from "../ObjectCommon/Object";
import {
  messageNullEmail,
  messageNullPassword,
} from "../MessageCommon/Message";

// Main Function
function Login() {
  // Title Page
  document.title = "Login System";

  // Reload Page
  useEffect(() => {
    document.getElementById("idEmail").focus();
  }, []);

  // Setting Email And Password
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  // Submit Hander form
  const onSubmitHander = (e) => {
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
          break;
        case 2:
          // Forcus Password Imput
          document.getElementById("idPassword").focus();
          document.getElementById("idEmail").style.border =
            "3px solid rgba(43, 121, 236, 0.658)";
          document.getElementById("idPassword").style.border = "3px solid red";
          break;
        default:
          break;
      }
      e.preventDefault();
    } else {
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

// Validation Input
function ValidationInput(email, password) {
  validationLogin.Status = true;

  // Check Null Email
  if (email === null || email === "" || email === undefined) {
    validationLogin.Status = false;
    validationLogin.Message = messageNullEmail;
    validationLogin.Type = 1; // Email
  } else {
    // Check Null Password
    if (password === null || password === "" || password === undefined) {
      validationLogin.Status = false;
      validationLogin.Message = messageNullPassword;
      validationLogin.Type = 2; // Password
    }
  }

  return validationLogin;
}

export default Login;
