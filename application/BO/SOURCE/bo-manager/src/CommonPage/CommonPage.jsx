import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import MenuCommon from "./MenuCommon";

// Main Page
function CommonPage() {
  return (
    <Container fluid>
      <Row>
        <col xs={3}>
          <MenuCommon></MenuCommon>
        </col>
        <col>content</col>
      </Row>
    </Container>
  );
}

export default CommonPage;
