import { IToastMessage } from '../../DTO/IToastMessage';
import { ApplicationDispatch } from '../typing';
import { setToast } from './actions';
import { ToastActions } from './reducer';

export const setToastMessage = (error: IToastMessage) => {
  return async (dispatch: ApplicationDispatch<ToastActions>) => {
    dispatch(setToast(error));
  };
};
