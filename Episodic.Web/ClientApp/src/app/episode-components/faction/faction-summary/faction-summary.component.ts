import { Component } from '@angular/core';
import { Faction } from 'src/app/models/episode';
import { FactionApiService } from 'src/app/services/faction-api.service';
import { BaseSummaryComponent } from '../../common/base-component-summary/base-component-summary.component';
import { FactionComponentStore } from '../faction-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class FactionSummaryComponent extends BaseSummaryComponent<Faction> {
  constructor(store: FactionComponentStore, apiService: FactionApiService) {
    super('/faction', store, apiService);
  }
}
