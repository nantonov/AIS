import { ShortQuestionSet } from '../questionSet/shortQuestionSet';
import { ShortTrueAnswer } from '../trueAnswer/shortTrueAnswer';

export enum QuestionActionTypes {
  QUESTION_START = 'QUESTION_START',
  QUESTION_SUCCES = 'QUESTION_SUCCES',
  QUESTION_SUCCES_ALL = 'QUESTION_SUCCES_ALL',
  QUESTION_FAIL = 'QUESTION_FAIL',
}

interface QuestionStartAction {
  type: QuestionActionTypes.QUESTION_START;
}

interface QuestionSuccessAction {
  type: QuestionActionTypes.QUESTION_SUCCES;
  payload: Question;
}

interface QuestionSuccessActionAll {
  type: QuestionActionTypes.QUESTION_SUCCES_ALL;
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
  trueAnswer: ShortTrueAnswer | null;
}

export type QuestionAction =
  | QuestionStartAction
  | QuestionSuccessAction
  | QuestionSuccessActionAll
  | QuestionFailAction;
