import React, { useState } from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Styles/Home.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChartSimple } from "@fortawesome/free-solid-svg-icons";
import Chart from "chart.js/auto";
import { useEffect } from "react";

// Main Function
function Home() {
  useEffect(() => {
    ChartBooks();
  });
  return (
    <Container fluid>
      <p className="titleChart">
        <FontAwesomeIcon icon={faChartSimple} /> Chart
      </p>
      <hr />
      <Row>
        <Col>
          <canvas id="myChart"></canvas>
        </Col>
        <Col>Chart User</Col>
        <Col>Chart Order By Month</Col>
      </Row>
    </Container>
  );
}

// Design Chart Book
function ChartBooks() {
  const ctx = document.getElementById("myChart");
  var getData = DataBooks();
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

// Design Data Books For chart
function DataBooks() {
  const labels = months({ count: 12 });
  const data = {
    labels: labels,
    datasets: [
      {
        label: "My First Dataset",
        data: [65, 59, 80, 81, 56, 55, 40, 88, 79, 10, 12, 34],
        backgroundColor: [
          "rgba(255, 99, 132, 0.2)",
          "rgba(255, 159, 64, 0.2)",
          "rgba(255, 205, 86, 0.2)",
          "rgba(75, 192, 192, 0.2)",
          "rgba(54, 162, 235, 0.2)",
          "rgba(153, 102, 255, 0.2)",
          "rgba(201, 203, 207, 0.2)",
        ],
        borderColor: [
          "rgb(255, 99, 132)",
          "rgb(255, 159, 64)",
          "rgb(255, 205, 86)",
          "rgb(75, 192, 192)",
          "rgb(54, 162, 235)",
          "rgb(153, 102, 255)",
          "rgb(201, 203, 207)",
        ],
        borderWidth: 1,
      },
    ],
  };
  console.log(data);
  return data;
}

function months(config) {
  const MONTHS = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];
  var cfg = config || {};
  var count = cfg.count || 12;
  var section = cfg.section;
  var values = [];
  var i, value;

  for (i = 0; i < count; ++i) {
    value = MONTHS[Math.ceil(i) % 12];
    values.push(value.substring(0, section));
  }

  return values;
}

export default Home;
