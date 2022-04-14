import defaultSession from '../common/defaultDTO/defaultSession';
import { Session } from '../interfaces/session/session';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getSesionsAllService = async (): Promise<Session[]> => {
  const result = await axiosInstance.get<Session[]>(Config.SESSION_URL).then((res) => res.data);

  return result || [];
};

export const getSessionByIdService = async (sessionId: number): Promise<Session> => {
  const result = await axiosInstance
    .get<Session>(`${Config.SESSION_URL}/${sessionId}`)
    .then((res) => res.data);
  return result || defaultSession;
};

export const deleteSessionService = (sessionId: number): Promise<any> =>
  axiosInstance.delete(`${Config.SESSION_URL}/${sessionId}`);

export const createSessionService = (session: Session): Promise<any> =>
  axiosInstance.post(Config.SESSION_URL, { ...session });

export const updateSessionService = (session: Session): Promise<boolean> =>
  axiosInstance.put(Config.SESSION_URL, { ...session }, { params: { id: session.id } });
