import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';

export const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      maxWidth: '350px',
      margin: '50px',
      textAlign: 'left',
    },
    favoriteButton: {
      justifyContent: 'end',
      margin: '5px 5px',
      transform: 'scale(1.3)',
    },
  }),
);
