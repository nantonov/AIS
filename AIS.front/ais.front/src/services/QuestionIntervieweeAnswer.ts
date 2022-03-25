import { defaultQuestionIntervieweeAnswer } from "../common/defaultDTO/defaultIQuestionIntervieweeAnswer";
import { IQuestionIntervieweeAnswer } from "../DTO/IQuestionIntervieweeAnswer";
import axiosInstance from "../utils/getAxious";
import {QUESTION_INTERVIEWEE_ANSWER_URL} from "../static/UrlConstants";


export class QuestionIntervieweeAnswer {
    public static async getAll(): Promise<IQuestionIntervieweeAnswer []> {
        const result = await axiosInstance.get<IQuestionIntervieweeAnswer[]>(QUESTION_INTERVIEWEE_ANSWER_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionIntervieweeAnswerId: number): Promise<IQuestionIntervieweeAnswer> {
        const result = await axiosInstance.get<IQuestionIntervieweeAnswer>(
            QUESTION_INTERVIEWEE_ANSWER_URL+`/${questionIntervieweeAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionIntervieweeAnswer;
    }

    public static deleteById(questionIntervieweeAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_INTERVIEWEE_ANSWER_URL+`/${questionIntervieweeAnswerId}`);
    }

    public static create(questionIntervieweeAnswer: IQuestionIntervieweeAnswer): Promise<any> {
        return axiosInstance.post(
            QUESTION_INTERVIEWEE_ANSWER_URL, { ...questionIntervieweeAnswer });
    }

    public static update(questionIntervieweeAnswer: IQuestionIntervieweeAnswer): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_INTERVIEWEE_ANSWER_URL, { ...questionIntervieweeAnswer }, { params: { id: questionIntervieweeAnswer.id } });
    }
}