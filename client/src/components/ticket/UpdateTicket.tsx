import { useNavigate, useParams } from "react-router-dom";
import { getTicketById, updateTicket } from "../../services/TicketService";
import { useCallback, useEffect, useRef, useState } from "react";
import { createReply, getAllReplies } from "../../services/ReplyService";
import { Ticket } from "../../interfaces/Ticket";
import { Reply } from "../../interfaces/Reply";
import {
  useInfiniteQuery,
  useMutation,
  useQuery,
  useQueryClient,
} from "@tanstack/react-query";

export default function UpdateTicket() {
  const moduleOptions = [
    { id: 1, name: "Loader" },
    { id: 2, name: "Finance" },
    { id: 3, name: "HR" },
    { id: 4, name: "Ingress" },
    { id: 5, name: "Clusters" },
  ];

  const { id } = useParams();
  const ticketId = Number(id);
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const [newReply, setNewReply] = useState("");

  const {
    data: ticket,
    isLoading,
    isError,
  } = useQuery({
    queryKey: ["ticket", ticketId],
    queryFn: async () => (await getTicketById(ticketId)).data as Ticket,
    enabled: !isNaN(ticketId),
    retry: false,
  });

  const {
    data: repliesData,
    fetchNextPage,
    hasNextPage,
    isFetchingNextPage,
  } = useInfiniteQuery({
    queryKey: ["replies", ticketId],
    queryFn: async ({ pageParam = 1 }) => {
      const response = await getAllReplies(pageParam, 5, ticketId);
      return response.data as Reply[];
    },
    initialPageParam: 1,
    getNextPageParam: (lastPage, allPages) => {
      return lastPage.length > 0 ? allPages.length + 1 : undefined;
    },
    enabled: !isNaN(ticketId),
  });

  const observerRef = useRef<HTMLDivElement>(null);
  const loadMoreReplies = useCallback(
    (node) => {
      if (isFetchingNextPage || !hasNextPage) return;
      if (observerRef.current) observerRef.current.disconnect();

      observerRef.current = new IntersectionObserver((entries) => {
        if (entries[0].isIntersecting) {
          fetchNextPage();
        }
      });

      if (node) observerRef.current.observe(node);
    },
    [isFetchingNextPage, hasNextPage]
  );

  const replies = repliesData?.pages.flat() || [];

  useEffect(() => {
    if (ticket) {
      setSelectedModule({
        id: ticket.applicationId,
        name: ticket.applicationName,
      });
      setSelectedPriority(ticket.priorityId);
      setSelectedType(ticket.ticketTypeId);
      setSelectedState(ticket.statusId);
      setDescription(ticket.description || ""); // Ensure non-null description
    }
  }, [ticket]);

  // Set initial module values based on `applicationId`
  const initialModule =
    moduleOptions.find((m) => m.id === ticket?.applicationId) ||
    moduleOptions[0];

  // Editable state for dropdowns
  const [selectedModule, setSelectedModule] = useState({
    id: initialModule.id,
    name: initialModule.name,
  });
  const [selectedPriority, setSelectedPriority] = useState(
    ticket?.priorityId || 5
  );
  const [selectedType, setSelectedType] = useState(ticket?.ticketTypeId || 1);
  const [selectedState, setSelectedState] = useState(ticket?.statusId || 1);
  const [description, setDescription] = useState(ticket?.description || "");

  // Mutations for API calls
  const updateTicketMutation = useMutation({
    mutationFn: updateTicket,
    onSuccess: () => {
      queryClient.invalidateQueries(["ticket", ticketId]);
    },
  });

  const createReplyMutation = useMutation({
    mutationFn: createReply,
    onSuccess: () => {
      queryClient.invalidateQueries(["replies", ticketId]);
      setNewReply(""); // Clear reply input after submission
    },
  });
  // Handle Save Click
  const handleSave = async () => {
    const isTicketModified =
      ticket?.applicationId !== selectedModule.id ||
      ticket?.applicationName !== selectedModule.name ||
      ticket?.priorityId !== selectedPriority ||
      ticket?.ticketTypeId !== selectedType ||
      ticket?.statusId !== selectedState ||
      ticket?.description !== description;

    try {
      if (isTicketModified) {
        const updatedTicket: Ticket = {
          ...ticket, // Pass all properties, even unchanged ones
          applicationId: selectedModule.id,
          applicationName: selectedModule.name,
          priorityId: selectedPriority,
          ticketTypeId: selectedType,
          statusId: selectedState,
          description: description,
          lastModified: new Date(),
          deleted: ticket?.deleted ?? false, // Always update lastModified timestamp
        };

        console.log(
          "🔹 Sending to backend:",
          JSON.stringify(updatedTicket, null, 2)
        );
        await updateTicketMutation.mutateAsync(updatedTicket);
        console.log("Ticket updated successfully");
      }

      if (newReply.trim() !== "") {
        await createReplyMutation.mutateAsync({
          replyId: 1,
          ticketId: ticketId,
          reply: newReply,
          replyDate: new Date(),
        });
        console.log("Reply added successfully");
        setNewReply(""); // Clear reply field after submission
      }
    } catch (error) {
      console.error("Error saving data:", error);
    }
  };

  if (isLoading) return <p className="text-center mt-4">Loading ticket...</p>;
  if (isError)
    return <p className="text-danger text-center">Error loading ticket</p>;
  if (!ticket)
    return (
      <p className="text-danger text-center">
        Ticket with ID {ticketId} not found
      </p>
    );

  return (
    <div className="container mt-4">
      {/* Header */}
      <div className="d-flex justify-content-between align-items-center">
        <h5>
          Ticket # {ticket.id} - {ticket.title}
        </h5>
        <div>
          <button
            className="btn btn-secondary me-2"
            onClick={() => navigate("/")}
          >
            Close
          </button>
          <button className="btn btn-success" onClick={handleSave}>
            Save
          </button>
        </div>
      </div>

      {/* New Reply Section */}
      <div className="mt-3">
        <label className="fw-bold">New Reply</label>
        <div className="p-2 bg-warning-subtle rounded">
          <textarea
            className="form-control border-0 bg-transparent"
            rows={2}
            placeholder="Type your reply here..."
            value={newReply}
            onChange={(e) => setNewReply(e.target.value)}
          />
        </div>
      </div>

      <div className="row mt-4">
        {/* Left Side: Ticket Details */}
        <div className="col-md-6">
          {/* Module Dropdown */}
          <div className="mb-3">
            <label className="fw-bold">Module</label>
            <select
              className="form-select"
              value={selectedModule.id}
              onChange={(e) => {
                const selected = moduleOptions.find(
                  (m) => m.id === Number(e.target.value)
                );
                if (selected) setSelectedModule(selected);
              }}
            >
              {moduleOptions.map((mod) => (
                <option key={mod.id} value={mod.id}>
                  {mod.name}
                </option>
              ))}
            </select>
          </div>

          {/* Urgent Level Dropdown */}
          <div className="mb-3">
            <label className="fw-bold">Urgent Level</label>
            <select
              className="form-select"
              value={selectedPriority}
              onChange={(e) => setSelectedPriority(Number(e.target.value))}
            >
              <option value={5}>None</option>
              <option value={4}>Priority</option>
              <option value={3}>High</option>
              <option value={2}>Medium</option>
              <option value={1}>Low</option>
            </select>
          </div>

          {/* Type Dropdown */}
          <div className="mb-3">
            <label className="fw-bold">Type</label>
            <select
              className="form-select"
              value={selectedType}
              onChange={(e) => setSelectedType(Number(e.target.value))}
            >
              <option value={1}>Question</option>
              <option value={2}>Issue</option>
              <option value={3}>Suggestion</option>
              <option value={4}>Feedback</option>
            </select>
          </div>

          {/* State Dropdown */}
          <div className="mb-3">
            <label className="fw-bold">State</label>
            <select
              className="form-select"
              value={selectedState}
              onChange={(e) => setSelectedState(Number(e.target.value))}
            >
              <option value={1}>New</option>
              <option value={2}>Open</option>
              <option value={3}>Awaiting Response - User</option>
              <option value={4}>Awaiting Response - Development</option>
              <option value={5}>Awaiting Response - Vendor</option>
              <option value={6}>Closed</option>
            </select>
          </div>
          {/* Editable Description */}
          <div className="mb-3">
            <label className="fw-bold">Description</label>
            <textarea
              className="form-control"
              rows={4}
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </div>
        </div>

        {/* Right Side: Replies Section */}
        <div className="col-md-6">
          <label className="fw-bold">Replies</label>
          <div
            className="border rounded p-2"
            style={{ height: "250px", overflowY: "auto" }}
          >
            {replies.map((reply: Reply, index: number) => (
              <div key={index} className="p-2 bg-light rounded mb-2">
                {reply.reply}
              </div>
            ))}
            {/* Infinite Scroll Trigger */}
            <div ref={loadMoreReplies} />
            {isFetchingNextPage && (
              <p className="text-center mt-2">Loading more replies...</p>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
