import defaultQuestionArea from '../common/defaultDTO/defaultQuestionArea';
import { QuestionArea, QuestionAreaAdd } from '../interfaces/questionArea/questionArea';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getAllQuestionAreasService = async (): Promise<QuestionArea[]> => {
  const result = await axiosInstance
    .get<QuestionArea[]>(Config.QUESTION_AREA_URL)
    .then((res) => res.data);

  return result || [];
};

export const getQuestionAreaByIdService = async (questionAreaId: number): Promise<QuestionArea> => {
  const result = await axiosInstance
    .get<QuestionArea>(`${Config.QUESTION_AREA_URL}/${questionAreaId}`)
    .then((res) => res.data);

  return result || defaultQuestionArea;
};

export const deleteQuestionAreaService = (questionAreaId: number): Promise<any> =>
  axiosInstance.delete(`${Config.QUESTION_AREA_URL}/${questionAreaId}`);

export const createQuestionAreaService = (questionArea: QuestionAreaAdd): Promise<any> =>
  axiosInstance.post(Config.QUESTION_AREA_URL, { ...questionArea });

export const updateQuestionAreaService = (questionArea: QuestionArea): Promise<boolean> =>
  axiosInstance.put(
    Config.QUESTION_AREA_URL,
    { ...questionArea },
    {
      params: { id: questionArea.id },
    }
  );
