import "./App.css";
import { Routes, Route } from "react-router-dom";
import RouterSytem from "./Pages/MainRoutes";
import Login from "./Pages/Login";
import CommonPage from "./CommonPage/CommonPage";

function App() {
  return (
    <div className="App">
      <RouterSytem></RouterSytem>
      <Routes>
        <Route path="/" element={<Login />}></Route>
        <Route path="/*" element={<CommonPage />}></Route>
      </Routes>
    </div>
  );
}

export default App;
