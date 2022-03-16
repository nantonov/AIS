import { defaultQuestionArea } from "../common/defaultDTO/defaultQuestionArea";
import { IQuestionArea } from "../DTO/IQuestionArea";
import axiosInstance from "../utils/getAxious";
import {QUESTION_AREA_URL} from "../static/UrlConstants";


export class QuestionAreaService {
    public static async getAll(): Promise<IQuestionArea[]> {
        const result = await axiosInstance.get<IQuestionArea[]>(QUESTION_AREA_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionAreaId: number): Promise<IQuestionArea> {
        const result = await axiosInstance.get<IQuestionArea>(
            QUESTION_AREA_URL+`/${questionAreaId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionArea;
    }

    public static deleteById(questionAreaId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_AREA_URL+`/${questionAreaId}`);
    }

    public static create(questionArea: IQuestionArea): Promise<any> {
        return axiosInstance.post(
            QUESTION_AREA_URL, { ...questionArea });
    }

    public static update(questionArea: IQuestionArea): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_AREA_URL, { ...questionArea }, { params: { id: questionArea.id } });
    }
}
