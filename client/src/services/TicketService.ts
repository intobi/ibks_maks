import axios from "axios";

const BASE_URL = " https://localhost:7082/api/v1";

export const getAllTickets = async (page: number, pageSize: number) => {
  return axios.get(`${BASE_URL}/tickets`, { params: { page, pageSize } });
};
