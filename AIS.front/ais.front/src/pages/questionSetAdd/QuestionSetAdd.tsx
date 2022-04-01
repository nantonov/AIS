import { Box, Button, FormControl, Grid, MenuItem, TextField } from '@mui/material';
import Typography from '@mui/material/Typography';
import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { QuestionSetAddState } from '../../core/interfaces/questionSet/questionSet';
import { IQuestionSetAddDefault } from '../../core/common/defaultDTO/defaultQuestionSet';
import QuestionSetService from '../../core/services/questionSetService';
import { getAllData } from '../../core/store/questionSets/actionCreator';
import { getAllData as getQuestions } from '../../core/store/questions/actionCreator';
import { fetchAllQuestionAreas } from '../../core/store/questionArea/actionCreators';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import { QuestionArea } from '../../core/interfaces/questionArea/questionArea';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import BoxContainer from '../../core/components/boxContainer/BoxContainer';
import ButtonContainer from '../../core/components/buttonContainer/ButtonContainer';
import MainRoutes from '../../core/constants/mainRoutes'

const QuestionSetAdd: React.FC = () => {
  const [questionSetModel, setQuestionSetModel] =
    useState<QuestionSetAddState>(IQuestionSetAddDefault);
  const questionAreas = useTypedSelector((state) => state.questionAreas.questionAreas);
  const questionSets = useTypedSelector((state) => state.questionSets.questionSets);
  const questions = useTypedSelector((state) => state.questions.questions);

  const navigate = useNavigate();
  const dispatch = useDispatch();

  const routeChange = () => {
    const path = `/${MainRoutes}`;
    navigate(path);
  };

  const saveAction = () => {
    QuestionSetService.addQuestionSet(questionSetModel);
    routeChange();
  };

  const changeNameHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
    setQuestionSetModel({
      ...questionSetModel,
      name: e.target.value,
    });
  };

  useEffect(() => {
    dispatch(getAllData());
    dispatch(getQuestions());
    dispatch(fetchAllQuestionAreas());
  }, [dispatch]);

  const addEmptyQuestionIdsArray = () => {
    const previousQuestionArray = [...questionSetModel.questionIds, 0];
    setQuestionSetModel({
      ...questionSetModel,
      questionIds: previousQuestionArray,
    });
  };

  const getQuestionAreaOptions = (id: number) => {
    const idsQuestionAreas = new Set([...questionSetModel.questionAreaIds]);
    return questionAreas.filter((item) => !idsQuestionAreas.has(item.id) || item.id === id);
  };

  const getQuestionOptions = (id: number) => {
    const idsSet = new Set([...questionSetModel.questionIds]);
    return questions.filter((item) => !idsSet.has(item.id) || item.id === id);
  };

  const changeQuestionHandler = (index: number) => (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const array = [...questionSetModel.questionIds];
    array[index] = Number(event.target.value);
    setQuestionSetModel({
      ...questionSetModel,
      questionIds: array,
    });
  };

  const addEmptyQuestionArea = () => {
    const previousQuestionAreasIdsArray = [...questionSetModel.questionAreaIds, 0];
    setQuestionSetModel({
      ...questionSetModel,
      questionAreaIds: previousQuestionAreasIdsArray,
    });
  };

  const changeQuestionAreaHandler = (index: number) => ( event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const array = [...questionSetModel.questionAreaIds];
    array[index] = Number(event.target.value);
    setQuestionSetModel({
      ...questionSetModel,
      questionAreaIds: array,
    });
  };

  return (
    <GridContainer>
      <Grid item>
        <BoxContainer>
          <Typography>Question set name: </Typography>
          <FormControl>
            <TextField
              required
              id="outlined-required"
              label="Required"
              sx={{ width: 180 }}
              value={questionSetModel.name}
              onChange={changeNameHandler}
            />
          </FormControl>
        </BoxContainer>
      </Grid>
      <Grid item>
        {questionSetModel.questionAreaIds.map((item, index) => (
          <BoxContainer key={item}>
            <Typography>Select question area: </Typography>
            <TextField
              id="outlined-select-question-area"
              select
              label="Select"
              helperText="Please select question area"
              value={item}
              onChange={changeQuestionAreaHandler(index)}
            >
              {getQuestionAreaOptions(item).map((questionArea) => (
                <MenuItem key={questionArea.id} value={questionArea.id}>
                  {questionArea.name}
                </MenuItem>
              ))}
            </TextField>
          </BoxContainer>
        ))}
        <ButtonContainer
          disabled={questionSets.length <= questionSetModel.questionAreaIds.length}
          variant="contained"
          onClick={addEmptyQuestionArea}
        >
          Add question area
        </ButtonContainer>
      </Grid>

      <Grid item>
        {questionSetModel.questionIds.map((item, index) => (
          <BoxContainer key={item}>
            <Typography>Select question: </Typography>
            <TextField
              id="outlined-select-question"
              select
              label="Select"
              helperText="Please select question"
              value={item}
              defaultValue={questionSetModel.questionIds[0]}
              onChange={changeQuestionHandler(index)}
            >
              {getQuestionOptions(item).map((question) => (
                <MenuItem key={question.id} value={question.id}>
                  {question.text}
                </MenuItem>
              ))}
            </TextField>
          </BoxContainer>
        ))}
        <ButtonContainer
          disabled={questions.length <= questionSetModel.questionIds.length}
          variant="contained"
          onClick={addEmptyQuestionIdsArray}
        >
          Add question
        </ButtonContainer>
      </Grid>
      <Grid item>
        <ButtonContainer variant="contained" onClick={saveAction}>
          Add question set
        </ButtonContainer>
      </Grid>
    </GridContainer>
  );
};

export default QuestionSetAdd;
