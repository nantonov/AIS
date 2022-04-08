import {
  ToastMessageAction,
  ToastMessageActionTypes,
  ToastMessage,
} from '../../interfaces/toastMessage';

export const setToastMessageStart = (): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_START,
});

export const setToastMessageSuccess = (toastMessage: ToastMessage): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_SUCCESS,
  payload: toastMessage,
});

export const setToastMessageGlobalSet = (toastMessage: ToastMessage): ToastMessageAction => ({
  type: ToastMessageActionTypes.GLOBAL_SET_TOAST_MESSAGE,
  payload: toastMessage,
});

export const setToastMessageFail = (error: string): ToastMessageAction => ({
  type: ToastMessageActionTypes.TOAST_MESSAGE_FAIL,
  payload: error,
});
