import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import { MenuItem, Typography } from '@mui/material';

const LoginButton: React.FC = () => {
  const { loginWithRedirect } = useAuth0();

  return (
    <MenuItem onClick={() => loginWithRedirect()}>
      <Typography textAlign="center">Log In</Typography>
    </MenuItem>
  );
};

export default LoginButton;
