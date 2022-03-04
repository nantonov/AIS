import {Routes, Route} from "react-router-dom";
import LeftSideBar from "../QuestionArea/QuestionArea";
import Sessions from "../Session/Session";
import React from 'react';
import QuestionSets from "../QuestionsSets/Questionsets";
import {MainRoutes} from "../../static/mainRoutes";


export default function Main() {
    return (
        <Routes>
            <Route path={MainRoutes.questionArea} element={<LeftSideBar/>}/>
            <Route path={MainRoutes.sessions} element={<Sessions/>}/>
            <Route path={MainRoutes.questionSet} element={<QuestionSets/>}/>
        </Routes>
    )
}
