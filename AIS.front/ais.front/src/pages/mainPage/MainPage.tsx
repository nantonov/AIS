import {Routes, Route} from "react-router-dom";
import LeftSideBar from "../questionArea/QuestionArea";
import Sessions from "../session/Session";
import React from 'react';
import {MainRoutes} from "../../core/constants/mainRoutes";
import QuestionsSets from "../questionsSets/QuestionsSets";
import QuestionSetDescription from "../questionSet/QuestionSetDescription";
import QuestionAreaForm from "../questionArea/QuestionAreaForm";
import AddQuestionSet from "../questionSet/QuestionSetAdd";

export default function Main() {
    return (
        <Routes>
            <Route path={MainRoutes.questionArea} element={<LeftSideBar/>}/>
            <Route path={MainRoutes.sessions} element={<Sessions/>}/>
            <Route path={MainRoutes.questionSet} element={<QuestionsSets/>}/>
            <Route path={MainRoutes.questionSetDescription} element={<QuestionSetDescription/>}/>
            <Route path={`${MainRoutes.questionAreaForm}/:id`} element={<QuestionAreaForm/>}/>
            <Route path={MainRoutes.questionAreaForm} element={<QuestionAreaForm/>}/>
            <Route path={MainRoutes.addQuestionSet} element ={<AddQuestionSet/>}/>
        </Routes>
    )
}
