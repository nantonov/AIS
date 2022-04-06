import {
  ToastMessage,
  ToastMessageAction,
  ToastMessageActionTypes,
} from '../../interfaces/toastMessage';

export interface InitQuestionSetState {
  toastMessage: ToastMessage | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitQuestionSetState = {
  toastMessage: null,
  isLoading: false,
  error: null,
};

const toastMessageReducer = (
  state = initialState,
  action: ToastMessageAction
): InitQuestionSetState => {
  switch (action.type) {
    case ToastMessageActionTypes.TOAST_MESSAGE_START:
      return {
        ...state,
        isLoading: true,
      };
    case ToastMessageActionTypes.TOAST_MESSAGE_SUCCES:
      return {
        ...state,
        isLoading: false,
        toastMessage: action.payload,
      };
    case ToastMessageActionTypes.TOAST_MESSAGE_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default toastMessageReducer;
