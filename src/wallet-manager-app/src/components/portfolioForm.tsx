import { Button, TextField } from "@mui/material";
import React, { useState } from "react";

interface PortfolioFormProps {
  onSubmit: (portfolio: Portfolio) => void;
}

const PortfolioForm: React.FC<PortfolioFormProps> = ({ onSubmit }) => {
  const [title, setTitle] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({ title });
  };

  return (
    <form onSubmit={handleSubmit}>
      <TextField
        label="Title"
        onChange={(ev) => {
          setTitle(ev.target.value);
        }}
      ></TextField>
      <Button variant="contained" type="submit">
        Submit
      </Button>
    </form>
  );
};

export default PortfolioForm;
