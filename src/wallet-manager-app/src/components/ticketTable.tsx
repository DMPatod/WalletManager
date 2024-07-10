import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect } from "react";

interface Props {
  // Define your component's props here
}

const TicketTable: React.FC<Props> = (props) => {
  const [tickets, setTickets] = React.useState<Ticket[]>([]);
  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState<string | null>(null);

  const apiUrl = process.env.NEXT_PUBLIC_API_URL;

  useEffect(() => {
    const fetchTickets = async () => {
      var response = await axios.get(apiUrl + "/api/ticket");
      if (response.status === 200) {
        setTickets(response.data);
        setLoading(false);
      } else {
        setError("Error fetching data");
      }
    };
    fetchTickets();
  }, []);

  return (
    <>
      {loading && <div>Loading...</div>}
      {error && <div>{error}</div>}
      {!loading && !error && (
        <DataGrid
          rows={tickets}
          columns={[
            { field: "id", headerName: "id" },
            { field: "cod", headerName: "title" },
            { field: "title", headerName: "id" },
            { field: "owner", headerName: "title" },
            { field: "currency", headerName: "id" },
          ]}
          initialState={{
            pagination: { paginationModel: { page: 0, pageSize: 5 } },
          }}
          pageSizeOptions={[5, 10, 20]}
          checkboxSelection
        />
      )}
    </>
  );
};

export default TicketTable;
