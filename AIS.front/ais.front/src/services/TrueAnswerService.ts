import { defaultTrueAnswer } from "../common/defaultDTO/defaultTrueAnswer";
import { ITrueAnswer } from "../DTO/ITrueAnswer";
import axiosInstance from "../utils/getAxious";
import {TRUE_ANSWER_URL} from "../static/UrlConstants";


export class TrueAnswerService {
    public static async getAll(): Promise<ITrueAnswer[]> {
        const result = await axiosInstance.get<ITrueAnswer[]>(TRUE_ANSWER_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(trueAnswerId: number): Promise<ITrueAnswer> {
        const result = await axiosInstance.get<ITrueAnswer>(
            TRUE_ANSWER_URL+`/${trueAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultTrueAnswer;
    }

    public static deleteById(trueAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            TRUE_ANSWER_URL+`/${trueAnswerId}`);
    }

    public static create(trueAnswer: ITrueAnswer): Promise<any> {
        return axiosInstance.post(
            TRUE_ANSWER_URL, { ...trueAnswer });
    }

    public static update(trueAnswer: ITrueAnswer): Promise<boolean> {
        return axiosInstance.put(
            TRUE_ANSWER_URL, { ...trueAnswer }, { params: { id: trueAnswer.id } });
    }
}
