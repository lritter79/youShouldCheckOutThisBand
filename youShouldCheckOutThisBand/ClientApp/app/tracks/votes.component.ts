import { Component, OnInit } from '@angular/core';
import { DataService } from '../../shared/data/dataService';
//import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
//import { Track } from '../../shared/track';
//import { Artist } from '../../shared/artist';


@Component({
    selector: "votes",
    templateUrl: "votes.component.html",
    styleUrls: ["votes.component.scss"]
})

export class Votes implements OnInit {

    constructor(private data: DataService) {
        
    }


    public upVotes: number = 0;
    public downVotes: number = 0;


    ngOnInit(): void {
        
    }

}