import React from 'react';
import Header from "./core/components/header/Header";
import {Provider} from 'react-redux';
import { store } from './core/store/index';
import {Route, Routes} from "react-router-dom";
import {MainRoutes} from "./core/constants/mainRoutes";
import QuestionArea from "./pages/questionArea/QuestionArea";
import Sessions from "./pages/session/Session";
import QuestionsSets from "./pages/questionsSets/QuestionsSets";
import QuestionSetDescription from "./pages/questionSetDescription/QuestionSetDescription";
import QuestionAreaForm from "./pages/questionAreaForm/QuestionAreaForm";
import AddQuestionSet from "./pages/questionSetAdd/QuestionSetAdd";

const App: React.FC = () => {
    return (
        <Provider store={store}>
                <Header/>
                <Routes>
                    <Route path={MainRoutes.questionArea} element={<QuestionArea/>}/>
                    <Route path={MainRoutes.sessions} element={<Sessions/>}/>
                    <Route path={MainRoutes.questionSet} element={<QuestionsSets/>}/>
                    <Route path={MainRoutes.questionSetDescription} element={<QuestionSetDescription/>}/>
                    <Route path={`${MainRoutes.questionAreaForm}/:id`} element={<QuestionAreaForm/>}/>
                    <Route path={MainRoutes.questionAreaForm} element={<QuestionAreaForm/>}/>
                    <Route path={MainRoutes.addQuestionSet} element ={<AddQuestionSet/>}/>
                </Routes>
        </Provider>
    )}

export default App;
