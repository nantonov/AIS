import { Dispatch } from 'redux';
import {
  questionAreaStart,
  questionAreaSuccess,
  questionAreaSuccessAll,
  questionAreaFail,
} from '../actionCreators/questionAreaAction';
import {
  QuestionArea,
  QuestionAreaAction,
  QuestionAreaAdd,
} from '../../interfaces/questionArea/questionArea';
import QuestionAreaService from '../../services/questionAreaService';

export const getAllQuestionAreas = () => async (dispatch: Dispatch<QuestionAreaAction>) => {
  try {
    dispatch(questionAreaStart());
    const questionAreas = await QuestionAreaService.getAll();
    dispatch(questionAreaSuccessAll(questionAreas));
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(questionAreaFail(errorMessage));
  }
};

export const getQuestionAreaById =
  (id: number) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(questionAreaStart());
      const questionArea = await QuestionAreaService.getById(id);
      dispatch(questionAreaSuccess(questionArea));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(questionAreaFail(errorMessage));
    }
  };

export const postQuestionArea =
  (questionArea: QuestionAreaAdd) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(questionAreaStart());
      const result = await QuestionAreaService.create(questionArea);
      if (result) {
        const questionAreas = await QuestionAreaService.getAll();
        dispatch(questionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(questionAreaFail(errorMessage));
    }
  };

export const putQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(questionAreaStart());
      const result = await QuestionAreaService.update(questionArea);
      if (result) {
        const questionAreas = await QuestionAreaService.getAll();
        dispatch(questionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(questionAreaFail(errorMessage));
    }
  };

export const deleteQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(questionAreaStart());
      await QuestionAreaService.deleteById(questionArea.id).then(async () => {
        const questionAreas = await QuestionAreaService.getAll();
        dispatch(questionAreaSuccessAll(questionAreas));
      });
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(questionAreaFail(errorMessage));
    }
  };
