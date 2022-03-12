import { AlertColor } from '@mui/material/Alert';

export interface IToastMessage {
  visible: boolean;
  text: string;
  severity: AlertColor;
}
