import { TrueAnswer } from './../../interfaces/trueAnswer';
import { TrueAnswerService } from './../../services/trueAnswerService';
import {ApplicationDispatch} from "../typing";
import { TrueAnswerActions} from "./reducer";
import { getTrueAnswerById} from "./action";


export const getById = (id: number) => {
    return async (dispatch: ApplicationDispatch<TrueAnswerActions>) => {
        const trueAnswer = await TrueAnswerService.getById(id);
        if (trueAnswer) {
            dispatch(getTrueAnswerById(trueAnswer));
        }
    };
};

export const editTrueAnswer = (trueAnswer: TrueAnswer) => {
  return async (dispatch: ApplicationDispatch<TrueAnswerActions>) => {
    const result = await TrueAnswerService.update(trueAnswer);
    if (result) dispatch(getTrueAnswerById(trueAnswer));
  };
};
