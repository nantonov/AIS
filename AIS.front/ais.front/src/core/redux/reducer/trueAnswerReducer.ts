import {
  TrueAnswer,
  TrueAnswerActionTypes,
  TrueAnswerAction,
} from '../../interfaces/trueAnswer/trueAnswer';

export interface InitQuestionState {
  trueAnswers: TrueAnswer[];
  trueAnswer: TrueAnswer | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitQuestionState = {
  trueAnswers: [],
  trueAnswer: null,
  isLoading: false,
  error: null,
};

const trueAnswerReducer = (state = initialState, action: TrueAnswerAction): InitQuestionState => {
  switch (action.type) {
    case TrueAnswerActionTypes.TRUE_ANSWER_START:
      return {
        ...state,
        isLoading: true,
      };
    case TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS:
      return {
        ...state,
        isLoading: false,
        trueAnswer: action.payload,
      };
    case TrueAnswerActionTypes.TRUE_ANSWER_SUCCESS_ALL:
      return {
        ...state,
        isLoading: false,
        trueAnswers: action.payload,
      };
    case TrueAnswerActionTypes.TRUE_ANSWER_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default trueAnswerReducer;
