import { defaultSession } from "../common/defaultDTO/defaultSession";
import { Session } from "../interfaces/session";
import axiosInstance from "../../config/getAxious";
import {SESSION_URL} from "../../core/constants/UrlConstants";


export class SessionService {
    public static async getAll(): Promise<Session[]> {
        const result = await axiosInstance.get<Session[]>(SESSION_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(sessionId: number): Promise<Session> {
        const result = await axiosInstance.get<Session>(
            SESSION_URL+`/${sessionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultSession;
    }

    public static deleteById(sessionId: number): Promise<any> {
        return axiosInstance.delete(
            SESSION_URL+`/${sessionId}`);
    }

    public static create(session: Session): Promise<any> {
        return axiosInstance.post(
            SESSION_URL, { ...session });
    }

    public static update(session: Session): Promise<boolean> {
        return axiosInstance.put(
            SESSION_URL, { ...session }, { params: { id: session.id } });
    }
}
