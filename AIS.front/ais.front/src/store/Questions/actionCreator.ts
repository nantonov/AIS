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
    console.log("emit")
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        await QuestionService.deleteById(id)
        dispatch(getAllData());
    };
  };

