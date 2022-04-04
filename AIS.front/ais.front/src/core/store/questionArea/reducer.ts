import { combineReducers } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import { QuestionArea } from '../../interfaces/questionArea/questionArea';

import * as actions from './actions';

export type QuestionAreasState = Readonly<{
  questionAreas: QuestionArea[];
  questionArea: QuestionArea | null;
}>;

const initialState: QuestionAreasState = {
  questionAreas: [],
  questionArea: null,
};

export type QuestionAreasActions = ActionType<typeof actions>;

export const questionAreasReducer = combineReducers<QuestionAreasState, QuestionAreasActions>({
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