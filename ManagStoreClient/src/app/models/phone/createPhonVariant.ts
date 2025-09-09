import Decimal from "decimal.js"

export interface CreatePhoneVariant {
    modelId : number
    specId: number
    colorId: number
    cost: Decimal
    
}