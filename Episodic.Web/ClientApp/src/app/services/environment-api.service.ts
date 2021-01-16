import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Environment } from '../models/episode';
import { ComponentApiService } from './component-api.service';


@Injectable({
    providedIn: 'root'
})
export class EnvironmentApiService extends ComponentApiService<Environment> {
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl, 'api/Environment');
    }
}
