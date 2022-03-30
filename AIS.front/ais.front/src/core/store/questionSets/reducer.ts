import { combineReducers } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import * as actions from './action';
import { QuestionSet } from '../../interfaces/questionSet/questionSet';
import { defaultQuestionSet } from '../../common/defaultDTO/defaultQuestionSet';

export type QuestionSetState = Readonly<{
  questionSets: QuestionSet[];
  questionSet: QuestionSet;
}>;

const initialState: QuestionSetState = {
  questionSets: [],
  questionSet: defaultQuestionSet,
};

export type QuestionSetActions = ActionType<typeof actions>;

export const questionSetReducer = combineReducers<QuestionSetState, QuestionSetActions>({
  // eslint-disable-next-line @typescript-eslint/default-param-last
  questionSets: (state = initialState.questionSets, action) => {
    switch (action.type) {
      case getType(actions.fetchAll): {
        return [...action.payload];
      }
      default:
        return state;
    }
  },
  // eslint-disable-next-line @typescript-eslint/default-param-last
  questionSet: (state = initialState.questionSet, action) => {
    switch (action.type) {
      case getType(actions.getQuestionSetById): {
        return { ...action.payload };
      }
      default:
        return state;
    }
  },
});
