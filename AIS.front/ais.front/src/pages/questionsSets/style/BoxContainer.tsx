import styled from 'styled-components';
import { Box } from '@mui/material';

export const BoxContainer = styled(Box)`
  overflow-y: auto;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: white;
  border: 2px solid #000;
  width: 45%;
  padding-bottom: 5px;
  height: 400px;
`;
