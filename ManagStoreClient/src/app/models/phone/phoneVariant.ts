import Decimal from 'decimal.js';
import { ApiImage } from 'src/app/models/image'
import { Color } from '../color';
export interface PhoneVariant {
    id: number;
    modelId: number;
    specId: number;
    color: Color;
    cost: Decimal;
    apiImages?: ApiImage [];
    images?: FileList
}