import React, { useEffect } from 'react';
import { Grid } from '@mui/material';
import { useDispatch } from 'react-redux';
import QuestionAreaTableHeader from './components/questionAreaTableHeader/QuestionAreaTableHeader';
import QuestionAreaTableRow from './components/questionAreaTableRow/QuestionAreaTableRow';
import { fetchAllQuestionAreas } from '../../core/store/questionArea/actionCreators';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';

const QuestionArea: React.FC = () => {
  const dispatch = useDispatch();
  const questionAreaState = useTypedSelector((state) => state.questionAreas.questionAreas);

  useEffect(() => {
    dispatch(fetchAllQuestionAreas());
  }, [dispatch]);

  return (
    <Grid container justifyContent="space=between" alignItems="center">
      <QuestionAreaTableHeader />
      {questionAreaState.map((item) => (
        <QuestionAreaTableRow key={item.id} qArea={item} />
      ))}
    </Grid>
  );
};

export default QuestionArea;
