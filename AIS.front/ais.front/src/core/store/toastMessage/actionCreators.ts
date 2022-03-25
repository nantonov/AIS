import { ToastMessage } from '../../interfaces/toastMessage';
import { ApplicationDispatch } from '../typing';
import { ToastActions } from './reducer';
import { setToast } from './actions';

export const setToastMessage = (error: ToastMessage) => {
  return async (dispatch: ApplicationDispatch<ToastActions>) => {
    dispatch(setToast(error));
  };
};
