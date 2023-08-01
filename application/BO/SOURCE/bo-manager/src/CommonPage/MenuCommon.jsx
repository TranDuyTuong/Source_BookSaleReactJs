import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Navbar from "react-bootstrap/Navbar";
import { faHome, faCircle } from "@fortawesome/free-solid-svg-icons";
import { Link, Routes, Route } from "react-router-dom";
// Main Function
function MenuCommon() {
  return (
    <React.Fragment>
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link to="/home">
            <FontAwesomeIcon icon={faHome} /> Home
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home">
            <FontAwesomeIcon icon={faCircle} /> Item Masters
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home">
            <FontAwesomeIcon icon={faCircle} /> Address
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home">
            <FontAwesomeIcon icon={faCircle} /> Users
          </Link>
        </Container>
      </Navbar>
    </React.Fragment>
  );
}

export default MenuCommon;
