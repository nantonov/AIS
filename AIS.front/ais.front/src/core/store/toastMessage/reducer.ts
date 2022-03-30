import { combineReducers } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import { ToastMessage } from '../../interfaces/toastMessage';
import * as actions from './actions';

export type ToastState = Readonly<{
  toastMessage: ToastMessage;
}>;

const initialState: ToastState = {
  toastMessage: { text: '', visible: false, severity: 'success' },
};

export type ToastActions = ActionType<typeof actions>;

export const toastReducer = combineReducers<ToastState, ToastActions>({
  // eslint-disable-next-line @typescript-eslint/default-param-last
  toastMessage: (state = initialState.toastMessage, action) => {
    switch (action.type) {
      case getType(actions.setToast): {
        return { ...action.payload };
      }
      default:
        return state;
    }
  },
});
