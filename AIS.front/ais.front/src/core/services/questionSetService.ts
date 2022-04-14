import { defaultQuestionSet } from '../common/defaultDTO/defaultQuestionSet';
import { QuestionSet, QuestionSetAddState } from '../interfaces/questionSet/questionSet';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getQuestionSetsAllService = async (): Promise<QuestionSet[]> => {
  const result = await axiosInstance
    .get<QuestionSet[]>(Config.QUESTION_SET_URL)
    .then((res) => res.data);

  return result || [];
};

export const getQuestionByIdService = async (questionSetId: number): Promise<QuestionSet> => {
  const result = await axiosInstance
    .get<QuestionSet>(`${Config.QUESTION_SET_URL}/${questionSetId}`)
    .then((res) => res.data);

  return result || defaultQuestionSet;
};

export const deleteQuestionService = (questionSetId: number): Promise<any> =>
  axiosInstance.delete(`${Config.QUESTION_SET_URL}/${questionSetId}`);

export const createQuestionService = (questionSet: QuestionSet): Promise<any> =>
  axiosInstance.post(Config.QUESTION_SET_URL, { ...questionSet });

export const updateQuestionService = (questionSet: QuestionSet): Promise<boolean> =>
  axiosInstance.put(
    Config.QUESTION_SET_URL,
    { ...questionSet },
    { params: { id: questionSet.id } }
  );

export const addQuestionSetService = (questionSetAdd: QuestionSetAddState): Promise<any> =>
  axiosInstance.post(
    Config.QUESTION_SET_URL,
    { ...questionSetAdd },
    { params: { questionSetAdd } }
  );
