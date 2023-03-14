export interface FeedbackRequest{
    id: string;
    text: string;
    rate: number;
    isApproved: boolean;
    company: any;
    fromUser: any;
}
