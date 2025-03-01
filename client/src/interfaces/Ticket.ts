export interface Ticket {
  id: number;
  applicationId: number;
  installedEnvironmentId: number;
  priorityId: number;
  statusId: number;
  ticketTypeId: number;
  userOid: string;

  title: string;
  description: string;
  url: string;
  stackTrace: string;
  device: string;
  browser: string;
  resolution: string;

  applicationName: string;

  userId: number;
  date: Date;
  deleted: boolean;
  lastModified: Date;
  createdByOid: string;
}
