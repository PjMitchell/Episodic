import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MacGuffin } from '../models/episode';
import { ComponentApiService } from './component-api.service';

@Injectable({
    providedIn: 'root'
})
export class MacGuffinApiService extends ComponentApiService<MacGuffin> {
    constructor(http: HttpClient, @Inject('BASE_URL')baseUrl: string) {
        super(http, baseUrl, 'api/MacGuffin');
    }
}
