import { QuestionSet } from "./questionSet";

export interface QuestionArea{
    id: number,
    name: string,
    questionSets: QuestionSet[]
}
