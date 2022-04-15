import defaultQuestionArea from '../common/defaultDTO/defaultQuestionArea';
import { QuestionArea, QuestionAreaAdd } from '../interfaces/questionArea/questionArea';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getAllQuestionAreasService = async (accessToken: string): Promise<QuestionArea[]> => {
  const result = await axiosInstance
    .get<QuestionArea[]>(Config.QUESTION_AREA_URL, {
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    })
    .then((res) => res.data);

  return result || [];
};

export const getQuestionAreaByIdService = async (
  questionAreaId: number,
  accessToken: string
): Promise<QuestionArea> => {
  const result = await axiosInstance
    .get<QuestionArea>(`${Config.QUESTION_AREA_URL}/${questionAreaId}`, {
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    })
    .then((res) => res.data);

  return result || defaultQuestionArea;
};

export const deleteQuestionAreaService = (
  questionAreaId: number,
  accessToken: string
): Promise<any> =>
  axiosInstance.delete(`${Config.QUESTION_AREA_URL}/${questionAreaId}`, {
    headers: {
      Authorization: `Bearer ${accessToken}`,
    },
  });

export const createQuestionAreaService = (
  questionArea: QuestionAreaAdd,
  accessToken: string
): Promise<any> =>
  axiosInstance.post(
    Config.QUESTION_AREA_URL,
    { ...questionArea },
    {
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    }
  );

export const updateQuestionAreaService = (
  questionArea: QuestionArea,
  accessToken: string
): Promise<boolean> =>
  axiosInstance.put(
    Config.QUESTION_AREA_URL,
    { ...questionArea },
    {
      params: { id: questionArea.id },
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    }
  );
