import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Grid } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { getAllQuestionSets } from '../../core/redux/thunk/questionSetThunk';
import QuestionSetItem from './questionSetItem/QuestionSetItem';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import QuestionSetItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
import MainRoutes from '../../core/constants/mainRoutes';
import questionSetSelector from '../../core/redux/selectors/questionSetSelector';

const QuestionsSets: React.FC = () => {
  const { questionSets } = useTypedSelector(questionSetSelector);
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const { t } = useTranslation();

  const routeChange = () => {
    const path = `/${MainRoutes.addQuestionSet}`;
    navigate(path);
  };

  useEffect(() => {
    dispatch(getAllQuestionSets());
  }, [dispatch]);

  return (
    <Grid>
      <Grid item>
        <Container>
          <QuestionSetItems>
            {questionSets.length ? (
              questionSets.map((item) => <QuestionSetItem key={item.id} questionSet={item} />)
            ) : (
              <TypographyContainer align="center" variant="h3">
                {t('somethingWentWrongPleaseRefreshPage')}
              </TypographyContainer>
            )}
          </QuestionSetItems>
        </Container>
      </Grid>
      <Grid item>
        <ToolTipContainer title={t('addQuestionSet').toString()} placement="left-start">
          <CircleIconContainer onClick={routeChange} />
        </ToolTipContainer>
      </Grid>
    </Grid>
  );
};

export default QuestionsSets;
