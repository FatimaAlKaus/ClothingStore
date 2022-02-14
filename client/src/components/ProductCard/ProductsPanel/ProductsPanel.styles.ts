import { createStyles, makeStyles } from '@material-ui/core/styles';

export const useStyles = makeStyles(() =>
  createStyles({
    pagination: {
      display: 'flex',
      justifyContent: 'center',
      margin: '10px',
      alignItems: 'end',
    },
    searchBar: {
      display: 'flex',
      justifyContent: 'end',
      margin: '10px',
    },
  }),
);
