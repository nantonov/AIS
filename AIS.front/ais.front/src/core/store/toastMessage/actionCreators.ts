import { ToastMessage } from '../../interfaces/toastMessage';
import { ApplicationDispatch } from '../typing';
import { ToastActions } from './reducer';
import { setToast } from './actions';

const setToastMessage =
  (error: ToastMessage) =>
  async (dispatch: ApplicationDispatch<ToastActions>) => {
    dispatch(setToast(error));
  };

export default setToastMessage;
