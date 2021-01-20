import { Component } from '@angular/core';
import { Location } from 'src/app/models/episode';
import { LocationApiService } from 'src/app/services/location-api.service';
import { BaseSummaryComponentDirective } from '../../common/base-component-summary/base-component-summary.component';
import { LocationComponentStore } from '../location-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class LocationSummaryComponent extends BaseSummaryComponentDirective<Location> {
  constructor(store: LocationComponentStore, apiService: LocationApiService) {
    super('/location', store, apiService);
  }
}
