import { ToastMessage } from '../../interfaces/toastMessage';
import { ApplicationDispatch } from '../typing';
import { setToast } from './actions';
import { ToastActions } from './reducer';

export const setToastMessage = (error: ToastMessage) => {
  return async (dispatch: ApplicationDispatch<ToastActions>) => {
    dispatch(setToast(error));
  };
};
