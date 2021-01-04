import { Component } from '@angular/core';
import { MacGuffin } from 'src/app/models/episode';
import { EpisodeTemplateApiService } from 'src/app/services/episode-template-api.service';
import { BaseSummaryComponent } from '../../common/base-component-summary/base-component-summary.component';
import { EpisodeTemplateComponentStore } from '../episode-template-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class EpisodeTemplateSummaryComponent extends BaseSummaryComponent<MacGuffin> {
  constructor(store: EpisodeTemplateComponentStore, apiService: EpisodeTemplateApiService) {
    super('/episodeTemplate', store, apiService);
  }
}
