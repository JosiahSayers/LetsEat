import { Invite } from './invite.model';

export interface User {
  id: number;
  displayName: string;
  email: string;
  isAdmin: boolean;
  role: string;
  familyId: number;
  familyRole: string;
  invite: Invite;
  inviteRequest: boolean;
}