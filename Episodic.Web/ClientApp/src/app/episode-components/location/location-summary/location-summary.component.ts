import { Component } from '@angular/core';
import { Location } from 'src/app/models/episode';
import { LocationApiService } from 'src/app/services/location-api.service';
import { BaseSummaryComponent } from '../../common/base-component-summary/base-component-summary.component';
import { LocationComponentStore } from '../location-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class LocationSummaryComponent extends BaseSummaryComponent<Location> {
  constructor(store: LocationComponentStore, apiService: LocationApiService) {
    super('/location', store, apiService);
  }
}
