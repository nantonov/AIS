import {Routes, Route} from "react-router-dom";
import LeftSideBar from "../QuestionsSets/QuestionsSets";
import Sessions from "../Session/Session";
import React from 'react';
import {MainRoutes} from "../../static/mainRoutes";
import QuestionsSets from "../QuestionsSets/QuestionsSets";
import QuestionSetDescription from "../QuestionSet/QuestionSetDescription";

export default function Main() {
    return (
        <Routes>
            <Route path={MainRoutes.questionArea} element={<LeftSideBar/>}/>
            <Route path={MainRoutes.sessions} element={<Sessions/>}/>
            <Route path={MainRoutes.questionSet} element={<QuestionsSets/>}/>
            <Route path={MainRoutes.questionSetDescription} element={<QuestionSetDescription/>}/>
        </Routes>
    )
}
