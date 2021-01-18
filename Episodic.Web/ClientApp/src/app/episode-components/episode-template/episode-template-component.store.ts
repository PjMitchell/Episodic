import { Injectable } from '@angular/core';
import { EpisodeTemplate } from 'src/app/models/episode';
import { EpisodeTemplateApiService } from 'src/app/services/episode-template-api.service';
import { EpisodeComponentStore } from '../episode-component.store';

@Injectable()
export class EpisodeTemplateComponentStore extends EpisodeComponentStore<EpisodeTemplate> {
    constructor(apiService: EpisodeTemplateApiService) {
        super(apiService);
    }

    createEmptyComponent(id: string): EpisodeTemplate {
        return {
            id,
            name: '',
            description: '',
            descriptionTemplate: '',
            requiredComponents: [],
            stages: []
        };
    }
}
