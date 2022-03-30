import React, { useEffect, useState } from 'react';
import { Grid } from '@mui/material';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import MainRoutes from '../../core/constants/mainRoutes';
import QuestionAreaTableHeader from './components/questionAreaTableHeader/QuestionAreaTableHeader';
import QuestionAreaTableRow from './components/questionAreaTableRow/QuestionAreaTableRow';
import {
  fetchAllQuestionAreas,
  fetchQuestionAreaById,
} from '../../core/store/questionArea/actionCreators';
import { QuestionArea as questionArea } from '../../core/interfaces/questionArea/questionArea';

const QuestionArea: React.FC = () => {
  const dispatch = useDispatch();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [questionAreaState, setQuestionArea] = useState<questionArea[]>([]);

  useEffect(() => {
    dispatch(fetchAllQuestionAreas());
  }, []);

  const navigate = useNavigate();
  const edit = (id: number) => {
    fetchQuestionAreaById(id);
    navigate(`/${MainRoutes.questionAreaForm}/${id}`);
  };

  return (
    <Grid container justifyContent="space=between" alignItems="center">
      <QuestionAreaTableHeader />
      {questionAreaState.map((item) => (
        <QuestionAreaTableRow key={item.id} qArea={item} onEdit={edit} />
      ))}
    </Grid>
  );
};

export default QuestionArea;
