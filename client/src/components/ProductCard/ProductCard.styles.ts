import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';

export const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      textAlign: 'left',
      fontFamily: theme.typography.fontFamily,
    },
    favoriteButton: {
      justifyContent: 'end',
      // margin: '5px 5px',
      transform: 'scale(1.3)',
    },
    text: {
      textDecoration: 'none',
      '&:hover': {
        textDecoration: 'underline',
      },
    },
  }),
);
