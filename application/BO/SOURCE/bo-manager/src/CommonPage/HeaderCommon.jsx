import React, { useState, useEffect } from "react";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Styles/HeaderCommon.css";
import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faClock,
  faRectangleList,
  faUser,
  faRightFromBracket,
} from "@fortawesome/free-solid-svg-icons";
import {
  HandleCheckTimeOut,
  GetCookies,
  ConcatStringEvent,
} from "../ObjectCommon/FunctionCommon";
import { SignOutUser } from "../ObjectCommon/Object";
import { UserLogin, EventSignOut, FistCode } from "../ObjectCommon/EventCommon";
import { ServiceHandleSignOut } from "../ApiLablary/SignOutApi";
import DiaLogTokenError from "../CommonPage/DialogTokenErrorCommon";
import {
  messageTitleSignOutError,
  messageErrorSignOut,
} from "../MessageCommon/Message";

// Main function
function HeaderCommon() {
  // Get Staff Login
  const [sessionExpiration, SetSessionExpiration] = useState("");
  const [roleName, SetRoleName] = useState("");
  const [userName, SetUserName] = useState("");
  // Get Show Dialog Confirm
  const [show, SetShow] = useState(false);
  const [contentMessage, SetContentMessage] = useState("");

  useEffect(() => {
    SetSessionExpiration(window.localStorage.getItem("ExpirationDate"));
    SetRoleName(window.localStorage.getItem("DescriptionRole"));
    SetUserName(window.localStorage.getItem("Employer"));
    // Check Time Out Token Use
    setInterval(HandleCheckTimeOut, 3000);
  }, []);

  // Handle SignOut
  const HandleSignOut = async (e) => {
    var signOutInfo = SignOutUser;
    signOutInfo.Token = GetCookies(UserLogin);
    signOutInfo.UserID = window.localStorage.getItem("UserID");
    signOutInfo.RoleID = window.localStorage.getItem("RoleEmployer");
    signOutInfo.ExpirationDate = window.localStorage.getItem("ExpirationDate");
    signOutInfo.EventCode = ConcatStringEvent(FistCode, EventSignOut);

    // Set data in form
    var signOut = new FormData();
    signOut.append("Token", signOutInfo.Token);
    signOut.append("UserID", signOutInfo.UserID);
    signOut.append("RoleID", signOutInfo.RoleID);
    signOut.append("ExpirationDate", signOutInfo.ExpirationDate);
    signOut.append("EventCode", signOutInfo.EventCode);

    // Call Api SignOut
    var result = await ServiceHandleSignOut(signOut);

    if (result.Status === true) {
      // Success
      window.location.href = window.location.origin;
    } else {
      // Error
      SetContentMessage(result.Message + "<br />" + messageErrorSignOut);
      SetShow(true);
    }
  };

  return (
    <div className="header">
      <Row>
        <Col xs={3}>
          <p className="title">BOOK MANAGEMENT</p>
        </Col>
        <Col>
          <p className="infoUser">
            <span className="positionInfo">
              <FontAwesomeIcon icon={faClock} /> Phiên Hết Hạn:{" "}
              {sessionExpiration}
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faRectangleList} /> Cấp Độ: {roleName}
            </span>
            <span className="positionInfo">
              <FontAwesomeIcon icon={faUser} /> {userName}
            </span>
            <span className="positionInfo">
              <Button variant="outline-light" onClick={HandleSignOut}>
                <FontAwesomeIcon icon={faRightFromBracket} /> SignOut
              </Button>
            </span>
          </p>
        </Col>
      </Row>
      {show && (
        <DiaLogTokenError
          messageTitleErrorToken={messageTitleSignOutError}
          Message={contentMessage}
        />
      )}
    </div>
  );
}

export default HeaderCommon;
