import { defaultTrueAnswer } from "../common/defaultDTO/defaultTrueAnswer";
import { Config } from "../config";
import { ITrueAnswer } from "../DTO/ITrueAnswer";
import axiosInstance from "../utils/getAxious";


export class TrueAnswerService {
    public static async getAll(): Promise<ITrueAnswer[]> {
        const result = await axiosInstance.get<ITrueAnswer[]>(Config.TRUE_ANSWER_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(trueAnswerId: number): Promise<ITrueAnswer> {
        const result = await axiosInstance.get<ITrueAnswer>(
            Config.TRUE_ANSWER_URL+`/${trueAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultTrueAnswer;
    }

    public static deleteById(trueAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            Config.TRUE_ANSWER_URL+`/${trueAnswerId}`);
    }

    public static create(trueAnswer: ITrueAnswer): Promise<any> {
        return axiosInstance.post(
            Config.TRUE_ANSWER_URL, { ...trueAnswer });
    }

    public static update(trueAnswer: ITrueAnswer): Promise<boolean> {
        return axiosInstance.put(
            Config.TRUE_ANSWER_URL, { ...trueAnswer }, { params: { id: trueAnswer.id } });
    }
}