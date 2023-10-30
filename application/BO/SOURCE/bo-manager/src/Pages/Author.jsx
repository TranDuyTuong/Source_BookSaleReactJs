import React, { useState, useEffect } from "react";
import "../Styles/Home.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSearch,
  faPlusSquare,
  faCheckSquare,
  faSquareCaretLeft,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/Author.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import {
  FistCode,
  UserLogin,
  EventAuthor,
  EventSeachAuthor,
  CompanyCode,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { AuthorReducer } from "../ReduxCommon/ReducerCommon/ReducerAuthor";
import LoadingModal from "../CommonPage/LoadingCommon";
import { useNavigate } from "react-router-dom";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { toast } from "react-toastify";
import { HandleSeachAuthor } from "../ApiLablary/AuthorApi";

// Main Function
function Author() {
  // dispatch reducer
  const dispatch = useDispatch();
  const navigate = useNavigate();
  // seach
  const [seachAuthor, setSeachAuthor] = useState("");

  // Message more than 100 recol
  const [messageMore100Recol, setMessageMore100Recol] = useState("");

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);

  // Call list area in Redux

  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventAuthor);

      // Set Object check Token Data
      var formData = new FormData();
      formData.append("Token", token);
      formData.append("UserID", window.localStorage.getItem("UserID"));
      formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
      formData.append("EventCode", eventCode);

      // Check User Role
      var resultCheckRole = await HandleCheckRoleStaff(formData);
      if (resultCheckRole.Status === false) {
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
        dispatch(OldURLReducer.actions.AddUrl("/author"));
        window.localStorage.setItem("oldURL", "/author");

        // Setting Title Page
        document.title = "Author";
        // disabled button Confirm
        document.getElementById("btn_Confirm").disabled = true;
        // Set listArea in redux when initialization
        HandleInitializaAuthor();
      }
    };
    CheckTokenAndRole();
  }, []);

  // Handle set data area when initialization
  const HandleInitializaAuthor = () => {
    // reset list Author in Redux
    dispatch(AuthorReducer.actions.SeachAuthor([]));
  };

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  // Handle Seach Author
  const SeachAuthor = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventSeachAuthor);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalArea", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", seachAuthor);
    formData.append("CompanyCode", CompanyCode);
    formData.append("ListAuthor", []);

    // Handle Call Api Seach Author
    var result = await HandleSeachAuthor(formData);
    if (result.Status === false) {
      // Seach Fail
      toast.error(result.MessageError);
    } else {
      // Save Author List In To Redux
      dispatch(AuthorReducer.actions.SeachAuthor(result.ListArea));
      // Seach Success
      setMessageMore100Recol(result.MessageError);
    }
  };

  return (
    <Container fluid className="fixedPotionArea">
      <h3 className="areaTitle">
        <Button
          type="button"
          variant="light"
          onClick={() => HandleBackMenuUI()}
        >
          <FontAwesomeIcon icon={faSquareCaretLeft} /> Back
        </Button>
        | Author
      </h3>
      <Row>
        <Col>
          <Form>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" controlId="validationCustom01">
                <Form.Control
                  type="text"
                  placeholder="Author Code..."
                  onChange={(e) => setSeachAuthor(e.target.value)}
                  value={seachAuthor}
                />
              </Form.Group>
              <Form.Group as={Col} md="2" controlId="validationCustom02">
                <Button type="button" onClick={(e) => SeachAuthor()}>
                  <FontAwesomeIcon icon={faSearch} /> Seach
                </Button>
              </Form.Group>
            </Row>
          </Form>
          <p className="notification">{messageMore100Recol}</p>
        </Col>
      </Row>
      <Row>
        <Col>
          <div className="customtable">
            <Table bordered hover>
              <thead>
                <tr className="headerarea">
                  <th>Author ID</th>
                  <th>Name Author</th>
                  <th>Description</th>
                  <th>Date Create</th>
                  <th>User ID</th>
                  <th>Status</th>
                  <th>Option</th>
                </tr>
              </thead>
              <tbody></tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="btnMain">
        <Button variant="primary" className="btnOption">
          <FontAwesomeIcon icon={faPlusSquare} /> Add
        </Button>
        <Button variant="success" className="btnOption" id="btn_Confirm">
          <FontAwesomeIcon icon={faCheckSquare} /> Confirm
        </Button>
      </p>
    </Container>
  );
}

export default Author;
