import { Dispatch } from 'redux';
import {
  setQuestionSetStart,
  setQuestionSetSuccess,
  setQuestionSetSuccessAll,
  setQuestionSetFail,
} from '../actionCreators/questionSetAction';
import { QuestionSetAction } from '../../interfaces/questionSet/questionSet';
import QuestionSetService from '../../services/questionSetService';

export const getAllQuestionSets = () => async (dispatch: Dispatch<QuestionSetAction>) => {
  try {
    dispatch(setQuestionSetStart());
    const questionSets = await QuestionSetService.getAll();
    if (questionSets) {
      dispatch(setQuestionSetSuccessAll(questionSets));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionSetFail(errorMessage));
  }
};

export const getQuestionSetById = (id: number) => async (dispatch: Dispatch<QuestionSetAction>) => {
  try {
    dispatch(setQuestionSetStart());
    const questionSet = await QuestionSetService.getById(id);
    if (questionSet) {
      dispatch(setQuestionSetSuccess(questionSet));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionSetFail(errorMessage));
  }
};
