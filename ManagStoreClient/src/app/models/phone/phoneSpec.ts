export interface PhoneSpec {
    id: number;
    storageGb: number;
    ramGb: number;
    displayIn: number;
    cameraMp: number
}
export const phoneSpecs: PhoneSpec[] = [
    {
      id: 1,
      storageGb: 64,
      ramGb: 4,
      displayIn: 6.0,
      cameraMp: 12
    },
    {
      id: 2,
      storageGb: 128,
      ramGb: 6,
      displayIn: 6.4,
      cameraMp: 48
    },
    {
      id: 3,
      storageGb: 256,
      ramGb: 8,
      displayIn: 6.7,
      cameraMp: 108
    }
]