import axios from "axios";

const BASE_URL = " https://localhost:7082/api/v1";

export const getAllTickets = () => {
  return axios.get(`${BASE_URL}/tickets`);
};
