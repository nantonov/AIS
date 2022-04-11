import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Box, Button, Grid, Modal } from '@mui/material';
// import { useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { getAllQuestionSets } from '../../core/redux/thunk/questionSetThunk';
import QuestionSetItem from './questionSetItem/QuestionSetItem';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import QuestionSetItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
// import MainRoutes from '../../core/constants/mainRoutes';
import questionSetSelector from '../../core/redux/selectors/questionSetSelector';
import QuestionSetAdd from '../questionSetAdd/QuestionSetAdd';
import { DivContainer } from '../questionSetAdd/BoxContainer';
// import { QuestionSetAddModal } from '../questionSetAdd/questionSetAddModal/QuestionSetAddModal';

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 700,
  height: 700,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

const QuestionsSets: React.FC = () => {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const { questionSets } = useTypedSelector(questionSetSelector);
  // const navigate = useNavigate();
  const dispatch = useDispatch();

  const { t } = useTranslation();

  // const routeChange = () => {
  //   const path = `/${MainRoutes.addQuestionSet}`;
  //   navigate(path);
  // };

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
          <Button onClick={handleOpen}>
            <CircleIconContainer />
          </Button>
        </ToolTipContainer>
      </Grid>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <DivContainer>
          <Box sx={style}>
            <QuestionSetAdd />
          </Box>
        </DivContainer>
      </Modal>
    </Grid>
  );
};

export default QuestionsSets;
