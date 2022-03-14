import {ApplicationDispatch} from "../typing";
import {QuestionsActions} from "./reducer";
import {fetchAll} from "./action";
import {QuestionService} from "../../services/QuestionService";

export const getAllData = () => {
    return async (dispatch: ApplicationDispatch<QuestionsActions>) => {
        const questions = await QuestionService.getAll();
        if (questions) {
            dispatch(fetchAll(questions));
        }
    };
};

