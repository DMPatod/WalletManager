import axios from "axios";
import { NextApiRequest, NextApiResponse } from "next";
import NextAuth, { NextAuthOptions } from "next-auth";
import Credentials from "next-auth/providers/credentials";

const options: NextAuthOptions = {
  providers: [
    Credentials({
      name: "Credentials",
      credentials: {
        username: { label: "Username", type: "text" },
        password: { label: "Password", type: "password" },
      },
      async authorize(credentials) {
        if (credentials === undefined) {
          return null;
        }

        const apiUrl = process.env.NEXT_PUBLIC_API_URL;

        var response = await axios.post(apiUrl + "/api/auth/signIn", {
          username: credentials.username,
          password: credentials.password,
        });

        if (response.status === 200) {
          return {
            id: response.data.id,
            name: response.data.name,
            email: response.data.email,
            image: response.data.image,
          };
        }

        return null;
      },
    }),
  ],
};

export default (req: NextApiRequest, res: NextApiResponse) =>
  NextAuth(req, res, options);
