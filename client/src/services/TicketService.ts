import axios from "axios";
import { Ticket } from "../interfaces/Ticket";

const BASE_URL = " https://localhost:7082/api/v1";

export const getAllTickets = async (page: number, pageSize: number) => {
  return axios.get(`${BASE_URL}/tickets`, { params: { page, pageSize } });
};

export const getTicketById = async (ticketId: number) => {
  return axios.get(`${BASE_URL}/tickets/${ticketId}`);
};

export const updateTicket = async (ticket: Ticket) => {
  console.log(ticket);
  return axios.put(`${BASE_URL}/tickets`, ticket, {
    headers: { "Content-Type": "application/json" },
  });
};
