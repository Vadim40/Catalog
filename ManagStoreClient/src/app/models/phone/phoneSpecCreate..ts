import Decimal from "decimal.js";

export interface PhoneSpecCreate {
    storageGb: number;
    ramGb: number;
    displayIn: Decimal
    cameraMp: number
}