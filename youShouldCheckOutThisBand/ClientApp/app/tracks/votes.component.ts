import { Component, OnInit, Input } from '@angular/core';
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


    @Input() public upVotes: number;
    @Input() public downVotes: number;
    @Input() public uri: string;


    ngOnInit(): void {
        
    }

    subtractVotes(): void {
        this.downVotes -= 1;

        //return downVotes;
    }

    addVotes(): void {
        this.upVotes += 1;

        //return downVotes;
    }

}