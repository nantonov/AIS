import { Dispatch } from 'redux';
import { QuestionAction } from '../../interfaces/question/question';
import QuestionService from '../../services/questionService';
import { setQuestionStart, setQuestionSuccessAll, setQuestionFail } from '../actionCreators/questionAction';

export const getAllQuestions = () => async (dispatch: Dispatch<QuestionAction>) => {
  try {
    dispatch(setQuestionStart());
    const questions = await QuestionService.getAll();
    if (questions) {
      dispatch(setQuestionSuccessAll(questions));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionFail(errorMessage));
  }
};
