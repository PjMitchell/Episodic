import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Episode } from '../models/episode';

@Injectable({
    providedIn: 'root'
})
export class EpisodeProvider {
    constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) {}

    getAdventure$() {
    return this.http.post<Episode>(this.baseUrl + 'api/episode', {});
    }
}



