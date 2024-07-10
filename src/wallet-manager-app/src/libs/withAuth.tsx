import { useSession } from "next-auth/react";
import { useRouter } from "next/router";
import { useEffect } from "react";

const withAuth = (WrappedComponent : Next) => {
  return (
    (props) => {
      const {} = useSession();
      const router = useRouter();

      useEffect(() => {});

      if()
    },
    []
  );
};
