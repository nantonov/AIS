import { ApplicationDispatch } from '../typing';
import { QuestionActions } from './reducer';
import { fetchAll } from './action';
import QuestionService from '../../services/questionService';
import { Question } from '../../interfaces/question/question';

export const getAllData = () => async (dispatch: ApplicationDispatch<QuestionActions>) => {
  const questions = await QuestionService.getAll();
  if (questions) {
    dispatch(fetchAll(questions));
  }
};

export const deleteQuestion =
  (id: number) => async (dispatch: ApplicationDispatch<QuestionActions>) => {
    await QuestionService.deleteById(id);
    dispatch(getAllData());
  };

export const editQuestion =
  (question: Question) => async (dispatch: ApplicationDispatch<QuestionActions>) => {
    const result = await QuestionService.update(question);
    if (result) dispatch(getAllData());
  };

export const createQuestion =
  (question: Question) => async (dispatch: ApplicationDispatch<QuestionActions>) => {
    const result = await QuestionService.create(question);
    if (result) dispatch(getAllData());
  };
