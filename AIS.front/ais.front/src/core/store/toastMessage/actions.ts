import { createAction } from 'typesafe-actions';
import { ToastMessage } from '../../interfaces/toastMessage';
import { SET_TOAST_MESSAGE, GLOBAL_SET_TOAST_MESSAGE } from './constants';

export const setToast = createAction(SET_TOAST_MESSAGE)<ToastMessage>();
export const setGlobalToast = createAction(GLOBAL_SET_TOAST_MESSAGE)<ToastMessage>();

