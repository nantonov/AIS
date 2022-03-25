import { defaultQuestion } from "../common/defaultDTO/defaultQuestion";
import { Question } from "../interfaces/question";
import axiosInstance from "../../config/getAxious";
import {QUESTION_URL} from "../constants/urlConstants";


export class QuestionService {
    public static async getAll(): Promise<Question[]> {
        const result = await axiosInstance.get<Question[]>(QUESTION_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));
        return result || [];
    }

    public static async getById(questionId: number): Promise<Question> {
        const result = await axiosInstance.get<Question>(
            QUESTION_URL+`/${questionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestion;
    }

    public static deleteById(questionId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_URL+`/${questionId}`);
    }

    public static create(question: Question): Promise<any> {
        return axiosInstance.post(
            QUESTION_URL, { ...question });
    }

    public static update(question: Question): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_URL, { ...question }, { params: { id: question.id } });
    }
}
