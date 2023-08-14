import React, { useState, useEffect } from "react";
import "../Styles/Home.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
import "../Styles/Area.css";
import { messageErrorMoreThan100Recol } from "../MessageCommon/Message";

// Main Function
function Area() {
  useEffect(() => {
    // Setting Title Page
    document.title = "Area";
  }, []);
  const hanldeclick1 = (e) => {
    alert("ok 1");
  };
  const hanldeclick2 = (e) => {
    alert("ok 2");
  };
  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">Area</h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="4" controlId="validationCustom01">
                <Form.Control required type="text" placeholder="Area Code..." />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="submit">
                  <FontAwesomeIcon icon={faSearch} /> Seach
                </Button>
              </Form.Group>
            </Row>
          </Form>
          <p className="notification">{messageErrorMoreThan100Recol}</p>
        </Col>
      </Row>
      <Row>
        <Col>
          <Table bordered hover>
            <thead>
              <tr className="headerarea">
                <th>#</th>
                <th>CompanyCode</th>
                <th>AreaCore</th>
                <th>Description</th>
              </tr>
            </thead>
            <tbody>
              <tr onClick={hanldeclick1}>
                <td>1</td>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
              </tr>
              <tr onClick={hanldeclick2}>
                <td>2</td>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
              </tr>
            </tbody>
          </Table>
        </Col>
      </Row>
    </Container>
  );
}

export default Area;
