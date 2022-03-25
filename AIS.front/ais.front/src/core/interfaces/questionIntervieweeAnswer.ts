import { Question } from "./question";
import { Session } from "./session";

export interface QuestionIntervieweeAnswer{
    id: number,
    text: string,
    mark: number,
    sessionId:number,
    session: Session | null
    questionId: number,
    question: Question | null
}
