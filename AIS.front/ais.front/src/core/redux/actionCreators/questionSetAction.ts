import {
  QuestionSetAction,
  QuestionSetActionTypes,
  QuestionSet,
} from '../../interfaces/questionSet/questionSet';

export const questionSetStart = (): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_START,
});

export const questionSetSuccess = (questionSet: QuestionSet): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_SUCCES,
  payload: questionSet,
});

export const questionSetSuccessAll = (questionSets: QuestionSet[]): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_SUCCES_ALL,
  payload: questionSets,
});

export const questionSetFail = (error: string): QuestionSetAction => ({
  type: QuestionSetActionTypes.QUESTION_SET_FAIL,
  payload: error,
});
