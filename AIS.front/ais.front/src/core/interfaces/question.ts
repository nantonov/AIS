import { QuestionSet } from "./questionSet";
import { TrueAnswer } from "./trueAnswer";

export interface Question{
    id: number,
    text: string,
    questionSetid: number,
    questionSet: QuestionSet | null,
    trueAnswer: TrueAnswer | null
}
