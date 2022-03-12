import {Action} from 'typesafe-actions';
import {RouterState} from "connected-react-router";
import {ThunkDispatch} from "redux-thunk";
import {QuestionSetState} from "./QuestionSets/reducer";
import { QuestionAreasState } from './QuestionArea/reducer';

export interface ApplicationState {
    questionSets: QuestionSetState;
    questionAreas: QuestionAreasState;
    router: RouterState;
}

export type ApplicationDispatch<T extends Action> = ThunkDispatch<ApplicationState, unknown, T>;

export type GetState = () => ApplicationState;
