import { Injectable } from '@angular/core';
import { Location } from 'src/app/models/episode';
import { LocationApiService } from 'src/app/services/location-api.service';
import { EpisodeComponentStore } from '../episode-component.store';

@Injectable()
export class LocationComponentStore extends EpisodeComponentStore<Location> {
    constructor(apiService: LocationApiService) {
        super(apiService);
    }

    createEmptyComponent(id: string): Location {
        return {
            id,
            name: '',
            description: ''
        };
    }
}
