import { queryOptions } from "@tanstack/react-query";
import client from "../client";
import { getFromMyEndpointAsync } from "./get.myendpoint";

export const myEndpointOptions = queryOptions({
  queryKey: ['myendpoint'],
  queryFn: () => getFromMyEndpointAsync(),
})