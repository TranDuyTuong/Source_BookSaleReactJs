import React, { useState, useEffect, useRef } from "react";
import "../Styles/ItemMaster.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPlus,
  faPenToSquare,
  faEye,
  faSearch,
  faSquareCheck,
  faFileArrowDown,
  faSquareCaretLeft,
} from "@fortawesome/free-solid-svg-icons";
import "../Styles/ItemMaster.css";
import {
  GetCookies,
  ConcatStringEvent,
  HandleGetAllStore,
  HandleCheckRoleStaff,
} from "../ObjectCommon/FunctionCommon";
import { UserLogin } from "../ObjectCommon/EventCommon";
import {
  CompanyCode,
  FistCode,
  EventInitializaItemMaster,
  EventItemMaster,
  EventSeachItemMaster,
} from "../ObjectCommon/EventCommon";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import LoadingModal from "../CommonPage/LoadingCommon";
import { useNavigate } from "react-router-dom";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { HandleSeachItemMaster } from "../ApiLablary/ItemMasterApi";
import { ItemMasterReducer } from "../ReduxCommon/ReducerCommon/ReducerItemMaster";
import moment from "moment";

// Main Function
function ItemMaster() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Call url old in redux
  const OldUrldata = useSelector((item) => item.oldUrl.ListoldUrlItem);
  // Call List ItemMaster in redux
  const ListItemMasterRedux = useSelector(
    (item) => item.itemMasterData.ListItemMaster
  );

  const ref_btnDetail = useRef(null);
  const ref_btnUpdate = useRef(null);
  const ref_btnDowload = useRef(null);
  const ref_btnConfirm = useRef(null);
  // Show Store Select
  const [state_ListStore, SetListSotre] = useState([]);
  // Message Error
  const [state_MessageError, SetMessageError] = useState("");
  // Show And Hide Loading Data
  const [state_Show, SetShow] = useState(false);

  // State Seach ItemMaster
  const [state_SeachItemMaster, SetSeachItemMaster] = useState("");
  // State Select Store
  const [state_SelectStore, SetSelectStore] = useState("");

  useEffect(() => {
    // Call Api Check Validation Token And Role User
    const CheckTokenAndRole = async () => {
      // Validation Token And Role Staff
      var token = GetCookies(UserLogin);

      // Get Event Code
      var eventCode = ConcatStringEvent(FistCode, EventItemMaster);

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
        dispatch(OldURLReducer.actions.AddUrl("/itemmaster"));
        window.localStorage.setItem("oldURL", "/itemmaster");

        // Setting Title Page
        document.title = "Item Maters";
        // Display button when initialization data
        ref_btnDetail.current.disabled = true;
        ref_btnUpdate.current.disabled = true;
        ref_btnDowload.current.disabled = true;
        ref_btnConfirm.current.disabled = true;

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
          const response = await HandleGetAllStore(formData);
          if (response.Status === true) {
            SetListSotre(response.ListStore);
            // Set Array Null In List ItemMaster When Initializa Data
            dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
          } else {
            SetMessageError(response.MessageError);
          }
        }
        InitializaData();
      }
    };
    CheckTokenAndRole();
  }, []);

  // Handle Back Menu
  const HandleBackMenuUI = (e) => {
    navigate("/menu");
  };

  // Handle Go to CreateItemMaster
  const HandleCreateItemMasterUI = (e) => {
    navigate("/createitemmaster");
  };

  // Handle Select Store
  const HandleSelectStore = (e) => {
    if (e === 0 || e === "0") {
      SetSelectStore(null);
    } else {
      SetSelectStore(e);
    }
  };

  // Handle Seach ItemMaser
  const HandleSeachItemMasterUI = async (e) => {
    // Get Token
    var token = GetCookies(UserLogin);
    // Get EventCode
    var eventCode = ConcatStringEvent(FistCode, EventSeachItemMaster);

    // Setting Data Seach ItemMaster
    var formData = new FormData();
    formData.append("Token", token);
    formData.append("UserID", window.localStorage.getItem("UserID"));
    formData.append("RoleID", window.localStorage.getItem("RoleEmployer"));
    formData.append("EventCode", eventCode);
    formData.append("TotalItemMaster", 0);
    formData.append("MessageError", null);
    formData.append("Status", true);
    formData.append("KeySeach", state_SeachItemMaster);
    formData.append("CompanyCode", CompanyCode);
    formData.append("StoreCode", state_SelectStore);
    formData.append("ListItemMaster", []);

    // Show Loading Modal
    SetShow(true);

    // Call Api Seach ItemMaster
    const seachResult = await HandleSeachItemMaster(formData);

    // Hide Loading Modal
    SetShow(false);

    // Result Data Seach
    if (seachResult.Status === true) {
      // Conver Applydate in list
      const listItemMasterNew = [];
      seachResult.ListItemMaster.forEach(function (item) {
        const data = {
          CompanyCode: item.CompanyCode,
          StoreCode: item.StoreCode,
          ItemCode: item.ItemCode,
          ApplyDate: moment(item.ApplyDate).format("YYYY-MM-DD"),
          Description: item.Description,
          DescriptionShort: item.DescriptionShort,
          DescriptionLong: item.DescriptionLong,
          PriceOrigin: item.PriceOrigin,
          PercentDiscount: item.PercentDiscount,
          priceSale: item.priceSale,
          QuantityDiscountID: item.QuantityDiscountID,
          PairDiscountID: item.PairDiscountID,
          SpecialDiscountID: item.SpecialDiscountID,
          Quantity: item.Quantity,
          Viewer: item.Viewer,
          Buy: item.Buy,
          CategoryItemMasterID: item.CategoryItemMasterID,
          AuthorID: item.AuthorID,
          DateCreate: item.DateCreate,
          IssuingCompanyID: item.IssuingCompanyID,
          PublicationDate: item.PublicationDate,
          size: item.size,
          PageNumber: item.PageNumber,
          PublishingCompanyID: item.PublishingCompanyID,
          IsSale: item.IsSale,
          LastUpdateDate:
            item.LastUpdateDate === null
              ? "--"
              : moment(item.LastUpdateDate).format("YYYY-MM-DD"),
          Note: item.Note,
          HeadquartersLastUpdateDateTime: item.HeadquartersLastUpdateDateTime,
          IsDeleteFlag: item.IsDeleteFlag,
          UserID: item.UserID,
          TaxGroupCodeID: item.TaxGroupCodeID,
          TypeOf: null,
          OldType: null,
        };
        listItemMasterNew.push(data);
      });
      // Save Area List In To Redux
      dispatch(ItemMasterReducer.actions.SeachItemMaster(listItemMasterNew));
      // Seach Success
      SetMessageError(seachResult.MessageError);
      // Enable Button Dowload
      ref_btnDowload.current.disabled = false;
    } else {
      // Save Area List In To Redux
      dispatch(ItemMasterReducer.actions.SeachItemMaster([]));
      SetMessageError(seachResult.MessageError);
    }
    return;
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
        | Item Master
      </h3>
      <Row>
        <Col xs={3}>
          <InputGroup className="mb-3 inputSeach">
            <Form.Control
              placeholder="Item code..."
              aria-describedby="basic-addon2"
              onChange={(e) => SetSeachItemMaster(e.target.value)}
            />
            <Button variant="primary" onClick={() => HandleSeachItemMasterUI()}>
              <FontAwesomeIcon icon={faSearch} /> Seach
            </Button>
          </InputGroup>
        </Col>
        <Col xs={2}>
          <Form.Select
            className="selectstore"
            onChange={(e) => HandleSelectStore(e.target.value)}
          >
            <option defaultChecked value="0">
              Select Store
            </option>
            {state_ListStore.map((item) => (
              <option key={item.StoreCode} value={item.StoreCode}>
                {item.Description}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col xs={7}>
          <p className="aline_settingHeader">
            <Button
              variant="primary"
              className="btn_setting"
              ref={ref_btnDowload}
            >
              <FontAwesomeIcon icon={faFileArrowDown} /> Dowload
            </Button>
          </p>
        </Col>
      </Row>
      <p className="messageError">{state_MessageError}</p>
      <Row>
        <Col>
          <div className="customtableItemMaster">
            <Table bordered hover>
              <thead>
                <tr>
                  <th>Item Code</th>
                  <th>Apply Date</th>
                  <th>Description</th>
                  <th>PriceOrigin</th>
                  <th>priceSale</th>
                  <th>Quantity</th>
                  <th>LastUpdate Date</th>
                </tr>
              </thead>
              <tbody>
                {ListItemMasterRedux.map((item) => (
                  <tr key={item.ItemCode}>
                    <td className="firsColum">{item.ItemCode}</td>
                    <td>{item.ApplyDate}</td>
                    <td>{item.Description}</td>
                    <td>{item.PriceOrigin}</td>
                    <td>{item.priceSale}</td>
                    <td>{item.Quantity}</td>
                    <td>{item.LastUpdateDate}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </Col>
      </Row>
      <p className="alinebuttonsetting">
        <Button
          variant="primary"
          className="btn_setting"
          onClick={(e) => HandleCreateItemMasterUI()}
        >
          <FontAwesomeIcon icon={faPlus} /> Add
        </Button>
        <Button variant="danger" className="btn_setting" ref={ref_btnDetail}>
          <FontAwesomeIcon icon={faEye} /> Detail
        </Button>
        <Button variant="warning" className="btn_setting" ref={ref_btnUpdate}>
          <FontAwesomeIcon icon={faPenToSquare} /> Update
        </Button>
        <Button variant="success" className="btn_setting" ref={ref_btnConfirm}>
          <FontAwesomeIcon icon={faSquareCheck} /> Confirm
        </Button>
      </p>
      {/* Show And Hide Laoding Data */}
      {state_Show && <LoadingModal />}
    </Container>
  );
}

export default ItemMaster;
