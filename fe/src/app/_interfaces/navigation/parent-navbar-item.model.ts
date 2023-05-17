import { BaseNavbarItem } from "./base-navbar-item.model";

export interface ParentNavbarItem {
    id: number,
    name: string,
    url: string
    subItems: BaseNavbarItem[]
}