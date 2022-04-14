import { AlertColor } from '@mui/material/Alert';

export enum ToastMessageActionTypes {
  TOAST_MESSAGE_START = 'TOAST_MESSAGE_START',
  TOAST_MESSAGE_SUCCESS = 'TOAST_MESSAGE_SUCCESS',
  TOAST_MESSAGE_FAIL = 'TOAST_MESSAGE_FAIL',
  GLOBAL_SET_TOAST_MESSAGE = 'GLOBAL_SET_TOAST_MESSAGE',
}

interface ToastMessageStartAction {
  type: ToastMessageActionTypes.TOAST_MESSAGE_START;
}

interface ToastMessageSuccessAction {
  type: ToastMessageActionTypes.TOAST_MESSAGE_SUCCESS;
  payload: ToastMessage;
}

interface ToastMessageGlobalSetAction {
  type: ToastMessageActionTypes.GLOBAL_SET_TOAST_MESSAGE;
  payload: ToastMessage;
}

interface ToastMessageFailAction {
  type: ToastMessageActionTypes.TOAST_MESSAGE_FAIL;
  payload: string;
}

export interface ToastMessage {
  visible: boolean;
  text: string;
  severity: AlertColor;
}

export type ToastMessageAction =
  | ToastMessageStartAction
  | ToastMessageSuccessAction
  | ToastMessageFailAction
  | ToastMessageGlobalSetAction;
