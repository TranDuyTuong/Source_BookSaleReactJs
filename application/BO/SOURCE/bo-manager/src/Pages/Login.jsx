import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import "../Styles/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSignInAlt } from "@fortawesome/free-solid-svg-icons";

// Main Function
function Login() {
  // Title Page
  document.title = "Login System";

  return (
    <Container>
      <Row>
        <Form className="form">
          <p className="title"> Login System </p>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Control
              className="input-title"
              type="email"
              placeholder="Enter email ..."
            />
          </Form.Group>

          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Control
              className="input-title"
              type="password"
              placeholder="Password ..."
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
