import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';

export const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    title: {
      fontFamily: theme.typography.fontFamily,
    },
    price: {
      fontFamily: theme.typography.fontFamily,
    },
  }),
);
