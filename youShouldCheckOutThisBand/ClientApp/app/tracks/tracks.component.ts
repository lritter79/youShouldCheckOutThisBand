import { Component, OnInit } from '@angular/core';
import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
import { Track } from '../../shared/track';
import { Artist } from '../../shared/artist';
import { Votes } from './votes.component';
import * as _ from "lodash";

@Component({
    selector: "tracks",
    templateUrl: "./tracks.component.html",
    styleUrls: ["./tracks.component.css"]
})
                      //interface that says once you're ready, call a method
export class TrackList implements OnInit {
    //private makes private member of the class
    //injects it into track list
    constructor(private data: DataService) {
        this.tracks = data.tracks;
        
    }

                   //make sure that an array of tracks is getting returned
    public tracks: Track[] = [];
    //public totalVotes: number;

    ngOnInit(): void {
        //once the load products happens, we want to get the data that's being passed back in
        this.data.loadTracks()
            //calls success because the shared component returns a bool
            .subscribe(success => {
                if (success) {
                    this.tracks = this.data.tracks;
                }
            });
    }

    getColor(totalVotes: number): string {
        if (totalVotes > 0) {
            return "blue;"
        }
        else if (totalVotes < 0) {
            return "red"
        }
    }

    getArtistNames(track: Track): string {
        let returnString = "";

        if (track.artists.length > 1) {
            track.artists.forEach(function (artist: Artist) {


                if (artist.uri == track.artists[track.artists.length - 2].uri) {
                    returnString += artist.name + ", and ";
                }
                else if (artist.uri == track.artists[track.artists.length - 1].uri) {
                    returnString += artist.name;
                }
                else {
                    returnString += artist.name + ", ";
                }

            });
        }
        else {
            returnString = track.artists[0].name;
        }
        

        return returnString;
    }
}