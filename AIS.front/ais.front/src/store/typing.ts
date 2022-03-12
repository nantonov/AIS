import {Action} from 'typesafe-actions';
import {RouterState} from "connected-react-router";
import {ThunkDispatch} from "redux-thunk";
import {QuestionSetState} from "./QuestionSets/reducer";

export interface ApplicationState {
    questionSets: QuestionSetState;
    router: RouterState;
}

export type ApplicationDispatch<T extends Action> = ThunkDispatch<ApplicationState, unknown, T>;

export type GetState = () => ApplicationState;
