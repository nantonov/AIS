import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { Grid } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';
import { useTranslation } from 'react-i18next';
import { getAllQuestionAreas } from '../../core/redux/thunk/questionAreaThunk';
import QuestionAreaItem from './questionAreaItem/QuestionAreaItem';
import QuestionAreaItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
import MainRoutes from '../../core/constants/mainRoutes';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import questionAreaSelector from '../../core/redux/selectors/questionAreaSelector';

const QuestionsAreas: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();
  const { questionAreas } = useTypedSelector(questionAreaSelector);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const [token, setToken] = useState('');
  const { t } = useTranslation();

  const routeChange = () => {
    const path = `/${MainRoutes.questionAreaForm}`;
    navigate(path);
  };

  useEffect(() => {
    const getUserMetadata = async () => {
      const accessToken = await getAccessTokenSilently({
        audience: `https://localhost:5001`,
        scope: 'read:current_user',
      });
      setToken(accessToken);
    };

    getUserMetadata();

    dispatch(getAllQuestionAreas(token));
  }, [dispatch, getAccessTokenSilently, token]);

  return (
    <Grid>
      <Grid item>
        <Container>
          <QuestionAreaItems>
            {questionAreas.length ? (
              questionAreas.map((item) => <QuestionAreaItem key={item.id} questionArea={item} />)
            ) : (
              <TypographyContainer align="center" variant="h3">
                {t('somethingWentWrongPleaseRefreshPage')}
              </TypographyContainer>
            )}
          </QuestionAreaItems>
        </Container>
      </Grid>
      <Grid item>
        <ToolTipContainer title={t('addQuestionArea').toString()} placement="left-start">
          <CircleIconContainer onClick={routeChange} />
        </ToolTipContainer>
      </Grid>
    </Grid>
  );
};

export default QuestionsAreas;
