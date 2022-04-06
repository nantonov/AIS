import {
  ToastMessageAction,
  ToastMessageActionTypes,
  ToastMessage,
} from '../../interfaces/toastMessage';

export const toastMessageStart = (): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_START,
});

export const toastMessageSuccess = (toastMessage: ToastMessage): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_SUCCES,
  payload: toastMessage,
});

export const toastMessageGlobalSet = (toastMessage: ToastMessage): ToastMessageAction => ({
  type: ToastMessageActionTypes.GLOBAL_SET_TOAST_MESSAGE,
  payload: toastMessage,
});

export const toastMessageFail = (error: string): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_FAIL,
  payload: error,
});
