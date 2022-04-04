import React, { useEffect, useState } from 'react';
import TableBody from '@material-ui/core/TableBody';
import {
  Button,
  Grid,
  MenuItem,
  Paper,
  Table,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography,
} from '@mui/material';
import { useDispatch } from 'react-redux';
import DeleteIcon from '@mui/icons-material/Delete';
import { useTypedSelector } from '../../../core/hooks/useTypedSelector';
import { QuestionAreaAdd } from '../../../core/interfaces/questionArea/questionArea';
import { getAllData } from '../../../core/store/questionSets/actionCreator';

interface QuestionAreaProps {
  questionArea: QuestionAreaAdd;
  setItem: (item: QuestionAreaAdd) => void;
}
const QuestionSets: React.FC<QuestionAreaProps> = ({ questionArea, setItem }) => {
  const dispatch = useDispatch();
  const questionSets = useTypedSelector((state) => state.questionSets.questionSets);
  const [QuestionSetsIds, setQuestionSetsIds] = useState<number[]>(questionArea.questionSetsIds);

  const deleteQuestionSet = (questionSetId: number) => () => {
    const array = QuestionSetsIds.filter((set) => set !== questionSetId);
    setQuestionSetsIds(array);
    setItem({ ...questionArea, questionSetsIds: QuestionSetsIds });
  };
  const getQuestionSetsOptions = () =>
    questionSets.filter((item) => !QuestionSetsIds.find((set) => item.id === set));

  const changeQuestionSetsHandler = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const array = [...QuestionSetsIds, Number(event.target.value)];
    setQuestionSetsIds(array);
    setItem({ ...questionArea, questionSetsIds: QuestionSetsIds });
  };
  useEffect(() => {
    dispatch(getAllData());
  }, [dispatch]);

  return (
    <Grid item>
      <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">
        Question sets:{' '}
      </Typography>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Question sets</TableCell>
              <TableCell />
            </TableRow>
          </TableHead>
          <TableBody>
            {QuestionSetsIds.map((questionSet) => (
              <TableRow
                key={questionSet}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {questionSets.find((item) => item.id === questionSet)?.name}
                </TableCell>
                <TableCell align="right">
                  <Button endIcon={<DeleteIcon />} onClick={deleteQuestionSet(questionSet)} />
                </TableCell>
              </TableRow>
            ))}
            {!!getQuestionSetsOptions().length && (
              <TableRow>
                <TableCell>
                  <TextField
                    id="outlined-select-question-area"
                    select
                    value={0}
                    onChange={changeQuestionSetsHandler}
                  >
                    <MenuItem value={0}>Choose question set</MenuItem>
                    {getQuestionSetsOptions().map((set) => (
                      <MenuItem key={set.id} value={set.id}>
                        {set.name}
                      </MenuItem>
                    ))}
                  </TextField>
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  );
};

export default QuestionSets;
