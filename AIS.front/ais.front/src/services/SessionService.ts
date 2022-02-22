import { defaultSession } from "../common/defaultDTO/defaultSession";
import { ISession } from "../DTO/ISession";
import axiosInstance from "../utils/getAxious";


export class SessionService {
    static path:string = 'api/Session';
    public static async getAll(): Promise<ISession[]> {
        const result = await axiosInstance.get<ISession[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(sessionId: number): Promise<ISession> {
        const result = await axiosInstance.get<ISession>(
            this.path+`/${sessionId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultSession;
    }

    public static deleteById(sessionId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${sessionId}`);
    }

    public static create(session: ISession): Promise<any> {
        return axiosInstance.post(
            this.path, { ...session });
    }

    public static update(session: ISession): Promise<boolean> {
        return axiosInstance.put(
            this.path , { ...session }, { params: { id: session.id } });
    }
}