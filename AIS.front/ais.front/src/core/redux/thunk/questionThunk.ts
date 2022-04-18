import { Dispatch } from 'redux';
import { Question, QuestionAction } from '../../interfaces/question/question';
import {
  setQuestionStart,
  setQuestionSuccessAll,
  setQuestionFail,
} from '../actionCreators/questionAction';
import {
  deleteQuestionService,
  getQuestionsAllService,
  updateQuestionService,
} from '../../services/questionService';

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

export const deleteQuestionById = (id: number) => async (dispatch: Dispatch<QuestionAction>) => {
  try {
    dispatch(setQuestionStart());
    await deleteQuestionService(id);
    const questions = await getQuestionsAllService();
    dispatch(setQuestionSuccessAll(questions));
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionFail(errorMessage));
  }
};

export const putQuestion = (question: Question) => async (dispatch: Dispatch<QuestionAction>) => {
  try {
    dispatch(setQuestionStart());
    const result = await updateQuestionService(question);
    if (result) {
      const questions = await getQuestionsAllService();
      dispatch(setQuestionSuccessAll(questions));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionFail(errorMessage));
  }
};
