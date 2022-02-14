import { makeStyles, createStyles } from '@material-ui/core/styles';

export const useStyles = makeStyles(() =>
  createStyles({
    root: {
      display: 'flex',
      justifyContent: 'end',
      margin: '10px',
    },
    closeIcon: {
      cursor: 'pointer',
      opacity: 0.4,
      '&:hover': {
        opacity: 0.8,
      },
    },
    textBox: {
      width: 200,
    },
    searchIcon: {
      opacity: 0.8,
      cursor: 'pointer',
      '&:hover': {
        opacity: 1,
      },
    },
  }),
);
