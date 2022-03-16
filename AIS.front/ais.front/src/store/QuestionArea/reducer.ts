import {combineReducers} from 'redux';
import {IQuestionArea} from '../../DTO/IQuestionArea'
import {ActionType, getType} from 'typesafe-actions';

import * as actions from './actions';

export type QuestionAreasState = Readonly<{
    questionAreas: IQuestionArea[],
    questionArea: IQuestionArea | null
}>;

const initialState: QuestionAreasState = {
    questionAreas: [],
    questionArea: null
};

export type questionAreasActions = ActionType<typeof actions>;

export const questionAreasReducer = combineReducers<QuestionAreasState,
    questionAreasActions>({
    questionAreas: (state = initialState.questionAreas, action) => {
        switch (action.type) {
            case getType(actions.fetchAll): {
                return [...action.payload];
            }
            default:
                return state;
        }
    },
    questionArea: (state = initialState.questionArea, action) => {
        switch (action.type) {
            case getType(actions.fetchById): {
                return action.payload;
            }
            default:
                return state;
        }
    },
    });
