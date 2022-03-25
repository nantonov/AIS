import { AlertColor } from '@mui/material/Alert';

export interface ToastMessage {
  visible: boolean;
  text: string;
  severity: AlertColor;
}
