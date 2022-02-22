import { IQuestion } from "./IQuestion";
import { ISession } from "./ISession";
import { ITrueAnswer } from "./ITrueAnswer";

export interface IQuestionIntervieweeAnswer{
    id: number,
    text: string,
    mark: number,
    sessionId:number,
    session: ISession | null
    questionId: number,
    question: IQuestion | null
}