import Decimal from "decimal.js";

export interface CreatePhoneSpec {
    storageGb: number;
    ramGb: number;
    displayIn: Decimal
    cameraMp: number
}