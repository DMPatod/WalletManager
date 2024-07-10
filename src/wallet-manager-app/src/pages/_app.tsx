import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterMoment } from "@mui/x-date-pickers/AdapterMoment";
import { SessionProvider, useSession } from "next-auth/react";
import { AppProps } from "next/app";
import { useRouter } from "next/router";

const App = ({ Component, pageProps }: AppProps) => {
  const { data: session, status } = useSession();
  const router = useRouter();

  if (status === "loading") {
    // Show loading state
    return <div>Loading...</div>;
  }

  if (!session) {
    // Redirect to sign in page
    router.push("/signin");
    return null;
  }

  return (
    <SessionProvider session={pageProps.session}>
      <LocalizationProvider dateAdapter={AdapterMoment}>
        <Component {...pageProps} />
      </LocalizationProvider>
    </SessionProvider>
  );
};

export default App;
