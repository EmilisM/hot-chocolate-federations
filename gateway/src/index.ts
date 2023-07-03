import { ApolloServer } from "@apollo/server";
import { startStandaloneServer } from "@apollo/server/standalone";
import {
  ApolloGateway,
  IntrospectAndCompose,
  RemoteGraphQLDataSource,
} from "@apollo/gateway";

const gateway = new ApolloGateway({
  supergraphSdl: new IntrospectAndCompose({
    subgraphs: [
      {
        name: "sub-schema-one",
        url: "http://localhost:4001/graphql",
      },
      {
        name: "sub-schema-two",
        url: "http://localhost:4002/graphql",
      },
    ],
    introspectionHeaders: {
      Accept: "application/json",
    },
  }),
  buildService({ name, url }) {
    return new HotChocolateDataSource({ url });
  },
});

class HotChocolateDataSource extends RemoteGraphQLDataSource {
  willSendRequest({ request, context }) {
    request.http.headers.set("Accept", "application/json");
  }
}

const server = new ApolloServer({
  gateway,
});

const { url } = await startStandaloneServer(server, {
  listen: {
    port: 5000,
  },
});

console.log(`🚀  Server ready at ${url}`);
