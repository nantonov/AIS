import { TrueAnswer } from '../trueAnswer/trueAnswer';
import { ShortQuestionSet } from '../questionSet/shortQuestionSet';
import { ShortTrueAnswer } from '../trueAnswer/shortTrueAnswer';

export enum QuestionActionTypes {
  QUESTION_START = 'QUESTION_START',
  QUESTION_SUCCESS = 'QUESTION_SUCCESS',
  QUESTION_SUCCESS_ALL = 'QUESTION_SUCCESS_ALL',
  QUESTION_FAIL = 'QUESTION_FAIL',
}

interface QuestionStartAction {
  type: QuestionActionTypes.QUESTION_START;
}

interface QuestionSuccessAction {
  type: QuestionActionTypes.QUESTION_SUCCESS;
  payload: Question;
}

interface QuestionSuccessActionAll {
  type: QuestionActionTypes.QUESTION_SUCCESS_ALL;
  payload: Question[];
}

interface QuestionFailAction {
  type: QuestionActionTypes.QUESTION_FAIL;
  payload: string;
}

export interface Question {
  id: number;
  text: string;
  questionSetid: number;
  questionSet: ShortQuestionSet | null;
  trueAnswer: TrueAnswer | ShortTrueAnswer | null;
}

export type QuestionAction =
  | QuestionStartAction
  | QuestionSuccessAction
  | QuestionSuccessActionAll
  | QuestionFailAction;
