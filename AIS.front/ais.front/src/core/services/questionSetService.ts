import {defaultQuestionSet} from "../common/defaultDTO/defaultQuestionSet";
import {QuestionSet, QuestionSetAddState} from "../interfaces/questionSet";
import axiosInstance from "../../config/getAxious";
import {QUESTION_SET_URL} from "../constants/urlConstants";

export class QuestionSetService {
    public static async getAll(): Promise<QuestionSet[]> {
        const result = await axiosInstance.get<QuestionSet[]>(QUESTION_SET_URL)
            .then((result) => result.data)
            .catch(({response}) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionSetId: number): Promise<QuestionSet> {
        const result = await axiosInstance.get<QuestionSet>(
            QUESTION_SET_URL + `/${questionSetId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionSet;
    }

    public static deleteById(questionSetId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_SET_URL + `/${questionSetId}`);
    }

    public static create(questionSet: QuestionSet): Promise<any> {
        return axiosInstance.post(
            QUESTION_SET_URL, {...questionSet});
    }

    public static update(questionSet: QuestionSet): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_SET_URL, {...questionSet}, {params: {id: questionSet.id}});
    }

    public static addQuestionSet(questionSetAdd: QuestionSetAddState): Promise<any>{
        return axiosInstance.post(
            QUESTION_SET_URL, {...questionSetAdd}, {params: {questionSetAdd}}
        )
    }
}
