import { User } from './user.model';

export interface Recipe {
  id: number;
  name: string;
  description: string;
  prepMinutes: number;
  cookMinutes: number;
  prepTime: string;
  cookTime: string;
  totalTimeMinutes: number;
  totalTime: string;
  source: string;
  dateAdded: Date;
  userWhoAdded: User;
  familyId: number;
  ingredients: string[];
  imageLocations: string[];
  steps: string[];
}