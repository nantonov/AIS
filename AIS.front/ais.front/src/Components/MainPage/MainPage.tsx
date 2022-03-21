import {Routes, Route} from "react-router-dom";
import LeftSideBar from "../QuestionsSets/QuestionsSets";
import Sessions from "../Session/Session";
import React from 'react';
import QuestionSets from "../QuestionsSets/Questionsets";
import {MainRoutes} from "../../static/mainRoutes";
import QuestionsSets from "../QuestionsSets/QuestionsSets";
import QuestionSetDescription from "../QuestionSet/QuestionSetDescription";
import Questions from "../Questions/Questions";

export default function Main() {
    return (
        <Routes>
            <Route path={MainRoutes.questionArea} element={<LeftSideBar/>}/>
            <Route path={MainRoutes.sessions} element={<Sessions/>}/>
            <Route path={MainRoutes.questions} element={<Questions/>}/>
            <Route path={MainRoutes.questionSet} element={<QuestionsSets/>}/>
            <Route path={MainRoutes.questionSetDescription} element={<QuestionSetDescription/>}/>
        </Routes>
    )
}
