import Decimal from 'decimal.js';
import { Image } from 'src/app/models/image'
export interface PhoneVariant {
    id: number;
    modelId: number;
    specId: number;
    colorId: number;
    cost: Decimal;
    images: Image [];
}