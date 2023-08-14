import React from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { Routes, Route } from "react-router-dom";
import MenuCommon from "./MenuCommon";
import HeaderCommon from "./HeaderCommon";
import Home from "../Pages/Home";
import Area from "../Pages/Area";

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
            <Route path="/area" element={<Area />}></Route>
          </Routes>
        </Col>
      </Row>
    </Container>
  );
}

export default CommonPage;
