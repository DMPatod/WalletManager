import {
  Autocomplete,
  Button,
  FormControlLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@mui/material";
import { useMemo, useState } from "react";

interface TicketFormProps {
  onSubmit: (ticket: Ticket) => void;
}

const TicketForm: React.FC<TicketFormProps> = ({ onSubmit }) => {
  const [cod, setCod] = useState("");
  const [title, setTitle] = useState("");
  const [owner, setOwner] = useState("");
  const [currency, setCurrency] = useState("BRL");
  const [portfolio, setPortfolio] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({
      cod,
      title,
      owner,
      currency,
      portfolio,
    });
  };

  const selectedValues = useMemo(() => {
    return [];
  }, []);

  return (
    <form onSubmit={handleSubmit}>
      <TextField
        label="Cod"
        onChange={(ev) => {
          setCod(ev.target.value);
        }}
      ></TextField>
      <TextField
        label="Title"
        onChange={(ev) => {
          setTitle(ev.target.value);
        }}
      ></TextField>
      <TextField
        label="Owner"
        onChange={(ev) => {
          setOwner(ev.target.value);
        }}
      ></TextField>
      <RadioGroup
        onChange={(ev) => {
          setCurrency(ev.target.value);
        }}
      >
        <FormControlLabel value="BRL" control={<Radio />} label="BRL" />
        <FormControlLabel value="USD" control={<Radio />} label="USD" />
      </RadioGroup>
      <Autocomplete
        freeSolo
        onChange={(ev, v) => {
          if (v != null) {
            if (typeof v === "string") {
              setPortfolio(v);
            } else {
              setPortfolio(v.id);
            }
          }
        }}
        options={[
          { label: "1", id: "1" },
          { label: "2", id: "2" },
        ]}
        renderInput={(params) => <TextField {...params} label="Ticket" />}
      />
      <Button variant="contained" type="submit">
        Submit
      </Button>
    </form>
  );
};

export default TicketForm;
