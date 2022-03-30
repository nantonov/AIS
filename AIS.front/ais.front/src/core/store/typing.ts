import {Action} from 'typesafe-actions';
import {RouterState} from "connected-react-router";
import {ThunkDispatch} from "redux-thunk";
import {QuestionSetState} from "./questionSets/reducer";
import { QuestionAreasState } from './questionArea/reducer';
import {QuestionState} from "./questions/reducer";
import { TrueAnswerState } from './trueAnswer/reducer';

export interface ApplicationState {
    questionSets: QuestionSetState;
    questionAreas: QuestionAreasState;
    questions: QuestionState;
    trueAnswers:TrueAnswerState;
    router: RouterState;
}

export type ApplicationDispatch<T extends Action> = ThunkDispatch<ApplicationState, unknown, T>;

