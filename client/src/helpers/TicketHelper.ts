export const getPriorityBadge = (priorityId: number) => {
  switch (priorityId) {
    case 5:
      return "bg-white"; // Red for high priority
    case 4:
      return "bg-danger"; // Red for high priority
    case 3:
      return "bg-warning"; // Yellow for medium priority
    case 2:
      return "bg-info"; // Green for low priority
    case 1:
      return "bg-success"; // Green for low priority
    default:
      return "bg-primary"; // Default blue
  }
};

export const getTypeText = (ticketTypeId: number) => {
  switch (ticketTypeId) {
    case 1:
      return "Question"; // Red for high priority
    case 2:
      return "Issue"; // Red for high priority
    case 3:
      return "Suggestion"; // Yellow for medium priority
    case 4:
      return "Feedback"; // Green for low priority // Green for low priority
    default:
      return "Unknown Type"; // Default blue
  }
};

export const getStateText = (statusId: number) => {
  switch (statusId) {
    case 1:
      return "New"; // Red for high priority
    case 2:
      return "Open"; // Red for high priority
    case 3:
      return "Awaiting Response - User"; // Yellow for medium priority
    case 4:
      return "Awaiting Response - Development"; // Green for low priority // Green for low priority
    case 5:
      return "Awaiting Response - Vendor";
    case 6:
      return "Closed";
    default:
      return "Unknown State"; // Default blue
  }
};
