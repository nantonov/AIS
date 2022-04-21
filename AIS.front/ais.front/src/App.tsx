import React, { useEffect } from 'react';
import { Provider } from 'react-redux';
import { Route, Routes } from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';
import Header from './core/components/header/Header';
import { store } from './core/redux/store';
import MainRoutes from './core/constants/mainRoutes';
import Sessions from './pages/session/Session';
import QuestionsSets from './pages/questionsSets/QuestionsSets';
import QuestionSetDescription from './pages/questionSetDescription/QuestionSetDescription';
import QuestionAreaForm from './pages/questionAreaForm/QuestionAreaForm';
import QuestionAreas from './pages/questionAreas/QuestionAreas';
import QuestionAreaDescription from './pages/questionAreaDescription/QuestionAreaDescription';
import { addAccessTokenInterceptor } from './config/getAxious';

const App: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();

  useEffect(() => {
    addAccessTokenInterceptor(getAccessTokenSilently);
  }, [getAccessTokenSilently]);

  return (
    <Provider store={store}>
      <Header />
      <Routes>
        <Route path={MainRoutes.questionAreas} element={<QuestionAreas />} />
        <Route path={MainRoutes.sessions} element={<Sessions />} />
        <Route path={MainRoutes.questionSets} element={<QuestionsSets />} />
        <Route path={`${MainRoutes.questionSet}/:id`} element={<QuestionSetDescription />} />
        <Route path={`${MainRoutes.questionArea}/:id`} element={<QuestionAreaDescription />} />
        <Route path={`${MainRoutes.questionAreaForm}/:id`} element={<QuestionAreaForm />} />
        <Route path={MainRoutes.questionAreaForm} element={<QuestionAreaForm />} />
      </Routes>
    </Provider>
  );
};

export default App;
