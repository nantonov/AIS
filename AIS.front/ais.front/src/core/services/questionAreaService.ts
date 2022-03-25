import { defaultQuestionArea } from "../common/defaultDTO/defaultQuestionArea";
import { QuestionArea } from "../interfaces/questionArea";
import axiosInstance from "../../config/getAxious";
import {QUESTION_AREA_URL} from "../constants/urlConstants";


export class QuestionAreaService {
    public static async getAll(): Promise<QuestionArea[]> {
        const result = await axiosInstance.get<QuestionArea[]>(QUESTION_AREA_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(questionAreaId: number): Promise<QuestionArea> {
        const result = await axiosInstance.get<QuestionArea>(
            QUESTION_AREA_URL+`/${questionAreaId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultQuestionArea;
    }

    public static deleteById(questionAreaId: number): Promise<any> {
        return axiosInstance.delete(
            QUESTION_AREA_URL+`/${questionAreaId}`);
    }

    public static create(questionArea: QuestionArea): Promise<any> {
        return axiosInstance.post(
            QUESTION_AREA_URL, { ...questionArea });
    }

    public static update(questionArea: QuestionArea): Promise<boolean> {
        return axiosInstance.put(
            QUESTION_AREA_URL, { ...questionArea }, { params: { id: questionArea.id } });
    }
}
