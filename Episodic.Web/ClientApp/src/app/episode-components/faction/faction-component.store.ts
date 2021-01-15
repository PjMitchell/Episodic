import { Injectable } from '@angular/core';
import { Faction } from 'src/app/models/episode';
import { FactionApiService } from 'src/app/services/faction-api.service';
import { EpisodeComponentStore } from '../episode-component.store';

@Injectable()
export class FactionComponentStore extends EpisodeComponentStore<Faction> {
    constructor(apiService: FactionApiService) {
        super(apiService);
    }

    createEmptyComponent(id: string): Faction {
        return {
            id,
            name: '',
            description: '',
            boss: {
                name: '',
                description: ''
            }
        };
    }
}
