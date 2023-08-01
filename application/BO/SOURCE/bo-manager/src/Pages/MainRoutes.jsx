import React from "react";
import { Link, Routes, Route } from "react-router-dom";

function RouterSytem() {
  <React.Fragment>
    <nav>
      <ul>
        <li>
          <Link to="/">Login</Link>
        </li>
        <li>
          <Link to="/home/*">Home</Link>
        </li>
      </ul>
    </nav>
  </React.Fragment>;
}

export default RouterSytem;
