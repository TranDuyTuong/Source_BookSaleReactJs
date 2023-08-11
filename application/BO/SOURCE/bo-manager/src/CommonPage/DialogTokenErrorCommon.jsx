import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import { messageTitleErrorToken } from "../MessageCommon/Message";
import "../Styles/DiaLogTokenErrorCommon.css";
// Main Function
function DiaLogTokenError(prop) {
  // Handle Close Dialog
  const handleClose = (e) => {
    var originUrl = window.location.origin;
    window.location.href = originUrl;
  };

  return (
    <Modal show={true}>
      <Modal.Header className="settingBackround">
        <Modal.Title>{messageTitleErrorToken}</Modal.Title>
      </Modal.Header>
      <Modal.Body className="settingBackround">{prop.Message}</Modal.Body>
      <Modal.Footer className="settingBackround">
        <Button variant="secondary" onClick={handleClose}>
          OK
        </Button>
      </Modal.Footer>
    </Modal>
  );
}

export default DiaLogTokenError;
