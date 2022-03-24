import { QuestionArea} from '../../interfaces/questionArea'
import { QuestionAreaService } from '../../services/questionAreaService';
import { ApplicationDispatch } from '../typing';
import { fetchAll, fetchById} from './actions';
import { questionAreasActions } from './reducer';

export const fetchAllQuestionAreas = () => {
  return async (dispatch: ApplicationDispatch<questionAreasActions>) => {
    const questionAreas = await QuestionAreaService.getAll();
    dispatch(fetchAll(questionAreas));
  };
};

export const fetchQuestionAreaById = (id: number) => {
  return async (dispatch: ApplicationDispatch<questionAreasActions>) => {
    const questionArea = await QuestionAreaService.getById(id);
    dispatch(fetchById(questionArea));
  };
};

export const createQuestionArea = (businessDomain: QuestionArea) => {
  return async (dispatch: ApplicationDispatch<questionAreasActions>) => {
    const result = await QuestionAreaService.create(businessDomain);
    if (result) dispatch(fetchAllQuestionAreas());
  };
};

export const editQuestionArea = (businessDomain: QuestionArea) => {
  return async (dispatch: ApplicationDispatch<questionAreasActions>) => {
    const result = await QuestionAreaService.update(businessDomain);
    if (result) dispatch(fetchAllQuestionAreas());
  };
};

export const deleteQuestionArea = (businessDomain: QuestionArea) => {
  return async (dispatch: ApplicationDispatch<questionAreasActions>) => {
      await QuestionAreaService.deleteById(businessDomain.id)
        .then(() => dispatch(fetchAllQuestionAreas()))
        .catch((err) => {console.log(err.response);
      });
  };
};
