import { Component, OnInit, Input } from '@angular/core';
import { Track } from '../../shared/track';
import { Artist } from '../../shared/artist';
import * as _ from "lodash";
import { Image } from '../../shared/image';
import { DataService } from '../../shared/data/dataService';

@Component({
    selector: "artists",
    templateUrl: "./artists.component.html",
    styleUrls: ["./artists.component.scss"]
})
export class ArtistList implements OnInit {

    constructor(private data: DataService) {
        //this.artists = data.artists;

    }

    public artists: Artist[] = [];

    ngOnInit(): void {
        this.data.loadArtists()
            //calls success because the shared component returns a bool
            .subscribe(success => {
                if (success) {
                    this.artists = this.data.artists;
                }
            });
    }

    public getImageUrl(a: Artist): string {

        if (a.images.length > 1) {
            if (a.images.find(image => (image.width > 199 && image.width < 401)).url != null) {
                return a.images.find(image => (image.width > 199 && image.width < 401)).url
            }
            else {
                return (a.images.find(image => image.width > 199).url != null) ? a.images.find(image => image.width > 199).url : "";
            }
        }
        else if (a.images.length > 1) {
            return a.images[0].url;
        }
        else {
            return "";
        }
        
    }

}