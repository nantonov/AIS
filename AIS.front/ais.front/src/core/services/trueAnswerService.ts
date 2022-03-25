import { defaultTrueAnswer } from "../common/defaultDTO/defaultTrueAnswer";
import { TrueAnswer } from "../interfaces/trueAnswer";
import axiosInstance from "../../config/getAxious";
import {TRUE_ANSWER_URL} from "../constants/urlConstants";


export class TrueAnswerService {
    public static async getAll(): Promise<TrueAnswer[]> {
        const result = await axiosInstance.get<TrueAnswer[]>(TRUE_ANSWER_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(trueAnswerId: number): Promise<TrueAnswer> {
        const result = await axiosInstance.get<TrueAnswer>(
            TRUE_ANSWER_URL+`/${trueAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultTrueAnswer;
    }

    public static deleteById(trueAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            TRUE_ANSWER_URL+`/${trueAnswerId}`);
    }

    public static create(trueAnswer: TrueAnswer): Promise<any> {
        return axiosInstance.post(
            TRUE_ANSWER_URL, { ...trueAnswer });
    }

    public static update(trueAnswer: TrueAnswer): Promise<boolean> {
        return axiosInstance.put(
            TRUE_ANSWER_URL, { ...trueAnswer }, { params: { id: trueAnswer.id } });
    }
}
