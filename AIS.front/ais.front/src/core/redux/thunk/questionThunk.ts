import { Dispatch } from 'redux';
import { QuestionAction } from '../../interfaces/question/question';
import { setQuestionStart, setQuestionSuccessAll, setQuestionFail } from '../actionCreators/questionAction';
import { getQuestionsAllService } from '../../services/questionService';

export const getAllQuestions = () => async (dispatch: Dispatch<QuestionAction>) => {
  try {
    dispatch(setQuestionStart());
    const questions = await getQuestionsAllService();
    if (questions) {
      dispatch(setQuestionSuccessAll(questions));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionFail(errorMessage));
  }
};
