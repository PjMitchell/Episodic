import { Component } from '@angular/core';
import { MacGuffin } from 'src/app/models/episode';
import { EpisodeTemplateApiService } from 'src/app/services/episode-template-api.service';
import { BaseSummaryComponentDirective } from '../../common/base-component-summary/base-component-summary.component';
import { EpisodeTemplateComponentStore } from '../episode-template-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class EpisodeTemplateSummaryComponent extends BaseSummaryComponentDirective<MacGuffin> {
  constructor(store: EpisodeTemplateComponentStore, apiService: EpisodeTemplateApiService) {
    super('/episodeTemplate', store, apiService);
  }
}
