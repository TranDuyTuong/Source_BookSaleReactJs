import "./App.css";
import { Routes, Route } from "react-router-dom";
import RouterSytem from "./Pages/MainRoutes";
import Login from "./Pages/Login";
import Home from "./Pages/Home";

function App() {
  return (
    <div className="App">
      <RouterSytem></RouterSytem>
      <Routes>
        <Route path="/" element={<Login />}></Route>
        <Route path="/home" element={<Home />}></Route>
      </Routes>
    </div>
  );
}

export default App;
