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
} from "@fortawesome/free-solid-svg-icons";
import { useEffect } from "react";
import { DataBooks } from "../TemplateCommon/ChartCommon";
import {
  Year2023,
  Year2024,
  Year2025,
  Year2026,
  Year2027,
  Year2028,
  Year2029,
  Year2030,
  ListMonths,
  ListYear,
} from "../Contants/DataContant";

// Main Function
function Home() {
  useEffect(() => {
    // Chart Book
    ChartBooks("myChartBook");
    // Chart User
    ChartBooks("myChartUser");
  }, []);
  return (
    <Container fluid>
      <p className="titleChart">
        <FontAwesomeIcon icon={faChartSimple} /> Chart
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
            <option value={Year2023}>{Year2023}</option>
            <option value={Year2024}>{Year2024}</option>
            <option value={Year2025}>{Year2025}</option>
            <option value={Year2026}>{Year2026}</option>
            <option value={Year2027}>{Year2027}</option>
            <option value={Year2028}>{Year2028}</option>
            <option value={Year2029}>{Year2029}</option>
            <option value={Year2030}>{Year2030}</option>
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
            <option value={Year2023}>{Year2023}</option>
            <option value={Year2024}>{Year2024}</option>
            <option value={Year2025}>{Year2025}</option>
            <option value={Year2026}>{Year2026}</option>
            <option value={Year2027}>{Year2027}</option>
            <option value={Year2028}>{Year2028}</option>
            <option value={Year2029}>{Year2029}</option>
            <option value={Year2030}>{Year2030}</option>
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
