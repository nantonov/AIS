import React, { useEffect, useState } from 'react';
import { Typography, Button, Box } from '@mui/material';
import { useDispatch } from 'react-redux';
import { useParams } from 'react-router-dom';
import { QuestionArea } from '../../core/interfaces/questionArea/questionArea';
import defaultQuestionArea from '../../core/common/defaultDTO/defaultQuestionArea';
import {
  createQuestionArea,
  editQuestionArea,
  fetchQuestionAreaById,
} from '../../core/store/questionArea/actionCreators';

const QuestionAreasForm: React.FC = () => {
  const { id } = useParams();
  const dispatch = useDispatch();
  const [item, setItem] = useState<QuestionArea>(defaultQuestionArea);

  useEffect(() => {
    dispatch(fetchQuestionAreaById(Number(id)));
  }, [dispatch, id]);

  const change = (e: React.ChangeEvent<HTMLInputElement>) => {
    setItem((oldItem) => ({ ...oldItem, name: e.target.value }));
  };

  const submit = () => {
    if (id) {
      dispatch(editQuestionArea(item));
    } else {
      dispatch(createQuestionArea(item));
    }
  };

  return (
    <Box>
      <Typography>{item.name}</Typography>
      <input value={item.name} onChange={change} />
      <Button onClick={submit}> Send</Button>
    </Box>
  );
};

export default QuestionAreasForm;
