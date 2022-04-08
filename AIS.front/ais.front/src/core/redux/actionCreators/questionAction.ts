import { Question, QuestionAction, QuestionActionTypes } from '../../interfaces/question/question';

export const setQuestionStart = (): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_START,
});

export const setQuestionSuccess = (question: Question): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_SUCCESS,
  payload: question,
});

export const setQuestionSuccessAll = (question: Question[]): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_SUCCESS_ALL,
  payload: question,
});

export const setQuestionFail = (error: string): QuestionAction => ({
  type: QuestionActionTypes.QUESTION_FAIL,
  payload: error,
});
