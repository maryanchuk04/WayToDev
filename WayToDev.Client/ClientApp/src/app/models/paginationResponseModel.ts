import {PageResponseViewModel} from "./pageResponseViewModel";

export interface PaginationResponseModel<T>{
  items: T
  pageViewModel: PageResponseViewModel
}
