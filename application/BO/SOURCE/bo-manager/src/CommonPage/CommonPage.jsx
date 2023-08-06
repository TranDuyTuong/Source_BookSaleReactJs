import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import MenuCommon from "./MenuCommon";
import Home from "../Pages/Home";
import { Routes, Route } from "react-router-dom";
import HeaderCommon from "./HeaderCommon";

// Main Page
function CommonPage() {
  return (
    <Container fluid>
      <HeaderCommon></HeaderCommon>
      <Row>
        <Col xs={2}>
          <MenuCommon></MenuCommon>
        </Col>
        <Col>
          <Routes>
            <Route path="/home" element={<Home />}></Route>
          </Routes>
        </Col>
      </Row>
    </Container>
  );
}

export default CommonPage;