import OrderForm from "@/components/orderForm";
import OrderTable from "@/components/orderTable";
import PortfolioForm from "@/components/portfolioForm";
import PortfolioTable from "@/components/portfolioTable";
import TicketForm from "@/components/ticketForm";
import TicketTable from "@/components/ticketTable";
import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Grid,
  Radio,
  RadioGroup,
} from "@mui/material";
import React from "react";

const IndexPage: React.FC = () => {
  const [radio, setRadio] = React.useState<string>("order");

  return (
    <Grid container spacing={2}>
      <Grid item xs={6}>
        <PortfolioTable />
      </Grid>
      <Grid item xs={6}>
        <TicketTable />
      </Grid>
      <Grid item xs={12}>
        <OrderTable />
      </Grid>
      <Grid item xs={12}>
        <FormControl>
          <FormLabel>Submition Form</FormLabel>
          <RadioGroup
            onChange={(ev) => {
              setRadio(ev.target.value);
            }}
          >
            <FormControlLabel
              value="portfolio"
              control={<Radio />}
              label="Portfolio"
            />
            <FormControlLabel
              value="ticket"
              control={<Radio />}
              label="Ticket"
            />
            <FormControlLabel value="order" control={<Radio />} label="Order" />
          </RadioGroup>
        </FormControl>
        {radio === "portfolio" && (
          <PortfolioForm
            onSubmit={(formProps) => {
              console.log(formProps);
            }}
          />
        )}
        {radio === "ticket" && (
          <TicketForm
            onSubmit={(formProps) => {
              console.log("Ticket Form");
              console.log(formProps);
            }}
          />
        )}
        {radio === "order" && (
          <OrderForm
            onSubmit={(formProps) => {
              console.log("Order Form");
              console.log(formProps);
            }}
          />
        )}
      </Grid>
    </Grid>
  );
};

export default IndexPage;
