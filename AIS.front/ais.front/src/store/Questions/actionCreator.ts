import {ApplicationDispatch} from "../typing";
import {QuestionActions} from "./reducer";
import {fetchAll} from "./action";
import {QuestionService} from "../../services/QuestionService";

export const getAllData = () => {
    return async (dispatch: ApplicationDispatch<QuestionActions>) => {
        const questions = await QuestionService.getAll();
        if (questions) {
            dispatch(fetchAll(questions));
        }
    };
};
