import { Button, Grid, TextField } from "@mui/material";
import { signIn } from "next-auth/react";
import { useState } from "react";

const SignInPage: React.FC = () => {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  return (
    <Grid container spacing={2}>
      <Grid item xs={6}>
        <form
          onSubmit={() => {
            signIn("credentials", {
              username,
              password,
              callbackUrl: "/",
            });
          }}
        >
          <TextField
            label="Username"
            onChange={(ev) => {
              setUsername(ev.target.value);
            }}
          />
          <TextField
            label="Username"
            onChange={(ev) => {
              setPassword(ev.target.value);
            }}
          />
          <Button variant="contained" type="submit">
            Submit
          </Button>
        </form>
      </Grid>
    </Grid>
  );
};

export default SignInPage;
