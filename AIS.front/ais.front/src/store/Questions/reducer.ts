import { combineReducers } from 'redux';
import {ActionType, getType} from 'typesafe-actions';
import * as actions from '../Questions/action'
import {IQuestion} from "../../DTO/IQuestion";

export type QuestionsState = Readonly<{
    questions: IQuestion[]
}>;

const initialState: QuestionsState = {
    questions: []
};

export type QuestionsActions = ActionType<typeof actions>;

export const questionsReducer = combineReducers<
    QuestionsState,
    QuestionsActions
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
