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
import { HandleSeachArea } from "../ApiLablary/AreaApi";
import { GetCookies, ConcatStringEvent } from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/Object";
import { FistCode, EventHome } from "../ObjectCommon/EventCommon";
import { CompanyCode } from "../ObjectCommon/EventCommon";

// Main Function
function Area() {
  // seach
  const [seachArea, setSeachArea] = useState("");
  // message Error
  const [messageError, setMessageError] = useState("");

  useEffect(() => {
    // Setting Title Page
    document.title = "Area";
  }, []);

  // Handle Seach Area
  const HandleSeachArea = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventHome);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalArea", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", seachArea);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListArea", []);

    // Handle Call Api Seach Area
    var result = await HandleSeachArea(formData);
    if (result.Status === false) {
      // Seach Fail
      setMessageError(result.MessageError);
    } else {
      // Seach Success
    }
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">Area</h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="4" controlId="validationCustom01">
                <Form.Control
                  type="text"
                  placeholder="Area Code..."
                  onChange={(e) => setSeachArea(e.target.value)}
                  value={seachArea}
                />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="button" onClick={HandleSeachArea}>
                  <FontAwesomeIcon icon={faSearch} /> Seach
                </Button>
              </Form.Group>
            </Row>
          </Form>
          <p className="notification">{messageError}</p>
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
              <tr>
                <td>1</td>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
              </tr>
              <tr>
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
