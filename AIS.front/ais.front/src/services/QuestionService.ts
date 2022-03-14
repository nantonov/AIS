import { defaultQuestion } from "../common/defaultDTO/defaultQuestion";
import { IQuestion } from "../DTO/IQuestion";
import axiosInstance from "../utils/getAxious";
import {QUESTION_URL} from "../static/UrlConstants";
import {Config} from "../config";


export class QuestionService {
    public static async getAll(): Promise<IQuestion[]> {
        const result = await axiosInstance.get<IQuestion[]>(Config.QUESTION_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));
        return result || [];
    }

    public static async getById(questionId: number): Promise<IQuestion> {
        const result = await axiosInstance.get<IQuestion>(
            Config.QUESTION_URL+`/${questionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestion;
    }

    public static deleteById(questionId: number): Promise<any> {
        return axiosInstance.delete(
            Config.QUESTION_URL+`/${questionId}`);
    }

    public static create(question: IQuestion): Promise<any> {
        return axiosInstance.post(
            Config.QUESTION_URL, { ...question });
    }

    public static update(question: IQuestion): Promise<boolean> {
        return axiosInstance.put(
            Config.QUESTION_URL, { ...question }, { params: { id: question.id } });
    }
}
