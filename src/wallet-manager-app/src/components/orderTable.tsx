import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect } from "react";

interface Props {
  // Define the props for your component here
}

const OrderTable: React.FC<Props> = (props) => {
  const [orders, setOrders] = React.useState<Order[]>([]);
  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState<string | null>(null);

  const apiUrl = process.env.NEXT_PUBLIC_API_URL;
  
  useEffect(() => {
    const fetchOrders = async () => {
      var response = await axios.get(apiUrl + "/api/order");
      if (response.status === 200) {
        setOrders(response.data);
        setLoading(false);
      } else {
        setError("Error fetching data");
      }
    };
    fetchOrders();
  }, []);

  return (
    <>
      {loading && <div>Loading...</div>}
      {error && <div>{error}</div>}
      {!loading && !error && (
        <DataGrid
          rows={orders}
          columns={[
            { field: "id", headerName: "id" },
            { field: "dateTime", headerName: "dateTime" },
            { field: "operationType", headerName: "operationType" },
            { field: "dayTrade", headerName: "dayTrade" },
            { field: "completed", headerName: "completed" },
            { field: "amount", headerName: "amount" },
            { field: "price", headerName: "price" },
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

export default OrderTable;
