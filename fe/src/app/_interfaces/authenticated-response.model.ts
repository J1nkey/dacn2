export interface AuthenticatedResponse {
    isSuccess: boolean;
    tokenAuth: string;
    userId: number;
    userName: string;
    fullName: string;
}