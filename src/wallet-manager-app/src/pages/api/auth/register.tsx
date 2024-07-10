import { Button, Grid, TextField } from "@mui/material";

const RegisterPage: React.FC = () => {
  return (
    <Grid container spacing={2}>
      <Grid item xs={6}>
        <form>
          <TextField label="Username" onChange={(ev) => {}} />
          <TextField label="Username" onChange={(ev) => {}} />
          <Button variant="contained" type="submit">
            Submit
          </Button>
        </form>
      </Grid>
    </Grid>
  );
};

export default RegisterPage;