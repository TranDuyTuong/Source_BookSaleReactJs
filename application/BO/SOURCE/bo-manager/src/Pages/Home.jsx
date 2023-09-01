import React, { useState } from "react";
import Chart from "chart.js/auto";
import "../Styles/Home.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faChartSimple,
  faCartShopping,
  faFilter,
  faSquareCaretLeft,
} from "@fortawesome/free-solid-svg-icons";
import { useEffect } from "react";
import { DataBooks } from "../TemplateCommon/ChartCommon";
import { ListMonths, ListYear } from "../Contants/DataContant";
import {
  ConcatStringEvent,
  GetCookies,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin, FistCode, EventHome } from "../ObjectCommon/EventCommon";
import DiaLogTokenError from "../CommonPage/DialogTokenErrorCommon";
import { useSelector } from "react-redux";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { messageTitleErrorToken } from "../MessageCommon/Message";

// Main Function
function Home() {
  // Show DiaLog Error Toekn
  const [show, setShow] = useState(false);
  const [messageErrorToken, getMessageErrorToken] = useState("");
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Read Loading Page
  useEffect(() => {
    // Setting Titel Page
    document.title = "Home";

    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventHome);

      // Set Object check Token Data
      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);

      // Check User Role
      var resultCheckRole = await HandleCheckRoleStaff(formData);
      if (resultCheckRole.Status === true) {
        // var OldURL = window.localStorage.getItem("oldURL");
        alert(resultCheckRole.Message);
        // User Don't have Role
        if (OldUrldata[0] === window.location.origin) {
          // redirect to Login Pgae
          window.location.href = window.location.origin;
        } else {
          // redirect to page before
          navigate(window.localStorage.getItem("oldURL"));
        }
      } else {
        // Reomve Old  Url
        window.localStorage.removeItem("oldURL");

        // Create New Url
        dispatch(OldURLReducer.actions.DeleteURL());
        dispatch(OldURLReducer.actions.AddUrl("/home"));
        window.localStorage.setItem("oldURL", "/home");

        // Chart Book
        ChartBooks("myChartBook");
        // Chart User
        ChartBooks("myChartUser");
      }
    };
    CheckTokenAndRole();
  }, []);

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  return (
    <Container fluid className="fixedPotionHome">
      <p className="titleChart">
        <Button
          type="button"
          variant="light"
          onClick={() => HandleBackMenuUI()}
        >
          <FontAwesomeIcon icon={faSquareCaretLeft} /> Back
        </Button>
        | <FontAwesomeIcon icon={faChartSimple} /> Chart
      </p>
      <hr />
      <Row>
        <Col>
          <p className="titelChartBook">Chart Book</p>
          <Form.Select
            aria-label="Default select example"
            className="selecYearChart"
          >
            <option value="0">Select Year (2023 - 2030)</option>
            {ListYear.map((item) => (
              <option value={item.id} key={item.id}>
                {item.yearName}
              </option>
            ))}
          </Form.Select>
          <canvas id="myChartBook"></canvas>
          <p className="total">Total:</p>
        </Col>
        <Col>
          <p className="titelChartBook">Chart User</p>
          <Form.Select
            aria-label="Default select example"
            className="selecYearChart"
          >
            <option value="0">Select Year (2023 - 2030)</option>
            {ListYear.map((item) => (
              <option value={item.id} key={item.id}>
                {item.yearName}
              </option>
            ))}
          </Form.Select>
          <canvas id="myChartUser"></canvas>
          <p className="total">Total:</p>
        </Col>
      </Row>

      <p className="titleChart">
        <FontAwesomeIcon icon={faCartShopping} /> Orders Of The Month
      </p>
      <hr></hr>
      <Row>
        <Col xs={2}>
          <Form.Select
            aria-label="Default select example"
            className="selecYearChart"
          >
            <option value="0">Select Month</option>
            {ListMonths.map((item) => (
              <option value={item.id} key={item.id}>
                {item.monthName}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col xs={2}>
          <Form.Select
            aria-label="Default select example"
            className="selecYearChart"
          >
            <option value="0">Select Year</option>
            {ListYear.map((item) => (
              <option value={item.id} key={item.id}>
                {item.yearName}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col xs={2}>
          <Button variant="primary" className="filterbtn">
            <FontAwesomeIcon icon={faFilter} /> Filter
          </Button>
        </Col>
        <Col>
          <p className="total">Total:</p>
        </Col>
      </Row>
      <br></br>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>UserID</th>
            <th>Full Name</th>
            <th>Total Orders</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>1</td>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
          </tr>
        </tbody>
      </Table>
      <p className="showMore">
        <Button variant="link">Show More</Button>
      </p>
      {show && (
        <DiaLogTokenError
          Message={messageErrorToken}
          TileError={messageTitleErrorToken}
        />
      )}
    </Container>
  );
}

// Design Chart Book
function ChartBooks(idName) {
  const ctx = document.getElementById(idName);
  var getData = DataBooks(idName);
  new Chart(ctx, {
    type: "bar",
    data: getData,
    options: {
      scales: {
        y: {
          beginAtZero: true,
        },
      },
    },
  });
}

export default Home;
