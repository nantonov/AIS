import React from 'react';
import logo from './logo.svg';
import './App.css';
import {BrowserRouter} from "react-router-dom";
import Header from "./Components/Header/Header";
import LeftSideBar from "./Components/SideMenu/LeftSideBarMenu";

function App() {
  return(
  <BrowserRouter>
    <Header/>
    {/*<LeftSideBar/>*/}
  </BrowserRouter>
  )
}

export default App;
