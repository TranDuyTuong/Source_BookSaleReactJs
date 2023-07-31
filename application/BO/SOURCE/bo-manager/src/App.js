import "./App.css";
import { Routes, Route } from "react-router-dom";
import RouterSytem from "./Pages/MainRoutes";
import Login from "./Pages/Login";

function App() {
  return (
    <div className="App">
      <RouterSytem></RouterSytem>
      <Routes>
        <Route path="/" element={<Login />}></Route>
      </Routes>
    </div>
  );
}

export default App;
