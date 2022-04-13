import { combineReducers } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import defaultTrueAnswer from '../../common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from '../../interfaces/trueAnswer/trueAnswer';
import * as actions from './action';

export type TrueAnswerState = Readonly<{
  trueAnswer: TrueAnswer;
}>;

const initialState: TrueAnswerState = {
  trueAnswer: defaultTrueAnswer,
};

export type TrueAnswerActions = ActionType<typeof actions>;

export const trueAnswerReducer = combineReducers<TrueAnswerState, TrueAnswerActions>({
  trueAnswer: (state = initialState.trueAnswer, action) => {
    switch (action.type) {
      case getType(actions.getTrueAnswerById): {
        return { ...action.payload };
      }
      default:
        return state;
    }
  },
});
