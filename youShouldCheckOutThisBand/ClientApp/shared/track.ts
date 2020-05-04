//make a track class for type safety

import { Artist } from './artist';

export interface Track {
    
    album: [];
    artists: Artist[];
        sumOfVotes: number;
        href: string;
        previewUrl?: string;
        uri: string;
        name: string;
        upVotes: number;
        downVotes: number;
    
}
