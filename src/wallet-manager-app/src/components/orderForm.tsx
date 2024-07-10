import { Autocomplete, Button, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { useState } from "react";

interface OrderFormProps {
  onSubmit: (title: string) => void;
}

const OrderForm: React.FC<OrderFormProps> = ({ onSubmit }) => {
  const [title, setTitle] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(title);
    setTitle("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <Autocomplete
        freeSolo
        options={[]}
        renderInput={(params) => <TextField {...params} label="Ticket" />}
      />
      <DatePicker label="Date" />
      <TextField label="Amount"></TextField>
      <TextField label="Price"></TextField>
      <Button variant="contained" type="submit">
        Submit
      </Button>
    </form>
  );
};

export default OrderForm;
