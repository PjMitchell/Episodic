import { Component } from '@angular/core';
import { MacGuffin } from 'src/app/models/episode';
import { MacGuffinApiService } from 'src/app/services/macguffin-api.service';
import { BaseSummaryComponent } from '../../common/base-component-summary/base-component-summary.component';
import { MacGuffinComponentStore } from '../macguffin-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class MacGuffinSummaryComponent extends BaseSummaryComponent<MacGuffin> {
  constructor(store: MacGuffinComponentStore, apiService: MacGuffinApiService) {
    super('/macGuffin', store, apiService);
  }
}
