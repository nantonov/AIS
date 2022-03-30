import { defaultTrueAnswer } from './../../common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from './../../interfaces/trueAnswer';
import { combineReducers } from 'redux';
import {ActionType, getType} from 'typesafe-actions';
import * as actions from '../trueAnswer/action';

export type TrueAnswerState = Readonly<{
    trueAnswer: TrueAnswer
}>;

const initialState: TrueAnswerState = {
    trueAnswer: defaultTrueAnswer
};

export type TrueAnswerActions = ActionType<typeof actions>;

export const trueAnswerReducer = combineReducers<
    TrueAnswerState,
    TrueAnswerActions
    >({
    trueAnswer:(state = initialState.trueAnswer, action)=>{
        switch (action.type) {
            case getType(actions.getTrueAnswerById): {
                return {...action.payload};
            }
            default:
                return state;
        }
    }
});
