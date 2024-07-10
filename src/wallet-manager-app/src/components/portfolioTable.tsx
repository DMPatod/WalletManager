import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import React from "react";

interface Props {}

const PortfolioTable: React.FC<Props> = () => {
  const [portfolios, setPortfolios] = React.useState<Portfolio[]>([]);
  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState<string | null>(null);

  const apiUrl = process.env.NEXT_PUBLIC_API_URL;

  React.useEffect(() => {
    const fetchPortfolio = async () => {
      console.log(apiUrl + "/api/portfolio");
      var response = await axios.get(apiUrl + "/api/portfolio");

      if (response.status === 200) {
        setPortfolios(response.data);
        setLoading(false);
      } else {
        setError("Error fetching data");
      }
    };
    fetchPortfolio();
  }, []);

  return (
    <>
      {loading && <div>Loading...</div>}
      {error && <div>{error}</div>}
      {!loading && !error && (
        <DataGrid
          rows={portfolios}
          columns={[
            { field: "id", headerName: "ID" },
            { field: "title", headerName: "Title" },
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

export default PortfolioTable;
