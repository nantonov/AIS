import { ShortQuestion } from '../question/shortQuestion';
import { ShortQuestionArea } from '../questionArea/shortQuestionArea';

export enum QuestionSetActionTypes {
  QUESTION_SET_START = 'QUESTION_SET_START',
  QUESTION_SET_SUCCESS = 'QUESTION_SET_SUCCESS',
  QUESTION_SET_SUCCESS_ALL = 'QUESTION_SET_SUCCESS_ALL',
  QUESTION_SET_FAIL = 'QUESTION_SET_FAIL',
}

interface QuestionSetStartAction {
  type: QuestionSetActionTypes.QUESTION_SET_START;
}

interface QuestionSetSuccessAction {
  type: QuestionSetActionTypes.QUESTION_SET_SUCCESS;
  payload: QuestionSet;
}

interface QuestionSetSuccessActionAll {
  type: QuestionSetActionTypes.QUESTION_SET_SUCCESS_ALL;
  payload: QuestionSet[];
}

interface QuestionSetFailAction {
  type: QuestionSetActionTypes.QUESTION_SET_FAIL;
  payload: string;
}

export interface QuestionSet {
  id: number;
  name: string;
  questionAreaId: number;
  questionAreas: ShortQuestionArea[];
  questions: ShortQuestion[];
}
export interface QuestionSetAddState {
  name: string;
  questionAreaIds: number[];
  questionIds: number[];
}

export type QuestionSetAction =
  | QuestionSetStartAction
  | QuestionSetSuccessAction
  | QuestionSetSuccessActionAll
  | QuestionSetFailAction;
