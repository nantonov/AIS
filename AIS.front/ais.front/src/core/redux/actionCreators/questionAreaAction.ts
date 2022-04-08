import {
  QuestionArea,
  QuestionAreaAction,
  QuestionAreaActionTypes,
} from '../../interfaces/questionArea/questionArea';

export const setQuestionAreaStart = (): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_START,
});

export const setQuestionAreaSuccess = (questionArea: QuestionArea): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCESS,
  payload: questionArea,
});

export const setQuestionAreaSuccessAll = (questionAreas: QuestionArea[]): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCESS_ALL,
  payload: questionAreas,
});

export const setQuestionAreaFail = (error: string): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_FAIL,
  payload: error,
});
