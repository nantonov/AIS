import defaultSession from '../common/defaultDTO/defaultSession';
import { Session } from '../interfaces/session/session';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class SessionService {
  public static async getAll(): Promise<Session[]> {
    const result = await axiosInstance
      .get<Session[]>(Config.SESSION_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(sessionId: number): Promise<Session> {
    const result = await axiosInstance
      .get<Session>(`${Config.SESSION_URL}/${sessionId}`)
      .then((res) => res.data);
    return result || defaultSession;
  }

  public static deleteById(sessionId: number): Promise<any> {
    return axiosInstance.delete(`${Config.SESSION_URL}/${sessionId}`);
  }

  public static create(session: Session): Promise<any> {
    return axiosInstance.post(Config.SESSION_URL, { ...session });
  }

  public static update(session: Session): Promise<boolean> {
    return axiosInstance.put(
      Config.SESSION_URL,
      { ...session },
      { params: { id: session.id } }
    );
  }
}

export default SessionService;
