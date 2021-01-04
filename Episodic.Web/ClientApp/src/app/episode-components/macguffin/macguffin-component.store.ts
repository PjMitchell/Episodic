import { Injectable } from '@angular/core';
import { MacGuffin } from 'src/app/models/episode';
import { MacGuffinApiService } from 'src/app/services/macguffin-api.service';
import { EpisodeComponentStore } from '../episode-component.store';

@Injectable()
export class MacGuffinComponentStore extends EpisodeComponentStore<MacGuffin> {
    constructor(apiService: MacGuffinApiService) {
        super(apiService);
    }

    createEmptyComponent(id: string): MacGuffin {
        return {
            id,
            name: '',
            description: ''
        };
    }
}
