import { ApplicationDispatch } from '../typing';
import { QuestionActions } from './reducer';
import { fetchAll } from './action';
import QuestionService from '../../services/questionService';

// eslint-disable-next-line  import/prefer-default-export
export const getAllData = () => async (dispatch: ApplicationDispatch<QuestionActions>) => {
  const questions = await QuestionService.getAll();
  if (questions) {
    dispatch(fetchAll(questions));
  }
};
