import { QuestionArea, QuestionAreaAdd } from '../../interfaces/questionArea/questionArea';
import QuestionAreaService from '../../services/questionAreaService';
import { ApplicationDispatch } from '../typing';
import { fetchAll, fetchById } from './actions';
import { QuestionAreasActions } from './reducer';

export const fetchAllQuestionAreas =
  () => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const questionAreas = await QuestionAreaService.getAll();
    dispatch(fetchAll(questionAreas));
  };

export const fetchQuestionAreaById =
  (id: number) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const questionArea = await QuestionAreaService.getById(id);
    dispatch(fetchById(questionArea));
  };

export const createQuestionArea =
  (questionArea: QuestionAreaAdd) =>
  async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const result = await QuestionAreaService.create(questionArea);
    if (result) dispatch(fetchAllQuestionAreas());
  };

export const editQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const result = await QuestionAreaService.update(questionArea);
    if (result) dispatch(fetchAllQuestionAreas());
  };

export const deleteQuestionArea =
  (questionArea: QuestionArea) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    await QuestionAreaService.deleteById(questionArea.id).then(() =>
      dispatch(fetchAllQuestionAreas())
    );
  };
