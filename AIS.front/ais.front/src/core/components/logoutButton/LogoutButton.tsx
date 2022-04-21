import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import { MenuItem, Typography } from '@mui/material';

const LogoutButton: React.FC = () => {
  const { logout } = useAuth0();

  return (
    <MenuItem onClick={() => logout({ returnTo: window.location.origin })}>
      <Typography textAlign="center">Log Out</Typography>
    </MenuItem>
  );
};

export default LogoutButton;
