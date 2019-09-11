import { User } from './user.model';

export interface Invite {
  id: number;
  invitee: number;
  familyId: number;
  familyName: string;
  invitedBy: User;
}