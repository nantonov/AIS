import { Dispatch } from 'redux';
import { QuestionAction } from '../../interfaces/question/question';
import QuestionService from '../../services/questionService';
import { questionStart, questionSuccessAll, questionFail } from '../actionCreators/questionAction';

export const getAllQuestions = () => async (dispatch: Dispatch<QuestionAction>) => {
  try {
    dispatch(questionStart());
    const questions = await QuestionService.getAll();
    if (questions) {
      dispatch(questionSuccessAll(questions));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(questionFail(errorMessage));
  }
};
