import { Dispatch } from 'redux';
import { ToastMessage, ToastMessageAction } from '../../interfaces/toastMessage';
import {
  setToastMessageStart,
  setToastMessageSuccess,
  setToastMessageFail,
} from '../actionCreators/toastMessageAction';

const setToastMessage =
  (massage: ToastMessage) => async (dispatch: Dispatch<ToastMessageAction>) => {
    try {
      dispatch(setToastMessageStart());
      dispatch(setToastMessageSuccess(massage));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setToastMessageFail(errorMessage));
    }
  };

export default setToastMessage;
