import {
  QuestionSetAction,
  QuestionSetActionTypes,
  QuestionSet,
} from '../../interfaces/questionSet/questionSet';

export const setQuestionSetStart = (): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_START,
});

export const setQuestionSetSuccess = (questionSet: QuestionSet): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_SUCCESS,
  payload: questionSet,
});

export const setQuestionSetSuccessAll = (questionSets: QuestionSet[]): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_SUCCESS_ALL,
  payload: questionSets,
});

export const setQuestionSetFail = (error: string): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_FAIL,
  payload: error,
});
