import { createAction } from 'typesafe-actions';
import { IToastMessage } from '../../DTO/IToastMessage';
import { SET_TOAST_MESSAGE, GLOBAL_SET_TOAST_MESSAGE } from './constants';

export const setToast = createAction(SET_TOAST_MESSAGE)<IToastMessage>();
export const setGlobalToast = createAction(GLOBAL_SET_TOAST_MESSAGE)<IToastMessage>();

