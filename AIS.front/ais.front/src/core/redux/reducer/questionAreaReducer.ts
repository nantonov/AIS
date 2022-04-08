import {
  QuestionArea,
  QuestionAreaAction,
  QuestionAreaActionTypes,
} from '../../interfaces/questionArea/questionArea';

export interface InitQuestionAreaState {
  questionAreas: QuestionArea[];
  questionArea: QuestionArea | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitQuestionAreaState = {
  questionAreas: [],
  questionArea: null,
  isLoading: false,
  error: null,
};

const questionAreaReducer = (
  state = initialState,
  action: QuestionAreaAction
): InitQuestionAreaState => {
  switch (action.type) {
    case QuestionAreaActionTypes.QUESTION_AREA_START:
      return {
        ...state,
        isLoading: true,
      };
    case QuestionAreaActionTypes.QUESTION_AREA_SUCCESS:
      return {
        ...state,
        isLoading: false,
        questionArea: action.payload,
      };
    case QuestionAreaActionTypes.QUESTION_AREA_SUCCESS_ALL:
      return {
        ...state,
        isLoading: false,
        questionAreas: action.payload,
      };
    case QuestionAreaActionTypes.QUESTION_AREA_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default questionAreaReducer;
