import defaultQuestionIntervieweeAnswer from '../common/defaultDTO/defaultQuestionIntervieweeAnswer';
import { QuestionIntervieweeAnswer } from '../interfaces/questionIntervieweeAnswer/questionIntervieweeAnswer';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getQuestionIntervieweeAnswersAllService = async (): Promise<
  QuestionIntervieweeAnswer[]
> => {
  const result = await axiosInstance
    .get<QuestionIntervieweeAnswer[]>(Config.QUESTION_INTERVIEWEE_ANSWER_URL)
    .then((res) => res.data);

  return result || [];
};

export const getQuestionIntervieweeAnswerByIdService = async (
  questionIntervieweeAnswerId: number
): Promise<QuestionIntervieweeAnswer> => {
  const result = await axiosInstance
    .get<QuestionIntervieweeAnswer>(
      `${Config.QUESTION_INTERVIEWEE_ANSWER_URL}/${questionIntervieweeAnswerId}`
    )
    .then((res) => res.data);

  return result || defaultQuestionIntervieweeAnswer;
};

export const deleteQuestionIntervieweeAnswerService = (
  questionIntervieweeAnswerId: number
): Promise<any> =>
  axiosInstance.delete(`${Config.QUESTION_INTERVIEWEE_ANSWER_URL}/${questionIntervieweeAnswerId}`);

export const createQuestionIntervieweeAnswerService = (
  questionIntervieweeAnswer: QuestionIntervieweeAnswer
): Promise<any> =>
  axiosInstance.post(Config.QUESTION_INTERVIEWEE_ANSWER_URL, {
    ...questionIntervieweeAnswer,
  });

export const updateQuestionIntervieweeAnswerService = (
  questionIntervieweeAnswer: QuestionIntervieweeAnswer
): Promise<boolean> =>
  axiosInstance.put(
    Config.QUESTION_INTERVIEWEE_ANSWER_URL,
    { ...questionIntervieweeAnswer },
    { params: { id: questionIntervieweeAnswer.id } }
  );
