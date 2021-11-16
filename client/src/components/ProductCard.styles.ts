import { makeStyles, Theme, createStyles, hexToRgb } from '@material-ui/core/styles';

export const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      maxWidth: '350px',
      margin: '50px',
      borderRadius: '10px',
      textAlign: 'left',
    },
    favoriteButton: {
      color: hexToRgb('#cc3c0e'),
      justifyContent: 'end',
      margin: '5px 5px',
    },
  }),
);
