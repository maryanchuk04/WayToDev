import {User} from "../models/user";
import {Company} from "../../models/company";

export interface ProfileInterface{
  user: User | null,
  company: Company | null
}
