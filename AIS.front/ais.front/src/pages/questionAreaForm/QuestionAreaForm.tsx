import React, { useEffect, useState } from 'react';
import { Grid, Typography, Button, Box, FormControl, TextField } from '@mui/material';
import { useDispatch } from 'react-redux';
import { useParams } from 'react-router-dom';
import { QuestionAreaAdd } from '../../core/interfaces/questionArea/questionArea';
import {
  createQuestionArea,
  fetchQuestionAreaById,
} from '../../core/store/questionArea/actionCreators';
import { defaultQuestionAreaAdd } from '../../core/common/defaultDTO/defaultQuestionArea';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import QuestionSets from './questionSetsForQuestionAreaForm/questionSetsForQuestionAreaForm';

const QuestionAreaForm: React.FC = () => {
  const { id } = useParams();
  const dispatch = useDispatch();
  const [item, setItem] = useState<QuestionAreaAdd>(defaultQuestionAreaAdd);

  useEffect(() => {
    dispatch(fetchQuestionAreaById(Number(id)));
  }, [dispatch, id]);

  const change = (event: React.ChangeEvent<HTMLInputElement>) => {
    const copy = { ...item, name: event.target.value };
    setItem(copy);
  };

  const submit = () => {
    dispatch(createQuestionArea(item));
  };
  return (
    <GridContainer>
      <Grid item>
        <Box>
          <Typography>Question area name: </Typography>
          <FormControl>
            <TextField
              required
              id="outlined-required"
              label="Required"
              sx={{ width: 180 }}
              value={item.name}
              onChange={change}
            />
            <Button onClick={submit}> Send</Button>
            <QuestionSets questionArea={item} setItem={setItem} />
          </FormControl>
        </Box>
      </Grid>
    </GridContainer>
  );
};

export default QuestionAreaForm;
