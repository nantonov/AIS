import defaultQuestion from '../common/defaultDTO/defaultQuestion';
import { Question } from '../interfaces/question/question';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getQuestionsAllService = async (): Promise<Question[]> => {
  const result = await axiosInstance.get<Question[]>(Config.QUESTION_URL).then((res) => res.data);

  return result || [];
};

export const getQuestionByIdService = async (questionId: number): Promise<Question> => {
  const result = await axiosInstance
    .get<Question>(`${Config.QUESTION_URL}/${questionId}`)
    .then((res) => res.data);

  return result || defaultQuestion;
};

export const deleteQuestionService = (questionId: number): Promise<any> =>
  axiosInstance.delete(`${Config.QUESTION_URL}/${questionId}`);

export const createQuestionService = (question: Question): Promise<any> =>
  axiosInstance.post(Config.QUESTION_URL, { ...question });

export const updateQuestionService = (question: Question): Promise<boolean> =>
  axiosInstance.put(Config.QUESTION_URL, { ...question }, { params: { id: question.id } });
