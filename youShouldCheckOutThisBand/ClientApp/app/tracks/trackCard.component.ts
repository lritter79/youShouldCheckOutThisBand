import { Component, OnInit, Input } from '@angular/core';
//import track interface so we can use it
import { Track } from '../../shared/track';
import { Artist } from '../../shared/artist';
import * as _ from "lodash";

@Component({
    selector: "track-card",
    templateUrl: "./trackCard.component.html",
    styleUrls: ["./trackCard.component.scss"]
})
//interface that says once you're ready, call a method
export class TrackCard implements OnInit {
    //private makes private member of the class
    //injects it into track list
    constructor() {
        
    }


    @Input() public track: Track;

    public totalVotes: number
    public artists: string

    ngOnInit(): void {
        this.totalVotes = this.track.sumOfVotes;
        this.getColor(this.totalVotes);
        this.artists = this.getArtistName(this.track);
    }

    getVoteTotal($event) {
        this.totalVotes = $event;
    }


    getColor(totalVotes: number): string {
        if (totalVotes > 0) {
            return "blue";
        }
        else if (totalVotes < 0) {
            return "red";
        }
    }

    getArtistName(tr: Track): string {
        let returnString = "";

        if (tr.artists.length > 1) {
            tr.artists.forEach(function (artist: Artist) {
                if (artist.uri == tr.artists[tr.artists.length - 2].uri) {
                    returnString += artist.name + ", and ";
                }
                else if (artist.uri == tr.artists[tr.artists.length - 1].uri) {
                    returnString += artist.name;
                }
                else {
                    returnString += artist.name + ", ";
                }
            });
        }
        else {
            returnString = tr.artists[0].name;
        }

        return returnString;
    } 
    //
    //    

    //    if (this.track.artists.length > 1) {




    //    return returnString;
    //}
}