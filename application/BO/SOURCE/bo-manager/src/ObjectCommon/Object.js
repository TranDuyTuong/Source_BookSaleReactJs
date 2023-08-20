// validationLogin
export var validationLogin = {
  Status: "",
  Message: "",
  Type: "", // 1 -> is Email And 2 -> is Password
};

// LoginUser
export var LoginUser = {
  Email: "",
  Password: "",
  RememberMe: "",
  EventCode: "",
};

// Result Login User
export var ResultLogin = {
  Status: "",
  Message: "",
};

// Validation Token And Role Staff
export var ResultCommonCheckToken = {
  Token: "",
  UserID: "",
  RoleID: "",
  EventCode: "",
};

// Return data common Api
export var ReturnCommonApi = {
  Status: "",
  IdPlugin: "",
  Message: "",
};

// SignOut User
export var SignOutUser = {
  Token: "",
  UserID: "",
  RoleID: "",
  ExpirationDate: "",
  EventCode: "",
};

// Area
export var M_Area = {
  CompanyCode: "",
  AreaCode: "",
  Description: "",
  TypeOf: "",
  OldType: null,
};

// M_ListArea
export var M_ListArea = {
  Token: "",
  UserID: "",
  RoleID: "",
  EventCode: "",
  TotalArea: "",
  MessageError: "",
  Status: "",
  KeySeach: "",
  CompanyCode: "",
  ListArea: [],
};
