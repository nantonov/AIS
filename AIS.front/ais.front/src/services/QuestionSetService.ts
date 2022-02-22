import { defaultQuestionSet } from "../common/defaultDTO/defaultQuestionSet";
import { IQuestionSet } from "../DTO/IQuestionSet";
import axiosInstance from "../utils/getAxious";


export class QuestionSetService {
    static path:string = 'api/QuestionSet';
    public static async getAll(): Promise<IQuestionSet[]> {
        const result = await axiosInstance.get<IQuestionSet[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionSetId: number): Promise<IQuestionSet> {
        const result = await axiosInstance.get<IQuestionSet>(
            this.path+`/${questionSetId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionSet;
    }

    public static deleteById(questionSetId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${questionSetId}`);
    }

    public static create(questionSet: IQuestionSet): Promise<any> {
        return axiosInstance.post(
            this.path, { ...questionSet });
    }

    public static update(questionSet: IQuestionSet): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...questionSet }, { params: { id: questionSet.id } });
    }
}