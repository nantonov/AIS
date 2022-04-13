import { ApplicationDispatch } from '../typing';
import { TrueAnswerActions } from './reducer';
import { getTrueAnswerById } from './action';
import TrueAnswerService from '../../services/trueAnswerService';
import { TrueAnswer } from '../../interfaces/trueAnswer/trueAnswer';

export const getById = (id: number) => async (dispatch: ApplicationDispatch<TrueAnswerActions>) => {
  const trueAnswer = await TrueAnswerService.getById(id);
  if (trueAnswer) {
    dispatch(getTrueAnswerById(trueAnswer));
  }
};

export const editTrueAnswer =
  (trueAnswer: TrueAnswer) => async (dispatch: ApplicationDispatch<TrueAnswerActions>) => {
    const result = await TrueAnswerService.update(trueAnswer);
    if (result) dispatch(getTrueAnswerById(trueAnswer));
  };
