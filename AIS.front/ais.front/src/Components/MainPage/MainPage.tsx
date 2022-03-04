import {Routes, Route} from "react-router-dom";
import LeftSideBar from "../QuestionArea/QuestionArea";
import Sessions from "../Session/Session";
import React from 'react';

export default function Main() {
    return (
        <Routes>
            <Route path="question_area" element={<LeftSideBar/>}/>
            <Route path="sessions" element={<Sessions/>}/>
        </Routes>
    )
}
