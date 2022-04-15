import React, { useEffect, useState } from 'react';
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
import { useAuth0 } from '@auth0/auth0-react';
import { useNavigate, useParams } from 'react-router-dom';
import DeleteIcon from '@mui/icons-material/Delete';
import Typography from '@mui/material/Typography';
import { ExpandMore } from '@material-ui/icons';
import { useTranslation } from 'react-i18next';
import { deleteByTwoIdsAreaSet } from '../../core/services/questionAreasQuestionSetsService';
import { getQuestionAreaById } from '../../core/redux/thunk/questionAreaThunk';
import GridContainer from '../../core/components/gridContainer/GridContainer';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import MainRoutes from '../../core/constants/mainRoutes';
import questionAreaSelector from '../../core/redux/selectors/questionAreaSelector';

const QuestionAreaDescription: React.FC = () => {
  const [token, setToken] = useState('');
  const { getAccessTokenSilently } = useAuth0();
  const { id } = useParams();
  const navigate = useNavigate();
  const { questionArea } = useTypedSelector(questionAreaSelector);
  const dispatch = useDispatch();

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
  const routeChangeSet = (changeId: Number) => () => {
    const path = `/${MainRoutes.questionSet}/${changeId}`;
    navigate(path);
  };
  const DeleteQuestionSet = (questionAreaId: number, questionSetId: number) => () => {
    deleteByTwoIdsAreaSet(questionAreaId, questionSetId).then(() => {
      getQuestionAreaById(Number(id), token);
    });
  };

  return (
    <GridContainer>
      <Grid item>
        <Typography variant="h4" component="h5">
          {t('questionArea:')} {questionArea?.name}
        </Typography>
      </Grid>
      <Grid item>
        <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">
          {t('questionSets')}
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>{t(`questionSets`)}</TableCell>
                <TableCell />
              </TableRow>
            </TableHead>
            <TableBody>
              {questionArea?.questionSets.map((questionSet) => (
                <TableRow
                  key={questionSet.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {questionSet.name}
                  </TableCell>
                  <TableCell align="right">
                    <Button onClick={routeChangeSet(questionSet.id)} endIcon={<ExpandMore />} />
                    <Button
                      endIcon={<DeleteIcon />}
                      onClick={DeleteQuestionSet(Number(id), questionSet.id)}
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

export default QuestionAreaDescription;
