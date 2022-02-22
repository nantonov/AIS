import { defaultQuestionArea } from "../common/defaultDTO/defaultQuestionArea";
import { IQuestionArea } from "../DTO/IQuestionArea";
import axiosInstance from "../utils/getAxious";


export class QuestionAreaService {
    static path:string = 'api/QuestionArea';
    public static async getAll(): Promise<IQuestionArea[]> {
        const result = await axiosInstance.get<IQuestionArea[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionAreaId: number): Promise<IQuestionArea> {
        const result = await axiosInstance.get<IQuestionArea>(
            this.path+`/${questionAreaId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionArea;
    }

    public static deleteById(questionAreaId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${questionAreaId}`);
    }

    public static create(questionArea: IQuestionArea): Promise<any> {
        return axiosInstance.post(
            this.path, { ...questionArea });
    }

    public static update(questionArea: IQuestionArea): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...questionArea }, { params: { id: questionArea.id } });
    }
}