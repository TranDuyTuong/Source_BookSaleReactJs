import {
  EventHome,
  EventArea,
  EventStore,
  EventItemMaster,
  EventCreateItemMaster,
  EventUpdateItemMaster,
  EventChangePriceItemMaster,
} from "../ObjectCommon/EventCommon";

// List Year
export const ListYear = [
  {
    id: "2023",
    yearName: "2023",
  },
  {
    id: "2024",
    yearName: "2024",
  },
  {
    id: "2025",
    yearName: "2025",
  },
  {
    id: "2026",
    yearName: "2026",
  },
  {
    id: "2027",
    yearName: "2027",
  },
  {
    id: "2028",
    yearName: "2028",
  },
  {
    id: "2029",
    yearName: "2029",
  },
  {
    id: "2030",
    yearName: "2030",
  },
];

// List Month
export const ListMonths = [
  {
    id: 1,
    monthName: "Month 01",
  },
  {
    id: 2,
    monthName: "Month 02",
  },
  {
    id: 3,
    monthName: "Month 03",
  },
  {
    id: 4,
    monthName: "Month 04",
  },
  {
    id: 5,
    monthName: "Month 05",
  },
  {
    id: 6,
    monthName: "Month 06",
  },
  {
    id: 7,
    monthName: "Month 07",
  },
  {
    id: 8,
    monthName: "Month 08",
  },
  {
    id: 9,
    monthName: "Month 09",
  },
  {
    id: 10,
    monthName: "Month 10",
  },
  {
    id: 11,
    monthName: "Month 11",
  },
  {
    id: 12,
    monthName: "Month 12",
  },
];

// List Button Main
export const ListButtonMain = [
  {
    id: "Main_01",
    buttonName: "Home",
    stylebutton: "outline-primary",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "Main_02",
    buttonName: "Area",
    stylebutton: "outline-primary",
    buttonUrl: "/area",
    eventCode: EventArea,
  },
  {
    id: "Main_03",
    buttonName: "Store",
    stylebutton: "outline-primary",
    buttonUrl: "/store",
    eventCode: EventStore,
  },
  {
    id: "Main_04",
    buttonName: "Item Master",
    stylebutton: "outline-primary",
    buttonUrl: "/itemmaster",
    eventCode: EventItemMaster,
  },
  {
    id: "Main_05",
    buttonName: "Create Item Master",
    stylebutton: "outline-primary",
    buttonUrl: "/createitemmaster",
    eventCode: EventCreateItemMaster,
  },
  {
    id: "Main_06",
    buttonName: "Update Item Master",
    stylebutton: "outline-primary",
    buttonUrl: "/updateitemmaster",
    eventCode: EventUpdateItemMaster,
  },
  {
    id: "Main_07",
    buttonName: "Change Price Item Master",
    stylebutton: "outline-primary",
    buttonUrl: "/changepriceitemmaster",
    eventCode: EventChangePriceItemMaster,
  },
];

// List Button Function
export const ListButtonFunction = [
  {
    id: "Function_01",
    buttonName: "Text",
    stylebutton: "outline-success",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "Function_02",
    buttonName: "Text",
    stylebutton: "outline-success",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "Function_03",
    buttonName: "Text",
    stylebutton: "outline-success",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "Function_04",
    buttonName: "Text",
    stylebutton: "outline-success",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "Function_05",
    buttonName: "Text",
    stylebutton: "outline-success",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
];

// List Button System
export const ListButtonSystem = [
  {
    id: "System_01",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "System_01",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "System_02",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "System_03",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "System_04",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
  {
    id: "System_05",
    buttonName: "Text",
    stylebutton: "outline-info",
    buttonUrl: "/home",
    eventCode: EventHome,
  },
];

// Create Data
export const Create = "CREATE";

// Update Data
export const Update = "UPDATE";

// Delete Data
export const Delete = "DELETE";

// Revert Data affter Delete
export const Revert = "REVERT";

// Detail Data
export const Detail = "DETAIL";

// Type Api
export const post = "post";

export const get = "get";

// OTP Control ItemMaster
export const Create_ItemMaster = 0;
export const UpdateBase_ItemMaster = 1;
export const Delete_ItemMaster = 2;
