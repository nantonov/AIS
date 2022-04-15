import React, { useEffect, useState } from 'react';
import { Grid, Typography, Button, Box, FormControl, TextField } from '@mui/material';
import { useDispatch } from 'react-redux';
import { useAuth0 } from '@auth0/auth0-react';
import { useParams } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { QuestionAreaAdd } from '../../core/interfaces/questionArea/questionArea';
import { postQuestionArea, getQuestionAreaById } from '../../core/redux/thunk/questionAreaThunk';
import { defaultQuestionAreaAdd } from '../../core/common/defaultDTO/defaultQuestionArea';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import QuestionSets from './questionSetsForQuestionAreaForm/questionSetsForQuestionAreaForm';

const QuestionAreaForm: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [token, setToken] = useState('');
  const { id } = useParams();
  const dispatch = useDispatch();
  const [item, setItem] = useState<QuestionAreaAdd>(defaultQuestionAreaAdd);

  const { t } = useTranslation();

  useEffect(() => {
    const getUserMetadata = async () => {
      const accessToken = await getAccessTokenSilently({
        audience: `https://localhost:5001`,
        scope: 'read:current_user',
      });
      setToken(accessToken);
    };

    getUserMetadata();
    dispatch(getQuestionAreaById(Number(id), token));
  }, [dispatch, id, token, getAccessTokenSilently]);

  const change = (event: React.ChangeEvent<HTMLInputElement>) => {
    const copy = { ...item, name: event.target.value };
    setItem(copy);
  };

  const submit = () => {
    dispatch(postQuestionArea(item, token));
  };
  return (
    <GridContainer>
      <Grid item>
        <Box>
          <Typography>{t('questionAreaName')} </Typography>
          <FormControl>
            <TextField
              required
              id="outlined-required"
              label="Required"
              sx={{ width: 180 }}
              value={item.name}
              onChange={change}
            />
            <Button onClick={submit}>{t('send')}</Button>
            <QuestionSets questionArea={item} setItem={setItem} />
          </FormControl>
        </Box>
      </Grid>
    </GridContainer>
  );
};

export default QuestionAreaForm;
