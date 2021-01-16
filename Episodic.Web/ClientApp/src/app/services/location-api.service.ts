import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ComponentApiService } from './component-api.service';
import { Location } from '../models/episode';




@Injectable({
    providedIn: 'root'
})
export class LocationApiService extends ComponentApiService<Location> {
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl, 'api/Location');
    }
}
