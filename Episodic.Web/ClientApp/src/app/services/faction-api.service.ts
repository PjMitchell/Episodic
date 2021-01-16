import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Faction } from '../models/episode';
import { ComponentApiService } from './component-api.service';

@Injectable({
    providedIn: 'root'
})
export class FactionApiService extends ComponentApiService<Faction> {
    constructor(http: HttpClient, @Inject('BASE_URL')baseUrl: string) {
        super(http, baseUrl, 'api/Faction');
    }
}




