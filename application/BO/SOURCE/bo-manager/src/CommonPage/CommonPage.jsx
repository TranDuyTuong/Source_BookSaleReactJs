import React from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { Routes, Route } from "react-router-dom";
import HeaderCommon from "./HeaderCommon";
import Home from "../Pages/Home";
import Area from "../Pages/Area";
import Store from "../Pages/Store";
import ItemMaster from "../Pages/ItemMaster";
import Menu from "../Pages/Menu";
import CreateItemMaster from "../Pages/CreateItemMaster";
import UpdateItemMaster from "../Pages/UpdateItemMaster";

// Main Page
function CommonPage() {
  return (
    <Container fluid>
      <HeaderCommon></HeaderCommon>
      <Row>
        <Col>
          <Routes>
            <Route path="/home" element={<Home />}></Route>
            <Route path="/area" element={<Area />}></Route>
            <Route path="/store" element={<Store />}></Route>
            <Route path="/itemmaster" element={<ItemMaster />}></Route>
            <Route path="/menu" element={<Menu />}></Route>
            <Route
              path="/createitemmaster"
              element={<CreateItemMaster />}
            ></Route>
            <Route
              path="/updateitemmaster"
              element={<UpdateItemMaster />}
            ></Route>
          </Routes>
        </Col>
      </Row>
    </Container>
  );
}

export default CommonPage;
