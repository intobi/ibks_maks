import axios from "axios";
import { Reply } from "../interfaces/Reply";

const BASE_URL = " https://localhost:7082/api/v1";

export const getAllReplies = async (
  page: number,
  pageSize: number,
  ticketId: number
) => {
  return axios.get(`${BASE_URL}/replies`, {
    params: { page, pageSize, ticketId },
  });
};

export const createReply = async (reply: Reply) => {
  return axios.post(`${BASE_URL}/replies`, reply);
};
