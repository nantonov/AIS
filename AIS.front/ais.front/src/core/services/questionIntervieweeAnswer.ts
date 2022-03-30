import defaultQuestionIntervieweeAnswer from '../common/defaultDTO/defaultQuestionIntervieweeAnswer';
import { QuestionIntervieweeAnswer } from '../interfaces/questionIntervieweeAnswer/questionIntervieweeAnswer';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class QuestionIntervieweeAnswerServer {
  public static async getAll(): Promise<QuestionIntervieweeAnswer[]> {
    const result = await axiosInstance
      .get<QuestionIntervieweeAnswer[]>(Config.QUESTION_INTERVIEWEE_ANSWER_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(
    questionIntervieweeAnswerId: number
  ): Promise<QuestionIntervieweeAnswer> {
    const result = await axiosInstance
      .get<QuestionIntervieweeAnswer>(
        `${Config.QUESTION_INTERVIEWEE_ANSWER_URL}/${questionIntervieweeAnswerId}`
      )
      .then((res) => res.data);

    return result || defaultQuestionIntervieweeAnswer;
  }

  public static deleteById(questionIntervieweeAnswerId: number): Promise<any> {
    return axiosInstance.delete(
      `${Config.QUESTION_INTERVIEWEE_ANSWER_URL}/${questionIntervieweeAnswerId}`
    );
  }

  public static create(
    questionIntervieweeAnswer: QuestionIntervieweeAnswer
  ): Promise<any> {
    return axiosInstance.post(Config.QUESTION_INTERVIEWEE_ANSWER_URL, {
      ...questionIntervieweeAnswer,
    });
  }

  public static update(
    questionIntervieweeAnswer: QuestionIntervieweeAnswer
  ): Promise<boolean> {
    return axiosInstance.put(
      Config.QUESTION_INTERVIEWEE_ANSWER_URL,
      { ...questionIntervieweeAnswer },
      { params: { id: questionIntervieweeAnswer.id } }
    );
  }
}

export default QuestionIntervieweeAnswerServer;
