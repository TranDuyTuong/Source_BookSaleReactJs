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
import ChangePriceItemMaster from "../Pages/ChangePriceItemMaster";
import Author from "../Pages/Author";
import BankSuport from "../Pages/BankSuport";
import CategoryItemMaster from "../Pages/CategoryItemMaster";
import City from "../Pages/City";
import District from "../Pages/District";
import Gender from "../Pages/Gender";
import ImageItemMaster from "../Pages/ImageItemMaster";
import PairDiscount from "../Pages/PairDiscount";
import PaymentMethod from "../Pages/PaymentMethod";
import QuantityDiscount from "../Pages/QuantityDiscount";
import SpecialDiscount from "../Pages/SpecialDiscount";

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
            <Route
              path="/changepriceitemmaster"
              element={<ChangePriceItemMaster />}
            ></Route>
            <Route path="/author" element={<Author />}></Route>
            <Route path="/banksuport" element={<BankSuport />}></Route>
            <Route
              path="/categoryitemmaster"
              element={<CategoryItemMaster />}
            ></Route>
            <Route path="/city" element={<City />}></Route>
            <Route path="/district" element={<District />}></Route>
            <Route path="/gender" element={<Gender />}></Route>
            <Route
              path="/imageitemmaster"
              element={<ImageItemMaster />}
            ></Route>
            <Route path="/pairdiscount" element={<PairDiscount />}></Route>
            <Route path="/paymentmethod" element={<PaymentMethod />}></Route>
            <Route
              path="/quantitydiscount"
              element={<QuantityDiscount />}
            ></Route>
            <Route
              path="/specialdiscount"
              element={<SpecialDiscount />}
            ></Route>
          </Routes>
        </Col>
      </Row>
    </Container>
  );
}

export default CommonPage;
