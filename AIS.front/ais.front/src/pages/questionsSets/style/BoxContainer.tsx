import styled from 'styled-components';
import { Box } from '@mui/material';

export const BoxContainer = styled(Box)`
  overflow-y: auto;
`;

export const BoxStyle = {
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
