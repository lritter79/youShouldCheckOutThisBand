import { Component, OnInit } from '@angular/core';
import { DataService } from '../../shared/data/dataService';




@Component({
    selector: "tracks",
    templateUrl: "./tracks.component.html",
    styleUrls: []
})
                      //interface that says once you're ready, call a method
export class TrackList implements OnInit {
    //private makes private member of the class
    //injects it into track list
    constructor(private data: DataService) {
        this.tracks = data.tracks;
    }

    public tracks = [];

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
}