import Decimal from 'decimal.js';
import { ApiImage } from 'src/app/models/image'
import { Color } from '../color';
import { PhoneModel } from './phoneModel';
import { PhoneSpec } from './phoneSpec';
export interface PhoneVariant {
    id: number;
    color: Color | null;
    cost: Decimal;
    apiImages?: ApiImage [];
    images?: FileList
    model: PhoneModel | null;
    spec: PhoneSpec | null;
}