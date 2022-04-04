import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Grid } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { fetchAllQuestionAreas } from '../../core/store/questionArea/actionCreators';
import QuestionAreaItem from './questionAreaItem/QuestionAreaItem';
import QuestionAreaItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
import MainRoutes from '../../core/constants/mainRoutes';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';

const QuestionsAreas: React.FC = () => {
  const questionAreas = useTypedSelector((state) => state.questionAreas.questionAreas);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const routeChange = () => {
    const path = `/${MainRoutes.questionAreaForm}`;
    navigate(path);
  };

  useEffect(() => {
    dispatch(fetchAllQuestionAreas());
  }, [dispatch]);

  return (
    <Grid>
      <Grid item>
        <Container>
          <QuestionAreaItems>
            {questionAreas.length ? (
              questionAreas.map((item) => <QuestionAreaItem key={item.id} questionArea={item} />)
            ) : (
              <TypographyContainer align="center" variant="h3">
                Something went wrong. Please refresh page!!!.
              </TypographyContainer>
            )}
          </QuestionAreaItems>
        </Container>
      </Grid>
      <Grid item>
        <ToolTipContainer title="Add question area" placement="left-start">
          <CircleIconContainer onClick={routeChange} />
        </ToolTipContainer>
      </Grid>
    </Grid>
  );
};

export default QuestionsAreas;
