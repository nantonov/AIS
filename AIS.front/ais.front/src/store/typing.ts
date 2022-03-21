import {Action} from 'typesafe-actions';
import {RouterState} from "connected-react-router";
import {ThunkDispatch} from "redux-thunk";
import {QuestionSetState} from "./QuestionSets/reducer";
import { QuestionState } from './Questions/reducer';
import {reducer as formReducer} from "redux-form"

export interface ApplicationState {
    questionSets: QuestionSetState;
    questions:QuestionState
    router: RouterState;
    form:any
    
}

export type ApplicationDispatch<T extends Action> = ThunkDispatch<ApplicationState, unknown, T>;

export type GetState = () => ApplicationState;
