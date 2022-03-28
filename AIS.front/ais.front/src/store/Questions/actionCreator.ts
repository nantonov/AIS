import { QuestionService } from './../../services/QuestionService';
import {ApplicationDispatch} from "../typing";
import {QuestionActions} from "./reducer";
import {fetchAll} from "./action";
import { IQuestion } from '../../DTO/IQuestion';

export const getAllData = () => {
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        const questions = await QuestionService.getAll();
        if (questions) {
            dispatch(fetchAll(questions));
        }
    };
};

export const deleteQuestion = (id: number) => {
    console.log("delete id "+id)
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        await QuestionService.deleteById(id)
        dispatch(getAllData());
    };
  };

export const editQuestion = (question: IQuestion) => {
    console.log("update question text: "+question.text)
  return async (dispatch: ApplicationDispatch<QuestionActions>) => {
    const result = await QuestionService.update(question);
    if (result) dispatch(getAllData());
  };
};

