import { Question, QuestionAction, QuestionActionTypes } from '../../interfaces/question/question';

export const questionStart = (): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_START,
});

export const questionSuccess = (question: Question): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_SUCCESS,
  payload: question,
});

export const questionSuccessAll = (question: Question[]): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_SUCCESS_ALL,
  payload: question,
});

export const questionFail = (error: string): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_FAIL,
  payload: error,
});
