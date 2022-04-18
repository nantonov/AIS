import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
  Typography,
} from '@mui/material';
import defaultQuestion from '../../../core/common/defaultDTO/defaultQuestion';
import defaultTrueAnswer from '../../../core/common/defaultDTO/defaultTrueAnswer';
import { Question } from '../../../core/interfaces/question/question';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer/trueAnswer';

interface Props {
  open: boolean;
  setOpen: (open: boolean) => void;
}

export const AddQuestionDialog: React.FC<Props> = ({ setOpen, open }) => {
  const [question, setQuestion] = useState<Question>(defaultQuestion);
  const [trueAnswer, setTrueAnswer] = useState<TrueAnswer>(defaultTrueAnswer);
  const { t } = useTranslation();

  const handleClose = () => {
    setOpen(false);
  };

  const changeQuestion = (event: React.ChangeEvent<HTMLInputElement>) => {
    const copy = { ...question, text: event.target.value };
    setQuestion(copy);
  };

  const changeTrueAnswer = (event: React.ChangeEvent<HTMLInputElement>) => {
    const copy = { ...trueAnswer, text: event.target.value };
    setTrueAnswer(copy);
  };

  return (
    <Dialog open={open} onClose={handleClose} PaperProps={{ sx: { width: '75%', height: '50%' } }}>
      <DialogTitle color="primary">{t('New Question')}</DialogTitle>

      <DialogContent>
        <Typography>{t('Question')}</Typography>
        <TextField
          fullWidth
          autoFocus
          type="text"
          value={question.text}
          onChange={changeQuestion}
        />

        <Typography pt={2}>True Answer</Typography>
        <TextField
          id="standard-multiline-flexible"
          fullWidth
          multiline
          maxRows={8}
          value={trueAnswer.text}
          onChange={changeTrueAnswer}
        />
      </DialogContent>

      <DialogActions>
        <Button onClick={handleClose} variant="contained">
          {t('Cancel')}
        </Button>
        <Button onClick={handleClose} variant="contained">
          {t('Add')}
        </Button>
      </DialogActions>
    </Dialog>
  );
};
