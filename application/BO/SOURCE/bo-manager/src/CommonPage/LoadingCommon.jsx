import Spinner from "react-bootstrap/Spinner";
import Modal from "react-bootstrap/Modal";
import "../Styles/LoadingCommon.css";
// Main Function
function LoadingModal() {
  return (
    <Modal show={true} className="potionAline">
      <Modal.Body className="modalcontent">
        <p className="loadingModal">
          <Spinner
            animation="border"
            variant="success"
            className="animationLoading"
          />
          <Spinner
            animation="border"
            variant="danger"
            className="animationLoading"
          />
          <Spinner
            animation="border"
            variant="warning"
            className="animationLoading"
          />
        </p>
      </Modal.Body>
    </Modal>
  );
}
export default LoadingModal;
