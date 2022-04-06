import {
  QuestionArea,
  QuestionAreaAction,
  QuestionAreaActionTypes,
} from '../../interfaces/questionArea/questionArea';

export const questionAreaStart = (): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_START,
});

export const questionAreaSuccess = (questionArea: QuestionArea): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCES,
  payload: questionArea,
});

export const questionAreaSuccessAll = (questionAreas: QuestionArea[]): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCES_ALL,
  payload: questionAreas,
});

export const questionAreaFail = (error: string): QuestionAreaAction => ({
  type: QuestionAreaActionTypes.QUESTION_AREA_FAIL,
  payload: error,
});
