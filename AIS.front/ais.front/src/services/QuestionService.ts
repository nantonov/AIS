import { defaultQuestion } from "../common/defaultDTO/defaultQuestion";
import { IQuestion } from "../DTO/IQuestion";
import axiosInstance from "../utils/getAxious";


export class QuestionService {
    static path:string = 'api/Question';
    public static async getAll(): Promise<IQuestion[]> {
        const result = await axiosInstance.get<IQuestion[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionId: number): Promise<IQuestion> {
        const result = await axiosInstance.get<IQuestion>(
            this.path+`/${questionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestion;
    }

    public static deleteById(questionId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${questionId}`);
    }

    public static create(question: IQuestion): Promise<any> {
        return axiosInstance.post(
            this.path, { ...question });
    }

    public static update(question: IQuestion): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...question }, { params: { id: question.id } });
    }
}