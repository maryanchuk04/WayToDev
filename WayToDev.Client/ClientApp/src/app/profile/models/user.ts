import {Gender} from "./gender";
import {TechItem} from "../../models/techItem";

export interface User{
  firstName: string
  lastName: string
  userName: string
  birthday: string
  gender: Gender | null
  imageUrl: string
  tags: Array<TechItem>
  email: string
}
