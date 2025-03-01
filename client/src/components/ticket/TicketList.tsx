import { useState } from "react";
import { Ticket } from "../../interfaces/Ticket";
import { useQuery } from "@tanstack/react-query";
import { getAllTickets } from "../../services/ticketService";

export default function TicketList() {
  const [page, setPage] = useState(0);

  const {
    data: tickets,
    isLoading,
    isError,
  } = useQuery({
    queryFn: async () => (await getAllTickets()).data,
    queryKey: ["tickets"],
  });

  return (
    <>
      <h1>Tickets</h1>
      <table className="table table-hover table-bordered border-secondary">
        <thead>
          <tr>
            <th scope="col">Lvl</th>
            <th scope="col">#</th>
            <th scope="col">Title</th>
            <th scope="col">Module</th>
            <th scope="col">Type</th>
            <th scope="col">State</th>
          </tr>
        </thead>
        <tbody>
          {tickets?.map((ticket: Ticket) => {
            return (
              <tr>
                <th scope="row">{ticket.priorityId}</th>
                <td>{ticket.id}</td>
                <td>{ticket.title}</td>
                <td>{ticket.applicationName}</td>
                <td>{ticket.ticketTypeId}</td>
                <td>{ticket.statusId}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
      <nav aria-label="Page navigation example">
        <ul className="pagination">
          <li className="page-item">
            <a className="page-link" href="#" aria-label="Previous">
              <span aria-hidden="true">&laquo;</span>
            </a>
          </li>
          <li className="page-item">
            <a className="page-link" href="#">
              1
            </a>
          </li>
          <li className="page-item">
            <a className="page-link" href="#">
              2
            </a>
          </li>
          <li className="page-item">
            <a className="page-link" href="#">
              3
            </a>
          </li>
          <li className="page-item">
            <a className="page-link" href="#" aria-label="Next">
              <span aria-hidden="true">&raquo;</span>
            </a>
          </li>
        </ul>
      </nav>
    </>
  );
}
