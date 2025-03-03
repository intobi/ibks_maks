//Due to lack of time and not implementing all entities APIs I decided to create such convertors

export const getPriorityBadge = (priorityId: number) => {
  switch (priorityId) {
    case 5:
      return "bg-white";
    case 4:
      return "bg-danger";
    case 3:
      return "bg-warning";
    case 2:
      return "bg-info";
    case 1:
      return "bg-success";
    default:
      return "bg-primary";
  }
};

export const getPriorityText = (priorityId: number) => {
  switch (priorityId) {
    case 5:
      return "None";
    case 4:
      return "Priority";
    case 3:
      return "High";
    case 2:
      return "Medium";
    case 1:
      return "Low";
    default:
      return "Unknown Priority";
  }
};

export const getTypeText = (ticketTypeId: number) => {
  switch (ticketTypeId) {
    case 1:
      return "Question";
    case 2:
      return "Issue";
    case 3:
      return "Suggestion";
    case 4:
      return "Feedback";
    default:
      return "Unknown Type";
  }
};

export const getStateText = (statusId: number) => {
  switch (statusId) {
    case 1:
      return "New";
    case 2:
      return "Open";
    case 3:
      return "Awaiting Response - User";
    case 4:
      return "Awaiting Response - Development";
    case 5:
      return "Awaiting Response - Vendor";
    case 6:
      return "Closed";
    default:
      return "Unknown State";
  }
};

export const getModuleText = (statusId: number) => {
  switch (statusId) {
    case 1:
      return "Loader";
    case 2:
      return "Finance";
    case 3:
      return "HR";
    case 4:
      return "Ingress";
    case 5:
      return "Clusters";
    default:
      return "Unknown Application";
  }
};
