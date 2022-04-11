import { FormControl, Grid, MenuItem, TextField } from '@mui/material';
import Typography from '@mui/material/Typography';
import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { QuestionSetAddState } from '../../core/interfaces/questionSet/questionSet';
import { IQuestionSetAddDefault } from '../../core/common/defaultDTO/defaultQuestionSet';
import { addQuestionSetService } from '../../core/services/questionSetService';
import { getAllQuestionSets } from '../../core/redux/thunk/questionSetThunk';
import { getAllQuestions } from '../../core/redux/thunk/questionThunk';
import { getAllQuestionAreas } from '../../core/redux/thunk/questionAreaThunk';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import BoxContainer from '../../core/components/boxContainer/BoxContainer';
import ButtonContainer from '../../core/components/buttonContainer/ButtonContainer';
import MainRoutes from '../../core/constants/mainRoutes';
import questionAreaSelector from '../../core/redux/selectors/questionAreaSelector';
import questionSetSelector from '../../core/redux/selectors/questionSetSelector';
import questionSelector from '../../core/redux/selectors/questionSelector';

const QuestionSetAdd: React.FC = () => {
  const [questionSetModel, setQuestionSetModel] =
    useState<QuestionSetAddState>(IQuestionSetAddDefault);
  const { questionAreas } = useTypedSelector(questionAreaSelector);
  const { questionSets } = useTypedSelector(questionSetSelector);
  const { questions } = useTypedSelector(questionSelector);

  const { t } = useTranslation();

  const navigate = useNavigate();
  const dispatch = useDispatch();

  const routeChange = () => {
    const path = `/${MainRoutes.questionSets}`;
    navigate(path);
  };

  const saveAction = () => {
    addQuestionSetService(questionSetModel);
    routeChange();
  };

  const changeNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setQuestionSetModel({
      ...questionSetModel,
      name: event.target.value,
    });
  };

  useEffect(() => {
    dispatch(getAllQuestionSets());
    dispatch(getAllQuestions());
    dispatch(getAllQuestionAreas());
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

  const changeQuestionHandler =
    (index: number) => (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
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

  const changeQuestionAreaHandler =
    (index: number) => (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
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
          <Typography>{t('questionSetName')} </Typography>
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
            <Typography>{t('selectQuestionArea')} </Typography>
            <TextField
              id="outlined-select-question-area"
              select
              label="Select"
              helperText={t('pleaseSelectQuestionArea')}
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
          {t('addQuestionArea')}
        </ButtonContainer>
      </Grid>

      <Grid item>
        {questionSetModel.questionIds.map((item, index) => (
          <BoxContainer key={item}>
            <Typography>{t('selectQuestion')} </Typography>
            <TextField
              id="outlined-select-question"
              select
              label="Select"
              helperText="pleaseSelectQuestion"
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
          {t('addQuestion')}
        </ButtonContainer>
      </Grid>
      <Grid item>
        <ButtonContainer variant="contained" onClick={saveAction}>
          {t('addQuestionSet')}
        </ButtonContainer>
      </Grid>
    </GridContainer>
  );
};

export default QuestionSetAdd;
