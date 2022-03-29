import {Routes, Route} from "react-router-dom";
import QuestionArea from "../questionArea/QuestionArea";
import Sessions from "../session/Session";
import React from 'react';
import {MainRoutes} from "../../core/constants/mainRoutes";
import QuestionsSets from "../questionsSets/QuestionsSets";
import QuestionSetDescription from "../questionSetDescription/QuestionSetDescription";
import QuestionAreaForm from "../questionAreaForm/QuestionAreaForm";
import AddQuestionSet from "../questionSetAdd/QuestionSetAdd";

 const Main: React.FC = () => {
    return (
        <Routes>
            <Route path={MainRoutes.questionArea} element={<QuestionArea/>}/>
            <Route path={MainRoutes.sessions} element={<Sessions/>}/>
            <Route path={MainRoutes.questionSet} element={<QuestionsSets/>}/>
            <Route path={MainRoutes.questionSetDescription} element={<QuestionSetDescription/>}/>
            <Route path={`${MainRoutes.questionAreaForm}/:id`} element={<QuestionAreaForm/>}/>
            <Route path={MainRoutes.questionAreaForm} element={<QuestionAreaForm/>}/>
            <Route path={MainRoutes.addQuestionSet} element ={<AddQuestionSet/>}/>
        </Routes>
    )
}

export default Main;