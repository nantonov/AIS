import { Question } from "./question";

export interface TrueAnswer{
    id: number,
    text: string,
    questionId: number,
    question: Question | null
}
