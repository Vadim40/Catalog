import Decimal from "decimal.js"

export interface PhoneVariantCreate {
    modelId : number
    specId: number
    colorId: number
    cost: Decimal
    
}