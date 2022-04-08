import {
  QuestionSetAction,
  QuestionSetActionTypes,
  QuestionSet,
} from '../../interfaces/questionSet/questionSet';

export interface InitQuestionSetState {
  questionSets: QuestionSet[];
  questionSet: QuestionSet | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitQuestionSetState = {
  questionSets: [],
  questionSet: null,
  isLoading: false,
  error: null,
};

const questionSetReducer = (
  state = initialState,
  action: QuestionSetAction
): InitQuestionSetState => {
  switch (action.type) {
    case QuestionSetActionTypes.QUESTION_SET_START:
      return {
        ...state,
        isLoading: true,
      };
    case QuestionSetActionTypes.QUESTION_SET_SUCCESS:
      return {
        ...state,
        isLoading: false,
        questionSet: action.payload,
      };
    case QuestionSetActionTypes.QUESTION_SET_SUCCESS_ALL:
      return {
        ...state,
        isLoading: false,
        questionSets: action.payload,
      };
    case QuestionSetActionTypes.QUESTION_SET_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default questionSetReducer;
