import { Dispatch } from 'redux';
import { TrueAnswer, TrueAnswerAction } from '../../interfaces/trueAnswer/trueAnswer';
import { setTrueAnswerStart, setTrueAnswerFail } from '../actionCreators/trueAnswerAction';
import { updateTrueAnswerService } from '../../services/trueAnswerService';

export const putTrueAnswer =
  (trueAnswer: TrueAnswer) => async (dispatch: Dispatch<TrueAnswerAction>) => {
    try {
      dispatch(setTrueAnswerStart());
      await updateTrueAnswerService(trueAnswer);
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setTrueAnswerFail(errorMessage));
    }
  };
