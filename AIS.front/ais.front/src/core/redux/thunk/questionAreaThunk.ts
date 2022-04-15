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

export const getAllQuestionAreas =
  (token: string) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const questionAreas = await getAllQuestionAreasService(token);
      dispatch(setQuestionAreaSuccessAll(questionAreas));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const getQuestionAreaById =
  (id: number, token: string) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const questionArea = await getQuestionAreaByIdService(id, token);
      dispatch(setQuestionAreaSuccess(questionArea));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const postQuestionArea =
  (questionArea: QuestionAreaAdd, token: string) =>
  async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const result = await createQuestionAreaService(questionArea, token);
      if (result) {
        const questionAreas = await getAllQuestionAreasService(token);
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const putQuestionArea =
  (questionArea: QuestionArea, token: string) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      const result = await updateQuestionAreaService(questionArea, token);
      if (result) {
        const questionAreas = await getAllQuestionAreasService(token);
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };

export const deleteQuestionArea =
  (questionArea: QuestionArea, token: string) => async (dispatch: Dispatch<QuestionAreaAction>) => {
    try {
      dispatch(setQuestionAreaStart());
      await deleteQuestionAreaService(questionArea.id, token).then(async () => {
        const questionAreas = await getAllQuestionAreasService(token);
        dispatch(setQuestionAreaSuccessAll(questionAreas));
      });
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setQuestionAreaFail(errorMessage));
    }
  };
