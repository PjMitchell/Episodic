import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EpisodeTemplate } from '../models/episode';
import { ComponentApiService } from './component-api.service';


@Injectable({
    providedIn: 'root'
})
export class EpisodeTemplateApiService extends ComponentApiService<EpisodeTemplate> {
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl, 'api/EpisodeTemplate');
    }
}
