import { defaultQuestionIntervieweeAnswer } from "../../core/common/defaultDTO/defaultQuestionIntervieweeAnswer";
import { QuestionIntervieweeAnswer } from "../interfaces/questionIntervieweeAnswer";
import axiosInstance from "../../config/getAxious";
import {QUESTION_INTERVIEWEE_ANSWER_URL} from "../constants/urlConstants";


export class QuestionIntervieweeAnswerServer {
    public static async getAll(): Promise<QuestionIntervieweeAnswer []> {
        const result = await axiosInstance.get<QuestionIntervieweeAnswer[]>(QUESTION_INTERVIEWEE_ANSWER_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionIntervieweeAnswerId: number): Promise<QuestionIntervieweeAnswer> {
        const result = await axiosInstance.get<QuestionIntervieweeAnswer>(
            QUESTION_INTERVIEWEE_ANSWER_URL+`/${questionIntervieweeAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionIntervieweeAnswer;
    }

    public static deleteById(questionIntervieweeAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_INTERVIEWEE_ANSWER_URL+`/${questionIntervieweeAnswerId}`);
    }

    public static create(questionIntervieweeAnswer: QuestionIntervieweeAnswer): Promise<any> {
        return axiosInstance.post(
            QUESTION_INTERVIEWEE_ANSWER_URL, { ...questionIntervieweeAnswer });
    }

    public static update(questionIntervieweeAnswer: QuestionIntervieweeAnswer): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_INTERVIEWEE_ANSWER_URL, { ...questionIntervieweeAnswer }, { params: { id: questionIntervieweeAnswer.id } });
    }
}
