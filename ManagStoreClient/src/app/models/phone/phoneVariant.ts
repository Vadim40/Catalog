import Decimal from "decimal.js";
import { ApiImage } from "../image";
import { PhoneSpec } from "./phoneSpec";

export interface PhoneVariant {
    id: number;
    modelId: number;
    colorId: number;
    name: string;
    images : ApiImage [];
    specs : PhoneSpec [];
    cost: Decimal;
}