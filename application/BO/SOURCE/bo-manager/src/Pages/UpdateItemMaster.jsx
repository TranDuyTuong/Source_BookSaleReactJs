import React, { useState, useEffect, useRef } from "react";
import "../Styles/CreateItemMaster.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import Table from "react-bootstrap/Table";
import Modal from "react-bootstrap/Modal";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSquareCheck,
  faSquareCaretLeft,
  faEllipsis,
  faPenToSquare,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/UpdateItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetInitializaItemMaster,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import {
  CompanyCode,
  FistCode,
  EventInitializaItemMaster,
  EventSeachItemMaster,
  EventUpdateItemMaster,
  UserLogin,
  EventGetAllItemMaster,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import LoadingModal from "../CommonPage/LoadingCommon";
import { useNavigate } from "react-router-dom";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { ItemMasterReducer } from "../ReduxCommon/ReducerCommon/ReducerItemMaster";
import {
  HandleSeachItemMasterUpdate,
  HandleGetAllItemMaster,
} from "../ApiLablary/ItemMasterApi";
import {
  InitializaDataSelect,
  DispayItemForm,
} from "../Validations/ValidationUpdateItemMaster";

// Main Function
function CreateItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Setting Button
  const btn_Update = useRef(null);
  const btn_Image = useRef(null);

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  // Get List ItemMaster Create
  const ListItemMasterMain = useSelector(
    (item) => item.itemMasterData.ListItemMaster
  );

  // Show Store Select
  const [state_ListStore, SetListStore] = useState([]);
  const [state_DefaulStore, SetDefaulStore] = useState("0");

  // Show Author Select
  const [state_ListAuthor, SetListAuthor] = useState([]);
  const [state_DefaulAuthor, SetDefaultAuthor] = useState("0");

  // Show Publishing Companys Select
  const [state_ListPublishingCompany, SetPublishingCompany] = useState([]);
  const [state_DefaultPublishingCompany, SetDefaultPublishingCompany] =
    useState("0");

  // Show Category Select
  const [state_ListCategory, SetListCategory] = useState([]);
  const [state_DefaultCategory, SetDefaultCategory] = useState("0");

  // Show And Hide Dialog Choose ItemMaster
  const [showDialogItemMaster, setShowDialogItemMaster] = useState(false);
  // State get All ItemMaster When Seach
  const [state_ListItemMaster, SetListItemMaster] = useState([]);
  // Message waining
  const [state_MessageWaining, SetMessageWaining] = useState("");

  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);

  // Create ItemMaster
  const [state_ItemCode, SetItemCode] = useState("");
  const [state_Description, SetDescription] = useState("");
  const [state_DescriptionLong, SetDescriptionLong] = useState("");
  const [state_DescriptionShort, SetDescriptionShort] = useState("");
  const [state_Quantity, SetQuantity] = useState("");
  const [state_Size, SetSize] = useState("");
  const [state_Note, SetNote] = useState("");
  const [state_ImageDefault, SetImageDefault] = useState("");

  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventUpdateItemMaster);

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
        dispatch(OldURLReducer.actions.AddUrl("/updateitemmaster"));
        window.localStorage.setItem("oldURL", "/updateitemmaster");
        // Setting Title Page
        document.title = "Update Item Maters";
        SetListStore([]);
        SetListAuthor([]);
        SetPublishingCompany([]);
        SetListCategory([]);
        // Reset form
        DispayItemForm(0);
        // Initializa Item Master, get all store
        async function InitializaData() {
          // Get Token
          var token = GetCookies(UserLogin);
          // Get EventCode
          var eventCode = ConcatStringEvent(
            FistCode,
            EventInitializaItemMaster
          );

          var formData = new FormData();
          formData.append("Token", token);
          formData.append("UserID", window.localStorage.getItem("UserID"));
          formData.append(
            "RoleID",
            window.localStorage.getItem("RoleEmployer")
          );
          formData.append("EventCode", eventCode);
          formData.append("MessageError", null);
          formData.append("Status", true);
          formData.append("CompanyCode", CompanyCode);
          // Call Api Initializa Data
          const response = await HandleGetInitializaItemMaster(formData);
          if (response.Status === true) {
            const initializaDataSelect = InitializaDataSelect(
              response.ListStore
            );
            // List Select Store
            SetListStore(initializaDataSelect.listStore);
          } else {
            SetListStore([]);
            SetMessageError(response.MessageError);
          }
        }
        InitializaData();
      }
      // reset List ItemMaster in Redux
      dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
    };
    CheckTokenAndRole();
  }, []);

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  // Handle Select Store
  const HandleSelectStore = (e, type) => {
    if (type === "Type01") {
      // Select store for seach ItemMaster By StoreCode
      SetDefaulStore(e);
    } else {
      // Update StoreCode for ItemMaster
      if (e === 0 || e === "0") {
        SetMessageError("Please Choose A Store!");
      } else {
        SetDefaulStore(e);
      }
    }
    return;
  };

  // Handle Select Author
  const HandleSelectAuthor = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Author!");
    } else {
      SetDefaultAuthor(e);
    }
    return;
  };

  // Handle Select PublishingCompany
  const HandleSelectPublishingCompany = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Publishing Company!");
    } else {
      SetDefaultPublishingCompany(e);
    }
    return;
  };

  // Handle Select Category
  const HandleSelectCategory = (e) => {
    if (e === 0 || e === "0") {
      SetMessageError("Please Choose A Category!");
    } else {
      SetDefaultCategory(e);
    }
    return;
  };

  // Handle Click Row Item In Table
  const HandleClickRowItem = (e) => {
    SetMessageError("");
    const findItemCode = ListItemMasterMain.find((item) => item.ItemCode === e);

    if (findItemCode !== undefined) {
      // Set Data in Form
      btn_Image.current.disabled = false;
      SetItemCode(findItemCode.ItemCode);
      SetDescription(findItemCode.Description);
      SetDescriptionLong(findItemCode.DescriptionLong);
      SetDescriptionShort(findItemCode.DescriptionShort);
      SetQuantity(findItemCode.Quantity);
      SetSize(findItemCode.size);
      SetNote(findItemCode.Note);
      // Set Select Defaul
      SetDefaulStore(findItemCode.StoreCode);
      SetDefaultAuthor(findItemCode.AuthorID);
      SetDefaultCategory(findItemCode.CategoryItemMasterID);
      SetDefaultPublishingCompany(findItemCode.PublishingCompanyID);
      // An Display Button Update
      btn_Update.current.disabled = false;
    } else {
      SetMessageError("Not Find ItemCode, Please Try Again!");
    }
  };

  // Handle Seach ItemCode
  const HandleSeachItemCodeUI = async (itemCode, typeSent, storecode) => {
    SetMessageError("");
    // Validation ItemCode Is Null
    if (itemCode === null || itemCode === undefined || itemCode === "") {
    } else {
      if (storecode === "0" || storecode === undefined) {
        SetMessageError("Please Choose A Store!");
      } else {
        // Hide Dialog Get All ItemMaster
        if (typeSent === "TypeSent02") {
          setShowDialogItemMaster(false);
        }
        // Show loading dialog
        SetShow(true);
        // Get Token
        var token = GetCookies(UserLogin);
        // Get EventCode
        var eventCode = ConcatStringEvent(FistCode, EventSeachItemMaster);
        // Setting Data Seach Area
        var formData = new FormData();
        formData.append("Token", token);
        formData.append("UserID", window.localStorage.getItem("UserID"));
        formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
        formData.append("EventCode", eventCode);
        formData.append("TotalItemMaster", 0);
        formData.append("MessageError", null);
        formData.append("Status", true);
        formData.append("KeySeach", itemCode);
        formData.append("CompanyCode", CompanyCode);
        formData.append("StoreCode", storecode);
        formData.append("ListItemMaster", []);

        // Call Api Get ItemMaster By ItemCode
        const resultData = await HandleSeachItemMasterUpdate(formData);

        // Hide loading Dialog
        SetShow(false);

        // Result
        if (resultData.Status === false) {
          SetMessageError(resultData.MessageError);
        } else {
          dispatch(
            ItemMasterReducer.actions.SeachItemMaster(resultData.ListItemMaster)
          );
        }
      }
    }
    return;
  };

  // Handle Show Dialog Get All ItemMaster UI
  const HandleShowDialogGetAllItemMasterUI = async (e) => {
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");
    setShowDialogItemMaster(true);
    SetListItemMaster([]);
  };

  // Handle GetAll ItemMaster
  const HandleGetAllItemMasterUI = async (e) => {
    SetMessageError("");
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventGetAllItemMaster);
    // Setting Data Seach Area
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("StoreCode", state_DefaulStore);
    formData.append("CompanyCode", CompanyCode);

    // Call Api
    const result = await HandleGetAllItemMaster(formData);
    if (result.Status === true) {
      if (result.TotalItemMaster === 0) {
        SetMessageWaining(result.MessageError);
      } else {
        SetMessageWaining(result.TotalItemMaster);
      }
      // render list itemMaster In UI
      SetListItemMaster(result.ListItemMaster);
    } else {
      SetMessageError(result.MessageError);
    }
  };

  // Handle Close Dialog Filter ItemMaster
  const HandleCloseDialogFilterItemMaster = (e) => {
    const storeSelect = document.getElementById("Btn_DisplayStore");
    storeSelect.selectedIndex = [...storeSelect.options].findIndex(
      (option) => option.text === "Select Store"
    );
    SetDefaulStore("0");

    SetMessageWaining("");
    SetMessageError("");
    setShowDialogItemMaster(false);
    SetListItemMaster([]);
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
        | Update Item Master
      </h3>
      <Row>
        <Col xs={3}>
          <Form.Group>
            {/* input ItemCode */}
            <p className="titleItem">
              ItemCode <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_ItemCode"
                value={state_ItemCode}
                placeholder="Enter ItemCode ..."
                onChange={(e) => SetItemCode(e.target.value)}
              />
              <Button
                variant="outline-primary"
                onClick={(e) => HandleShowDialogGetAllItemMasterUI()}
              >
                <FontAwesomeIcon icon={faEllipsis} />
              </Button>
              <Button
                variant="outline-secondary"
                onClick={(e) =>
                  HandleSeachItemCodeUI(
                    state_ItemCode,
                    "TypeSent01",
                    state_DefaulStore
                  )
                }
              >
                Seach
              </Button>
            </InputGroup>

            {/* input Description */}
            <p className="titleItem">
              Description <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescription"
                onChange={(e) => SetDescription(e.target.value)}
                value={state_Description}
              />
            </InputGroup>

            {/* input Description Long */}
            <p className="titleItem">
              Description Long <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item Long ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescriptionLong"
                onChange={(e) => SetDescriptionLong(e.target.value)}
                value={state_DescriptionLong}
              />
            </InputGroup>

            {/* input Description Long */}
            <p className="titleItem">
              Description Short <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Name Item Short ..."
                aria-describedby="basic-addon2"
                id="Btn_DisplayDescriptionShort"
                onChange={(e) => SetDescriptionShort(e.target.value)}
                value={state_DescriptionShort}
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={4}>
          <Form.Group>
            {/* input Store */}
            <p className="titleItem">
              Store <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore mb-3"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value, "Type02")}
            >
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>

            {/* input Category */}
            <p className="titleItem">
              Category <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              value={state_DefaultCategory}
              onChange={(e) => HandleSelectCategory(e.target.value)}
              id="Btn_DisplayCategory"
            >
              {state_ListCategory.map((item) => (
                <option
                  key={item.CategoryItemMasterID}
                  value={item.CategoryItemMasterID}
                >
                  {item.Description}
                </option>
              ))}
            </Form.Select>

            {/* input Author */}
            <p className="titleItem">
              Author <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              value={state_DefaulAuthor}
              onChange={(e) => HandleSelectAuthor(e.target.value)}
              id="Btn_DisplayAuthor"
            >
              {state_ListAuthor.map((item) => (
                <option key={item.AuthorID} value={item.AuthorID}>
                  {item.NameAuthor}
                </option>
              ))}
            </Form.Select>

            {/* input Publishing CompanyID */}
            <p className="titleItem">
              Publishing Company <span className="itemNotNull">*</span>
            </p>
            <Form.Select
              className="selectstore mb-3"
              value={state_DefaultPublishingCompany}
              onChange={(e) => HandleSelectPublishingCompany(e.target.value)}
              id="Btn_DisplayPublishingCompany"
            >
              {state_ListPublishingCompany.map((item) => (
                <option
                  key={item.PublishingCompanyID}
                  value={item.PublishingCompanyID}
                >
                  {item.Description}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
        </Col>
        <Col xs={3}>
          <Form.Group>
            {/* input Quantity */}
            <p className="titleItem">
              Quantity <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                placeholder="Enter Quantity ..."
                aria-describedby="basic-addon2"
                type="Number"
                id="Btn_DisplayQuantity"
                onChange={(e) => SetQuantity(e.target.value)}
                value={state_Quantity}
              />
            </InputGroup>
            {/* input Size */}
            <p className="titleItem">
              Size <span className="itemNotNull">*</span>
            </p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_DisplaySize"
                placeholder="Enter Size ..."
                aria-describedby="basic-addon2"
                onChange={(e) => SetSize(e.target.value)}
                value={state_Size}
              />
            </InputGroup>
            {/* input Note */}
            <p className="titleItem">Note</p>
            <InputGroup className="mb-3">
              <Form.Control
                id="Btn_DisplayNote"
                placeholder="Enter Note ..."
                as="textarea"
                style={{ height: "110px" }}
                onChange={(e) => SetNote(e.target.value)}
                value={state_Note}
              />
            </InputGroup>
          </Form.Group>
        </Col>
        <Col xs={2}>
          <Form.Group>
            <img
              className="imgDefault"
              src={state_ImageDefault}
              alt="zkteco-k14-Default"
              border="0"
            />
          </Form.Group>
          <Form.Group>
            <InputGroup className="mb-3">
              <Button variant="outline-primary" style={{ width: "100%" }}>
                <FontAwesomeIcon icon={faPenToSquare} /> Update
              </Button>
            </InputGroup>
          </Form.Group>
        </Col>
      </Row>
      <p className="messageError">{state_MessageError}</p>
      <Row>
        <Col>
          <div className="customtableCreateItemMaster">
            <Table bordered hover>
              <thead>
                <tr className="headerItemMaster">
                  <th>Item Code</th>
                  <th>Store</th>
                  <th>Quantity</th>
                  <th>Category</th>
                  <th>Author</th>
                  <th>PriceSale</th>
                  <th>PublishingCompanyID</th>
                  <th>Description</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody>
                {ListItemMasterMain.map((item) => (
                  <tr
                    key={item.ItemCode}
                    onClick={(e) => HandleClickRowItem(item.ItemCode)}
                  >
                    <td>{item.ItemCode}</td>
                    <td>{item.StoreCode}</td>
                    <td>{item.Quantity}</td>
                    <td>{item.CategoryItemMasterID}</td>
                    <td>{item.AuthorID}</td>
                    <td>{item.priceSale}</td>
                    <td>{item.PublishingCompanyID}</td>
                    <td>{item.Description}</td>
                    <td>{item.TypeOf}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="alinebuttonsetting">
        {ListItemMasterMain.length !== 0 && (
          <Button variant="success" className="btn_setting">
            <FontAwesomeIcon icon={faSquareCheck} /> Confirm
          </Button>
        )}
      </p>
      {/* Show And Hide Laoding Data */}
      {state_Show && <LoadingModal />}
      {/* Dialog list itemMaster */}
      <Modal show={showDialogItemMaster}>
        <Modal.Header className="backroundModal">
          <InputGroup className="mb-3">
            <Form.Select
              id="Btn_DisplayStore"
              className="selectstore mb-3"
              value={state_DefaulStore}
              onChange={(e) => HandleSelectStore(e.target.value, "Type01")}
            >
              {state_ListStore.map((item) => (
                <option key={item.StoreCode} value={item.StoreCode}>
                  {item.Description}
                </option>
              ))}
            </Form.Select>
            <Button
              className="fuilterItemMaster"
              variant="outline-primary"
              onClick={(e) => HandleGetAllItemMasterUI()}
            >
              Filter
            </Button>
          </InputGroup>
        </Modal.Header>
        <Modal.Body className="backroundModal sizeBody">
          <p className="MessageWaining">{state_MessageWaining}</p>
          <Table bordered hover>
            <tbody>
              {state_ListItemMaster.map((item) => (
                <tr key={item.ItemCode}>
                  <td>
                    <p className="buttonChoose">{item.ItemCode} </p>
                  </td>
                  <td>
                    <p className="buttonChoose">{item.Description}</p>
                  </td>
                  <td>
                    <p className="buttonChoose">
                      <Button
                        variant="primary"
                        onClick={(e) =>
                          HandleSeachItemCodeUI(
                            item.ItemCode,
                            "TypeSent02",
                            state_DefaulStore
                          )
                        }
                      >
                        Choose
                      </Button>
                    </p>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Modal.Body>
        <Modal.Footer className="backroundModal">
          <Button
            variant="secondary"
            onClick={() => HandleCloseDialogFilterItemMaster()}
          >
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default CreateItemMaster;
