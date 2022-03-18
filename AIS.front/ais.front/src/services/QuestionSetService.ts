import {defaultQuestionSet} from "../common/defaultDTO/defaultQuestionSet";
import {IQuestionSet, IQuestionSetAdd} from "../DTO/IQuestionSet";
import axiosInstance from "../utils/getAxious";
import {QUESTION_SET_URL} from "../static/UrlConstants";
import {Config} from "../config";

export class QuestionSetService {
    public static async getAll(): Promise<IQuestionSet[]> {
        const result = await axiosInstance.get<IQuestionSet[]>(QUESTION_SET_URL)
            .then((result) => result.data)
            .catch(({response}) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionSetId: number): Promise<IQuestionSet> {
        const result = await axiosInstance.get<IQuestionSet>(
            QUESTION_SET_URL + `/${questionSetId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionSet;
    }

    public static deleteById(questionSetId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_SET_URL + `/${questionSetId}`);
    }

    public static create(questionSet: IQuestionSet): Promise<any> {
        return axiosInstance.post(
            QUESTION_SET_URL, {...questionSet});
    }

    public static update(questionSet: IQuestionSet): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_SET_URL, {...questionSet}, {params: {id: questionSet.id}});
    }

    public static addQuestionSet(questionSetAdd: IQuestionSetAdd): Promise<any>{
        return axiosInstance.post(
            Config.QUESTION_SET_URL, {}, {params: {questionSetAdd}}
        )
    }
}
