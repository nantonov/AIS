import { Question, QuestionAction, QuestionActionTypes } from '../../interfaces/question/question';

export interface InitQuestionState {
  questions: Question[];
  question: Question | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitQuestionState = {
  questions: [],
  question: null,
  isLoading: false,
  error: null,
};

const questionReducer = (state = initialState, action: QuestionAction): InitQuestionState => {
  switch (action.type) {
    case QuestionActionTypes.QUESTION_START:
      return {
        ...state,
        isLoading: true,
      };
    case QuestionActionTypes.QUESTION_SUCCESS:
      return {
        ...state,
        isLoading: false,
        question: action.payload,
      };
    case QuestionActionTypes.QUESTION_SUCCESS_ALL:
      return {
        ...state,
        isLoading: false,
        questions: action.payload,
      };
    case QuestionActionTypes.QUESTION_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default questionReducer;
