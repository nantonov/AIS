import { combineReducers } from 'redux';
import {ActionType, getType} from 'typesafe-actions';
import * as actions from '../questions/action'
import {Question} from "../../interfaces/question";

export type QuestionState = Readonly<{
    questions: Question[]
}>;

const initialState: QuestionState = {
    questions: []
};

export type QuestionActions = ActionType<typeof actions>;

export const questionReducer = combineReducers<
    QuestionState,
    QuestionActions
    >({
    questions: (state = initialState.questions, action) => {
        switch (action.type) {
            case getType(actions.fetchAll): {
                return [...action.payload];
            }
            default:
                return state;
        }
    },
});
