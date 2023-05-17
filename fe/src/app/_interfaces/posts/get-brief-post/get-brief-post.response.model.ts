import { PaginatedList } from "../../paginated-list.model";
import { BriefPostDto } from "./brief-post-dto.model";

export class GetBriefPostResponse {
    response: PaginatedList<BriefPostDto>
}