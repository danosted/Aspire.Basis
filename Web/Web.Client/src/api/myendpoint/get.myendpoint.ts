import client from "../client";

export const getFromMyEndpointAsync = async () => {
  try {
    const { data } = await client.GET("/v1/api/my-endpoint", {
      params: {},
    });
    return data;
  } catch (error) {
    console.error("Error fetching data from my endpoint:", error);
    throw error;
  }
};