import { EntityId } from "./entity-id.model";

export interface AuditableEntity extends EntityId {
    createdBy: number
    modifiedBy: number
}