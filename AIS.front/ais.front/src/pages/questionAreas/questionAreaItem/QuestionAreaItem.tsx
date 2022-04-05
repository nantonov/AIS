import React from 'react';
import { useNavigate } from 'react-router-dom';
import { QuestionArea } from '../../../core/interfaces/questionArea/questionArea';
import QuestionAreaContainer from '../../../core/components/itemContainer/ItemContainer';
import { QuestionAreaDescriptionDiv, QuestionAreaHeader, QuestionAreaNameText } from './style';
import MainRoutes from '../../../core/constants/mainRoutes';

interface Props {
  questionArea: QuestionArea;
}

const QuestionAreaItem: React.FC<Props> = ({ questionArea }) => {
  const navigate = useNavigate();
  const routeChange = (id: number) => () => {
    const path = `/${MainRoutes.questionArea}/${id}`;
    navigate(path);
  };
  return (
    <QuestionAreaContainer onClick={routeChange(questionArea.id)}>
      <QuestionAreaHeader>{questionArea.name}</QuestionAreaHeader>
      <QuestionAreaDescriptionDiv>
        <QuestionAreaNameText>{questionArea.name}</QuestionAreaNameText>
      </QuestionAreaDescriptionDiv>
    </QuestionAreaContainer>
  );
};

export default QuestionAreaItem;
