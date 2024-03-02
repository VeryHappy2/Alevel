import { IResource } from "./resource"

export interface IPageResource {
    page: number
    per_page: number
    total: number
    total_page: number
    data: IResource[]
}