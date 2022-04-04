import QuestionSetService from '../../services/questionSetService';
import { ApplicationDispatch } from '../typing';
import { QuestionSetActions } from './reducer';
import { fetchAll, getQuestionSetById } from './action';

export const getAllData = () => async (dispatch: ApplicationDispatch<QuestionSetActions>) => {
  const questionSets = await QuestionSetService.getAll();
  if (questionSets) {
    dispatch(fetchAll(questionSets));
  }
};

export const getById =
  (id: number) => async (dispatch: ApplicationDispatch<QuestionSetActions>) => {
    const questionSet = await QuestionSetService.getById(id);
    if (questionSet) {
      dispatch(getQuestionSetById(questionSet));
    }
  };
