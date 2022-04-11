import { Dispatch } from 'redux';
import {
  setQuestionAreaStart,
  setQuestionAreaSuccess,
  setQuestionAreaSuccessAll,
  setQuestionAreaFail,
} from '../actionCreators/questionAreaAction';
import {
  QuestionArea,
  QuestionAreaAction,
  QuestionAreaAdd,
} from '../../interfaces/questionArea/questionArea';
import {
  getAllQuestionAreasService,
  getQuestionAreaByIdService,
  createQuestionAreaService,
  deleteQuestionAreaService,
  updateQuestionAreaService,
} from '../../services/questionAreaService';

export const getAllQuestionAreas = () => async (dispatch: Dispatch<QuestionAreaAction>) => {
  try {
    dispatch(setQuestionAreaStart());
    const questionAreas = await getAllQuestionAreasService();
    dispatch(setQuestionAreaSuccessAll(questionAreas));
  } catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setQuestionAreaFail(errorMessage));
  }
};

export const getQuestionAreaById =
  (id: number) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const questionArea = await getQuestionAreaByIdService(id);
      dispatch(setQuestionAreaSuccess(questionArea));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const postQuestionArea =
  (questionArea: QuestionAreaAdd) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const result = await createQuestionAreaService(questionArea);
      if (result) {
        const questionAreas = await getAllQuestionAreasService();
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const putQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const result = await updateQuestionAreaService(questionArea);
      if (result) {
        const questionAreas = await getAllQuestionAreasService();
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const deleteQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      await deleteQuestionAreaService(questionArea.id).then(async () => {
        const questionAreas = await getAllQuestionAreasService();
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      });
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };
