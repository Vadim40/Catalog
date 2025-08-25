export interface Image {
    id: number;
    url: string;
    isMain: boolean;
    publicId: number;
}


export const IMAGES: Image[] = [
  { id: 1, url: 'https://picsum.photos/200/300', isMain: true, publicId: 101 },
  { id: 2, url: 'https://picsum.photos/300/200', isMain: false, publicId: 102 },
  { id: 3, url: 'https://picsum.photos/300/200', isMain: false, publicId: 103 },
  { id: 4, url: 'https://picsum.photos/300/200', isMain: false, publicId: 104 }
];
