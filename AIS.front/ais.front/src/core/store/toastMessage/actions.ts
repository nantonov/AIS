import { ToastMessage } from '../../interfaces/toastMessage';
import { SET_TOAST_MESSAGE, GLOBAL_SET_TOAST_MESSAGE } from './constants';
import {createAction} from "typesafe-actions";

export const setToast = createAction(SET_TOAST_MESSAGE)<ToastMessage>();
export const setGlobalToast = createAction(GLOBAL_SET_TOAST_MESSAGE)<ToastMessage>();

