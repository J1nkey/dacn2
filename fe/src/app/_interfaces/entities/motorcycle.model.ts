import { AuditableEntity } from "../commons/auditable-entity.model";

export interface Motorcycle extends AuditableEntity {
    Name: string
    Description: string
    CubicCentimeters: number
    Torque: number
    HorsePower: number
    ImagePath: string
    ManufacturerId: number
    MotorcycleTypeId: number 
}