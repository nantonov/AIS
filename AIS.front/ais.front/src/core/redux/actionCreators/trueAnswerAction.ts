import {
  TrueAnswer,
  TrueAnswerActionTypes,
  TrueAnswerAction,
} from '../../interfaces/trueAnswer/trueAnswer';

export const setTrueAnswerStart = (): TrueAnswerAction => ({
  type: TrueAnswerActionTypes.TRUE_ANSWER_START,
});

export const setTrueAnswerSuccess = (trueAnswers: TrueAnswer): TrueAnswerAction => ({
  type: TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS,
  payload: trueAnswers,
});

export const setTrueAnswerSuccessAll = (trueAnswers: TrueAnswer[]): TrueAnswerAction => ({
  type: TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS_ALL,
  payload: trueAnswers,
});

export const setTrueAnswerFail = (error: string): TrueAnswerAction => ({
  type: TrueAnswerActionTypes.TRUE_ANSWER_FAIL,
  payload: error,
});
