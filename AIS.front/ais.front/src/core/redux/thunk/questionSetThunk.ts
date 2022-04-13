import { Dispatch } from 'redux';
import {
  setQuestionSetStart,
  setQuestionSetSuccess,
  setQuestionSetSuccessAll,
  setQuestionSetFail,
} from '../actionCreators/questionSetAction';
import { QuestionSetAction } from '../../interfaces/questionSet/questionSet';
import {
  deleteQuestionService,
  getQuestionByIdService,
  getQuestionSetsAllService,
} from '../../services/questionSetService';

export const getAllQuestionSets = () => async (dispatch: Dispatch<QuestionSetAction>) => {
  try {
    dispatch(setQuestionSetStart());
    const questionSets = await getQuestionSetsAllService();
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
    const questionSet = await getQuestionByIdService(id);
    if (questionSet) {
      dispatch(setQuestionSetSuccess(questionSet));
    }
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionSetFail(errorMessage));
  }
};

export const deleteQuestionSetById =
  (id: number) => async (dispatch: Dispatch<QuestionSetAction>) => {
    try {
      dispatch(setQuestionSetStart());
      await deleteQuestionService(id);
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionSetFail(errorMessage));
    }
  };
