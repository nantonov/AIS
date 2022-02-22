import { defaultQuestionIntervieweeAnswer } from "../common/defaultDTO/defaultIQuestionIntervieweeAnswer";
import { IQuestionIntervieweeAnswer } from "../DTO/IQuestionIntervieweeAnswer";
import axiosInstance from "../utils/getAxious";


export class QuestionIntervieweeAnswer {
    static path:string = 'api/QuestionIntervieweeAnswer';
    public static async getAll(): Promise<IQuestionIntervieweeAnswer []> {
        const result = await axiosInstance.get<IQuestionIntervieweeAnswer[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionIntervieweeAnswerId: number): Promise<IQuestionIntervieweeAnswer> {
        const result = await axiosInstance.get<IQuestionIntervieweeAnswer>(
            this.path+`/${questionIntervieweeAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionIntervieweeAnswer;
    }

    public static deleteById(questionIntervieweeAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${questionIntervieweeAnswerId}`);
    }

    public static create(questionIntervieweeAnswer: IQuestionIntervieweeAnswer): Promise<any> {
        return axiosInstance.post(
            this.path, { ...questionIntervieweeAnswer });
    }

    public static update(questionIntervieweeAnswer: IQuestionIntervieweeAnswer): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...questionIntervieweeAnswer }, { params: { id: questionIntervieweeAnswer.id } });
    }
}