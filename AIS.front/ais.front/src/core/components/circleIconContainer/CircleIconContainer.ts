import styledComponent from 'styled-components';
import AddCircleIcon from '@mui/icons-material/AddCircle';

const CircleIconContainer = styledComponent(AddCircleIcon)`
  color: #1976d2;
  fontsize: 'large';
  font-size: 3.5rem;
  display: flex;
  opacity: 1;

  &:hover {
    color: #0d4f91;
  }
`;

export default CircleIconContainer;
