import { Motorcycle } from "../../entities/motorcycle.model";

export interface MotorcycleTypes {
    name: string,
    imagePath: string,
    motorcycles: Motorcycle[]
}