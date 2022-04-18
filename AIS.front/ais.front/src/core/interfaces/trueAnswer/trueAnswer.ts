import { ShortQuestion } from '../question/shortQuestion';

export enum TrueAnswerActionTypes {
  TRUE_ANSWER_START = 'TRUE_ANSWER_START',
  TRUE_ANSWER_SUCCESS = 'TRUE_ANSWER_SUCCESS',
  TRUE_ANSWER_SUCCESS_ALL = 'TRUE_ANSWER_SUCCESS_ALL',
  TRUE_ANSWER_FAIL = 'TRUE_ANSWER_FAIL',
}

interface TrueAnswerStartAction {
  type: TrueAnswerActionTypes.TRUE_ANSWER_START;
}

interface TrueAnswerSuccessAction {
  type: TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS;
  payload: TrueAnswer;
}

interface TrueAnswerSuccessActionAll {
  type: TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS_ALL;
  payload: TrueAnswer[];
}

interface TrueAnswerFailAction {
  type: TrueAnswerActionTypes.TRUE_ANSWER_FAIL;
  payload: string;
}

export interface TrueAnswer {
  id: number;
  text: string;
  questionId: number;
  question: ShortQuestion | null;
}

export type TrueAnswerAction =
  | TrueAnswerStartAction
  | TrueAnswerSuccessAction
  | TrueAnswerSuccessActionAll
  | TrueAnswerFailAction;
