import { combineReducers } from 'redux';
import {ActionType, getType} from 'typesafe-actions';
import * as actions from '../QuestionSets/action';
import {IQuestionSet} from "../../DTO/IQuestionSet";
import {defaultQuestionSet} from "../../common/defaultDTO/defaultQuestionSet";

export type QuestionSetState = Readonly<{
    questionSets: IQuestionSet[],
    questionSet: IQuestionSet,
}>;

const initialState: QuestionSetState = {
    questionSets: [],
    questionSet: defaultQuestionSet
};

export type QuestionSetActions = ActionType<typeof actions>;

export const questionSetReducer = combineReducers<
    QuestionSetState,
    QuestionSetActions
    >({
    questionSets: (state = initialState.questionSets, action) => {
        switch (action.type) {
            case getType(actions.fetchAll): {
                console.log(...action.payload)
                return [...action.payload];
            }
            default:
                return state;
        }
    },
    questionSet:(state = initialState.questionSet, action)=>{
        switch (action.type) {
            case getType(actions.getQuestionSetById): {
                return {...action.payload};
            }
            default:
                return state;
        }
    }
});
