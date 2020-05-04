import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../shared/data/dataService';



@Component({
    selector: "votes",
    templateUrl: "votes.component.html",
    styleUrls: ["votes.component.scss"]
})

export class Votes implements OnInit {

    constructor(private data: DataService) {
        
    }

    public upClicked: boolean;
    public downClicked: boolean;

    @Input() public upVotes: number;
    @Input() public downVotes: number;
    @Input() public uri: string;
    @Output() public voteEvent = new EventEmitter<number>();


    ngOnInit(): void {
        this.voteEvent.emit(this.upVotes - this.downVotes);
        this.upClicked = false;
        this.downClicked = false
    }

    subtractVotes(uri:string): void {
        this.downVotes += 1;
        if (this.upClicked) {
            this.upVotes--;
        }
        this.changeVotesInRepo(false, uri);
        this.voteEvent.emit(this.upVotes - this.downVotes);
        //return downVotes;
    }

    addVotes(uri: string): void {
        this.upVotes += 1;
        if (this.downClicked) {
            this.downVotes--;
        }
        this.changeVotesInRepo(true, uri)
        this.voteEvent.emit(this.upVotes - this.downVotes);

    }

    changeVotesInRepo(vote: boolean, trackUri: string): void {

        let newTotal = this.data.getNewVoteTotal(vote, trackUri)
            .subscribe(success => {
                if (success) {
                    return this.data.votes;
                }
            });

        
    }

}