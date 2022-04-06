import { Dispatch } from 'redux';
import { ToastMessage, ToastMessageAction } from '../../interfaces/toastMessage';
import {
  toastMessageStart,
  toastMessageSuccess,
  toastMessageFail,
} from '../actionCreators/toastMessageAction';

const setToastMessage =
  (massage: ToastMessage) => async (dispatch: Dispatch<ToastMessageAction>) => {
    try {
      dispatch(toastMessageStart());
      dispatch(toastMessageSuccess(massage));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(toastMessageFail(errorMessage));
    }
  };

export default setToastMessage;
