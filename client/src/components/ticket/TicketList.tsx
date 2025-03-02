import { useState } from "react";
import { Ticket } from "../../interfaces/Ticket";
import { useQuery } from "@tanstack/react-query";
import { getAllTickets } from "../../services/TicketService";
import {
  getPriorityBadge,
  getStateText,
  getTypeText,
} from "../../helpers/TicketHelper";
import { useNavigate } from "react-router-dom";

export default function TicketList() {
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const navigate = useNavigate();

  const { data: tickets, isLoading } = useQuery({
    queryFn: async () => (await getAllTickets(page, pageSize)).data,
    queryKey: ["tickets", page, pageSize],
  });

  const isLastPage = tickets?.length < pageSize;

  if (isLoading)
    return (
      <div className="d-flex justify-content-center">
        <div className="spinner-border m-5" role="status">
          <span className="sr-only"></span>
        </div>
      </div>
    );

  if (!isLoading && tickets?.length == 0)
    return (
      <div className="d-flex justify-content-center">
        <h2>No tickets found</h2>
      </div>
    );

  const handleAddTicket = () => {
    alert("Not a part of a test task. Just click it whenever you want");
  };

  const redirectToEditPage = (ticketId: number) => {
    navigate(`/ticket/${ticketId}`);
  };

  return (
    <div className="table-responsive" style={{ maxWidth: "900px" }}>
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2 className="mb-0">Tickets</h2>
        <button className="btn btn-primary" onClick={handleAddTicket}>
          Add New Ticket
        </button>
      </div>
      <table className="table table-hover table-bordered border-secondary text-center align-middle">
        <thead>
          <tr>
            <th
              scope="col"
              style={{
                width: "45px",
                minWidth: "45px",
                textAlign: "center",
                padding: "6px",
              }}
            >
              Lvl
            </th>
            <th
              scope="col"
              style={{ width: "50px", minWidth: "50px", padding: "6px" }}
            >
              #
            </th>
            <th scope="col" style={{ minWidth: "200px", padding: "10px" }}>
              Title
            </th>
            <th scope="col" style={{ minWidth: "150px", padding: "10px" }}>
              Module
            </th>
            <th scope="col" style={{ minWidth: "120px", padding: "10px" }}>
              Type
            </th>
            <th scope="col" style={{ minWidth: "120px", padding: "10px" }}>
              State
            </th>
          </tr>
        </thead>
        <tbody>
          {tickets?.map((ticket: Ticket) => (
            <tr
              key={ticket.id}
              onClick={() => redirectToEditPage(ticket.id)}
              style={{ cursor: "pointer" }}
            >
              <td style={{ width: "45px", minWidth: "45px", padding: "4px" }}>
                <div
                  className="d-flex justify-content-center align-items-center"
                  style={{ height: "45px" }}
                >
                  <span
                    className={`badge ${getPriorityBadge(
                      ticket.priorityId
                    )} rounded-circle d-inline-block`}
                    style={{ width: "40px", height: "40px" }}
                  ></span>
                </div>
              </td>
              <td style={{ width: "50px", minWidth: "50px", padding: "4px" }}>
                {ticket.id}
              </td>
              <td style={{ minWidth: "200px", padding: "10px" }}>
                {ticket.title}
              </td>
              <td style={{ minWidth: "150px", padding: "10px" }}>
                {ticket.applicationName}
              </td>
              <td style={{ minWidth: "120px", padding: "10px" }}>
                {getTypeText(ticket.ticketTypeId)}
              </td>
              <td style={{ minWidth: "120px", padding: "10px" }}>
                {getStateText(ticket.statusId)}
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="d-flex justify-content-between align-items-center mt-3">
        <nav aria-label="Page navigation">
          <ul className="pagination mb-0">
            <li className={`page-item ${page === 1 ? "disabled" : ""}`}>
              <button
                className="page-link"
                onClick={() => setPage((prev) => Math.max(prev - 1, 1))}
              >
                &laquo; Previous
              </button>
            </li>
            <li className={`page-item ${isLastPage ? "disabled" : ""}`}>
              <button
                className="page-link"
                onClick={() => setPage((prev) => prev + 1)}
              >
                Next &raquo;
              </button>
            </li>
          </ul>
        </nav>
        <div>
          <label className="me-2">Page Size:</label>
          <select
            className="form-select w-auto d-inline-block"
            value={pageSize}
            onChange={(e) => {
              setPageSize(Number(e.target.value));
              setPage(1);
            }}
          >
            {[5, 10, 20, 50].map((size) => (
              <option key={size} value={size}>
                {size}
              </option>
            ))}
          </select>
        </div>
      </div>
    </div>
  );
}
