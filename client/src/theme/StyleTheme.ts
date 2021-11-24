import { createTheme } from '@mui/material';
import { grey, red } from '@mui/material/colors';

export const theme = createTheme({
  typography: {
    fontFamily: ['Montserrat', 'sans-serif'].join(','),
  },
  palette: {
    primary: {
      main: red[600],
    },
    secondary: {
      main: grey[700],
    },
  },
});
