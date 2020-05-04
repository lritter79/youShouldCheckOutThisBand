import { Track } from './track';
import { Image } from './image';

export interface Artist {
    albums: any[];
    tracks: Track[];
    images: Image[];
    genres: any[];
    type: string;
    href: string;
    name: string;
    uri: string;
}