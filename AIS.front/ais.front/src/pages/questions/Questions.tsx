import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { useTranslation } from 'react-i18next';
import { Button, Grid, Typography } from '@mui/material';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { AddQuestionDialog } from './components/AddQuestionDialog';
import { QuestionComponent } from './components';
import { Question } from '../../core/interfaces/question/question';
import { getAllQuestions } from '../../core/redux/thunk/questionThunk';
import questionSelector from '../../core/redux/selectors/questionSelector';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import { GridItemContainer } from './styled/GridItemContainer';

const Questions: React.FC = () => {
  const [open, setOpen] = React.useState(false);
  const dispatch = useDispatch();
  const { questions } = useTypedSelector(questionSelector);
  const { t } = useTranslation();

  const handleClickOpen = () => {
    setOpen(true);
  };

  useEffect(() => {
    dispatch(getAllQuestions());
  }, [dispatch]);

  return (
    <GridItemContainer>
      <Grid pt={1} pb={1}>
        <Typography variant="h5">{t('Questions')}</Typography>
      </Grid>

      <Grid pt={1} pb={1}>
        <Button variant="contained" startIcon={<AddCircleIcon />} onClick={handleClickOpen}>
          {t('Add Question')}
        </Button>

        <AddQuestionDialog open={open} setOpen={setOpen} />
      </Grid>
      {questions.map((item: Question) => (
        <QuestionComponent key={item.id} item={item} />
      ))}
    </GridItemContainer>
  );
};

export default Questions;
