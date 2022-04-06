import { InitQuestionAreaState } from '../reducer/questionAreaReducer';
import { RootState } from '../reducer/rootReducer';

const questionAreaSelector = (state: RootState): InitQuestionAreaState => state.questionArea;

export default questionAreaSelector;
