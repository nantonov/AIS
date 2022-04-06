import { Dispatch } from 'redux';
import {
  questionSetStart,
  questionSetSuccess,
  questionSetSuccessAll,
  questionSetFail,
} from '../actionCreators/questionSetAction';
import { QuestionSetAction } from '../../interfaces/questionSet/questionSet';
import QuestionSetService from '../../services/questionSetService';

export const getAllQuestionSets = () => async (dispatch: Dispatch<QuestionSetAction>) => {
  try {
    dispatch(questionSetStart());
    const questionSets = await QuestionSetService.getAll();
    if (questionSets) {
      dispatch(questionSetSuccessAll(questionSets));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(questionSetFail(errorMessage));
  }
};

export const getQuestionSetById = (id: number) => async (dispatch: Dispatch<QuestionSetAction>) => {
  try {
    dispatch(questionSetStart());
    const questionSet = await QuestionSetService.getById(id);
    if (questionSet) {
      dispatch(questionSetSuccess(questionSet));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(questionSetFail(errorMessage));
  }
};
