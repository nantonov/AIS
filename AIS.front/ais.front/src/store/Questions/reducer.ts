import { IQuestion } from './../../DTO/IQuestion';
import { combineReducers } from 'redux';
import {ActionType, getType} from 'typesafe-actions';
import { defaultQuestion } from '../../common/defaultDTO/defaultQuestion';
import * as actions from '../Questions/action';

export type QuestionState = Readonly<{
    questions: IQuestion[]
}>;

const initialState: QuestionState = {
    questions: [
        {
            id: 1,
            text: "First question",
            questionSetid: 1,
            questionSet: null,
            trueAnswer: null
        },
        {
            id: 2,
            text: "Second question",
            questionSetid: 1,
            questionSet: null,
            trueAnswer: null
        },
        {
            id: 3,
            text: "Third question",
            questionSetid: 1,
            questionSet: null,
            trueAnswer: null
        }
    ]
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
    }
});
