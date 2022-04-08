import { ShortQuestionSet } from '../questionSet/shortQuestionSet';

export enum QuestionAreaActionTypes {
  QUESTION_AREA_START = 'QUESTION_AREA_START',
  QUESTION_AREA_SUCCESS = 'QUESTION_AREA_SUCCESS',
  QUESTION_AREA_SUCCESS_ALL = 'QUESTION_AREA_SUCCESS_ALL',
  QUESTION_AREA_FAIL = 'QUESTION_AREA_FAIL',
}

interface QuestionAreaStartAction {
  type: QuestionAreaActionTypes.QUESTION_AREA_START;
}

interface QuestionAreaSuccessAction {
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCESS;
  payload: QuestionArea;
}

interface QuestionAreaSuccessActionAll {
  type: QuestionAreaActionTypes.QUESTION_AREA_SUCCESS_ALL;
  payload: QuestionArea[];
}

interface QuestionAreaFailAction {
  type: QuestionAreaActionTypes.QUESTION_AREA_FAIL;
  payload: string;
}

export interface QuestionArea {
  id: number;
  name: string;
  questionSets: ShortQuestionSet[];
}

export interface QuestionAreaAdd {
  name: string;
  questionSetsIds: number[];
}

export type QuestionAreaAction =
  | QuestionAreaStartAction
  | QuestionAreaSuccessAction
  | QuestionAreaSuccessActionAll
  | QuestionAreaFailAction;
