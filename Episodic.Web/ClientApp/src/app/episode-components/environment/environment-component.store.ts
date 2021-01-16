import { Injectable } from '@angular/core';
import { Environment } from 'src/app/models/episode';
import { EnvironmentApiService } from 'src/app/services/environment-api.service';
import { EpisodeComponentStore } from '../episode-component.store';

@Injectable()
export class EnvironmentComponentStore extends EpisodeComponentStore<Environment> {
    constructor(apiService: EnvironmentApiService) {
        super(apiService);
    }

    createEmptyComponent(id: string): Environment {
        return {
            id,
            name: '',
            description: ''
        };
    }
}
