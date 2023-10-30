import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import "../Styles/DiaLogTokenErrorCommon.css";
import React, { useState, useEffect } from "react";
// Main Function
function CreateDialog(prop) {
  const [show, setShow] = useState(false);

  // Close dialog
  const handleClose = (e) => {
    setShow(false);
  };

  // Show dialog
  const handeShow = (e) => {
    setShow(true);
  };

  // Create Author
  const handleSave = (e) => {};

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Modal heading</Modal.Title>
      </Modal.Header>
      <Modal.Body>Woohoo, you are reading this text in a modal!</Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={handleSave}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
}

export default CreateDialog;
