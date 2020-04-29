import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
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
    @Output() public newTotal = new EventEmitter();


    ngOnInit(): void {
        this.newTotal.emit(this.upVotes - this.downVotes);
    }

    subtractVotes(uri:string): void {
        this.downVotes += 1;
        this.changeVotesInRepo(false, uri);
        this.newTotal.emit(this.changeVotesInRepo(true, uri));
        //return downVotes;
    }

    addVotes(uri: string): void {
        this.upVotes += 1;
        this.newTotal.emit(this.changeVotesInRepo(true, uri));

    }

    changeVotesInRepo(vote: boolean, trackUri: string): void {

        let newTotal = this.data.getNewVoteTotal(vote, trackUri)
            .subscribe(success => {
                if (success) {
                    console.log(this.data.votes);
                    return this.data.votes;
                }
            });

        
    }

}