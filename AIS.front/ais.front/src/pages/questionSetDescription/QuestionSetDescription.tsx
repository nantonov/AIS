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
import { useTranslation } from 'react-i18next';
import { deleteByTwoIdsAreaSet } from '../../core/services/questionAreasQuestionSetsService';
import { deleteByTwoIdsSetQuestion } from '../../core/services/questionsQuestionSetsService';
import { getQuestionSetById } from '../../core/redux/thunk/questionSetThunk';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import questionSetSelector from '../../core/redux/selectors/questionSetSelector';

const QuestionSetDescription: React.FC = () => {
  const { id } = useParams();
  const { questionSet } = useTypedSelector(questionSetSelector);
  const dispatch = useDispatch();

  const { t } = useTranslation();

  useEffect(() => {
    dispatch(getQuestionSetById(Number(id)));
  }, [dispatch, id]);

  const DeleteQuestion = (questionSetId: number, questionId: number) => () => {
    deleteByTwoIdsSetQuestion(questionSetId, questionId).then(() => {
      getQuestionSetById(Number(id));
    });
  };

  const DeleteQuestionArea = (questionAreaId: number, questionSetId: number) => () => {
    deleteByTwoIdsAreaSet(questionAreaId, questionSetId).then(() => {
      getQuestionSetById(Number(id));
    });
  };

  return (
    <GridContainer>
      <Grid item>
        <Typography variant="h4" component="h5">
          {t('questionSet:')} {questionSet?.name}
        </Typography>
      </Grid>
      <Grid item>
        <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">
          {t('questionAreas:')}
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>{t('questionArea')}</TableCell>
                <TableCell />
              </TableRow>
            </TableHead>
            <TableBody>
              {questionSet?.questionAreas?.map((questionArea) => (
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
          {t('questions')}
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>{t('number')}</TableCell>
                <TableCell>{t('name')}</TableCell>
                <TableCell />
              </TableRow>
            </TableHead>
            <TableBody>
              {questionSet?.questions.map((question) => (
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
