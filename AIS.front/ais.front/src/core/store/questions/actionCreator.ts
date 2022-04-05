import { Question } from './../../interfaces/question';
import {ApplicationDispatch} from "../typing";
import {QuestionActions} from "./reducer";
import {fetchAll} from "./action";
import {QuestionService} from "../../services/questionService";

export const getAllData = () => {
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        const questions = await QuestionService.getAll();
        if (questions) {
            dispatch(fetchAll(questions));
        }
    };
};

export const deleteQuestion = (id: number) => {
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        await QuestionService.deleteById(id)
        dispatch(getAllData());
    };
  };

export const editQuestion = (question: Question) => {
  return async (dispatch: ApplicationDispatch<QuestionActions>) => {
    const result = await QuestionService.update(question);
    if (result) dispatch(getAllData());
  };
};

export const createQuestion = (question: Question) => {
  return async (dispatch: ApplicationDispatch<QuestionActions>) => {
    const result = await QuestionService.create(question);
    if (result) dispatch(getAllData());
  };
};

