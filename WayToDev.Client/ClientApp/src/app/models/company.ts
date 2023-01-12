import {Feedback} from "./feedback";
import {Tag} from "./tag";

export interface Company{
  id: string;
  companyName: string;
  imageUrl: string;
  description: string;
  email: string;
  tags: Tag[];
  feedbacks: Feedback[];
}
