import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';

export const useStyles = makeStyles((theme: Theme) => ({
  content: {
    margin: theme.spacing(2),
    padding: theme.spacing(2),
  },
  toolbar: {
    display: 'flex',
    justifyContent: 'space-between',
    marginBottom: theme.spacing(2),
  },
  botToolBar: {
    marginTop: theme.spacing(2),
    display: 'flex',
    justifyContent: 'end',
  },
  actionRow: {
    display: 'flex',
    flex: 1,
    justifyContent: 'space-between',
  },
  saveButton: {},
}));
