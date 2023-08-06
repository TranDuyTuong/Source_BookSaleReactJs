import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Navbar from "react-bootstrap/Navbar";
import { faHome, faCircle } from "@fortawesome/free-solid-svg-icons";
import { Link, Routes, Route } from "react-router-dom";
import "../Styles/MenuCommon.css";

// Main Function
function MenuCommon() {
  return (
    <div className="menuSibar">
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link to="/home" className="itemChild">
            Home
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Area
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Stores
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Item Masters
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Categorys
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Orders
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Promotions
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Address
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Users
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Bank Suports
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Report
          </Link>
        </Container>
      </Navbar>
      <br />
      <Navbar className="bg-body-tertiary">
        <Container>
          <Link href="#home" className="itemChild">
            Setting
          </Link>
        </Container>
      </Navbar>
    </div>
  );
}

export default MenuCommon;
