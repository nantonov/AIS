import { QuestionArea } from '../../interfaces/questionArea/questionArea';
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
  (businessDomain: QuestionArea) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const result = await QuestionAreaService.create(businessDomain);
    if (result) dispatch(fetchAllQuestionAreas());
  };

export const editQuestionArea =
  (businessDomain: QuestionArea) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    const result = await QuestionAreaService.update(businessDomain);
    if (result) dispatch(fetchAllQuestionAreas());
  };

export const deleteQuestionArea =
  (businessDomain: QuestionArea) => async (dispatch: ApplicationDispatch<QuestionAreasActions>) => {
    await QuestionAreaService.deleteById(businessDomain.id).then(() =>
      dispatch(fetchAllQuestionAreas())
    );
  };
