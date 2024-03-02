import { IUser } from "./user";

export interface IPageUser {
    page: number
    per_page: number
    total: number
    total_page: number
    data: IUser[] 
}
