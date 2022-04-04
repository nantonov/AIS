import React, { useEffect } from 'react';
import {
  Button,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from '@mui/material';
import { useDispatch } from 'react-redux';
import { useParams } from 'react-router-dom';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import Typography from '@mui/material/Typography';
import QuestionAreasQuestionSetsService from '../../core/services/questionAreasQuestionSetsService';
import QuestionsQuestionSetsService from '../../core/services/questionsQuestionSetsService';
import { getById } from '../../core/store/questionSets/actionCreator';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import GridContainer from '../../core/components/gridContainer/GridContainer';

const QuestionSetDescription: React.FC = () => {
  const { id } = useParams();
  const questionSet = useTypedSelector((state) => state.questionSets.questionSet);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getById(Number(id)));
  }, [dispatch, id]);

  const DeleteQuestion = (questionSetId: number, questionId: number) => () => {
    QuestionsQuestionSetsService.deleteByTwoIds(questionSetId, questionId).then(() => {
      getById(Number(id));
    });
  };

  const DeleteQuestionArea = (questionAreaId: number, questionSetId: number) => () => {
    QuestionAreasQuestionSetsService.deleteByTwoIds(questionAreaId, questionSetId).then(() => {
      getById(Number(id));
    });
  };

  return (
    <GridContainer>
      <Grid item>
        <Typography variant="h4" component="h5">
          Question set: {questionSet.name}
        </Typography>
      </Grid>
      <Grid item>
        <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">
          Question areas:
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Question area</TableCell>
                <TableCell />
              </TableRow>
            </TableHead>
            <TableBody>
              {questionSet.questionAreas?.map((questionArea) => (
                <TableRow
                  key={questionArea.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {questionArea.name}
                  </TableCell>
                  <TableCell align="right">
                    <Button endIcon={<EditIcon />} />
                    <Button
                      endIcon={<DeleteIcon />}
                      onClick={DeleteQuestionArea(questionArea.id, questionSet.id)}
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>

      <Grid item>
        <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">
          Questions
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Number</TableCell>
                <TableCell>Name</TableCell>
                <TableCell />
              </TableRow>
            </TableHead>
            <TableBody>
              {questionSet.questions.map((question) => (
                <TableRow
                  key={question.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell>{question.id}</TableCell>
                  <TableCell component="th" scope="row">
                    {question.text}
                  </TableCell>
                  <TableCell align="right">
                    <Button endIcon={<EditIcon />} />
                    <Button
                      endIcon={<DeleteIcon />}
                      onClick={DeleteQuestion(Number(id), question.id)}
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </GridContainer>
  );
};

export default QuestionSetDescription;
