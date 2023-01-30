import { PaginationResponseModel } from "../models/paginationResponseModel";
import { News } from "../news/models/news";

export const mockOneNews: News = {
    id: "1",
    title: "Mock news title",
    shortDescription: "Mock short description",
    text: "Txt news",
    date: "27.01.2023",
    image: "news-image"
}

export const mockNewsArray: News[] = [
    mockOneNews, 
    { ...mockOneNews, id: "2" }, 
    { ...mockOneNews, id: "3" },
    { ...mockOneNews, id: "4" },
]

export const mockPaginationNewsArray: PaginationResponseModel<News[]> = {
    items: [...mockNewsArray],
    pageViewModel: {
        pageNumber: 1,
        totalPages: 1,
        hasPreviousPage: "false",
        hasNewsPage: 10,
        totalItemsCount: mockNewsArray.length
    }
}