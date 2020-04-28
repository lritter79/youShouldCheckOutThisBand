import { Track } from './track';

export interface Artist {
    albums: any[];
    tracks: Track[];
    images: any[];
    genres: any[];
    type: string;
    href: string;
    name: string;
    uri: string;
}