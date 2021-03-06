﻿//support using http client to make api requests
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";
                        //reactive extension for ng
import { Observable } from "rxjs"
import { Track } from '../../shared/track';
import { Artist } from '../artist';

//we have to decorate to tell the dependency injection serivce that it's part of the chain of injection
//this part is for if it requires other dependencies
@Injectable()
export class DataService {

    
    constructor(private http: HttpClient) {

    }
                 //add interface for type safety
    public tracks: Track[] = [];
    public artists: Artist[] = [];
    public votes: number

    loadTracks(): Observable<boolean> {
        //use http to get our api
        return this.http.get("/api/Tracks")
            // subscribe() says when this is done i want to know the response
            // and kicks of the beginning of this request
            //.subscribe()
            //what we want to do is intercept the call and change the data
            .pipe(
                //this way we call subscribe by the client
                map((data: any[]) => {
                    this.tracks = data;
                    //return true to say it did what we wanted it to do
                    return true
                }));
        //this should allow us to assign the tracks tp the track list
    }

    loadArtists(): Observable<boolean> {
        //use http to get our api
        return this.http.get("/api/Artists")
            // subscribe() says when this is done i want to know the response
            // and kicks of the beginning of this request
            //.subscribe()
            //what we want to do is intercept the call and change the data
            .pipe(
                //this way we call subscribe by the client
                map((data: any[]) => {
                    this.artists = data;
                    //return true to say it did what we wanted it to do
                    return true
                }));
        //this should allow us to assign the tracks tp the track list
    }

    getNewVoteTotal(voteStatus: boolean, uri: string): Observable<boolean> {
        return this.http.post<number>("api/Tracks/Vote", {
            vote: voteStatus,
            trackUri: uri
        }).pipe(
            map((data: number) => {
                this.votes = data;
                    return true;
            }));
    }  
}