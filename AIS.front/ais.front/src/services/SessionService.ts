import { defaultSession } from "../common/defaultDTO/defaultSession";
import { ISession } from "../DTO/ISession";
import axiosInstance from "../utils/getAxious";
import {SESSION_URL} from "../static/UrlConstants";
import {Config} from "../config";


export class SessionService {
    public static async getAll(): Promise<ISession[]> {
        const result = await axiosInstance.get<ISession[]>(Config.SESSION_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(sessionId: number): Promise<ISession> {
        const result = await axiosInstance.get<ISession>(
            Config.SESSION_URL+`/${sessionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultSession;
    }

    public static deleteById(sessionId: number): Promise<any> {
        return axiosInstance.delete(
            Config.SESSION_URL+`/${sessionId}`);
    }

    public static create(session: ISession): Promise<any> {
        return axiosInstance.post(
            Config.SESSION_URL, { ...session });
    }

    public static update(session: ISession): Promise<boolean> {
        return axiosInstance.put(
            Config.SESSION_URL, { ...session }, { params: { id: session.id } });
    }
}
