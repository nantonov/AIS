import { defaultTrueAnswer } from "../common/defaultDTO/defaultTrueAnswer";
import { ITrueAnswer } from "../DTO/ITrueAnswer";
import axiosInstance from "../utils/getAxious";


export class TrueAnswerService {
    static path:string = 'api/TrueAnswer';
    public static async getAll(): Promise<ITrueAnswer[]> {
        const result = await axiosInstance.get<ITrueAnswer[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(trueAnswerId: number): Promise<ITrueAnswer> {
        const result = await axiosInstance.get<ITrueAnswer>(
            this.path+`/${trueAnswerId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultTrueAnswer;
    }

    public static deleteById(trueAnswerId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${trueAnswerId}`);
    }

    public static create(trueAnswer: ITrueAnswer): Promise<any> {
        return axiosInstance.post(
            this.path, { ...trueAnswer });
    }

    public static update(trueAnswer: ITrueAnswer): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...trueAnswer }, { params: { id: trueAnswer.id } });
    }
}