import { Component } from '@angular/core';
import { Environment } from 'src/app/models/episode';
import { EnvironmentApiService } from 'src/app/services/environment-api.service';
import { BaseSummaryComponentDirective } from '../../common/base-component-summary/base-component-summary.component';
import { EnvironmentComponentStore } from '../environment-component.store';

@Component({
    templateUrl: '../../common/base-component-summary/base-component-summary.component.html',
  })
export class EnvironmentSummaryComponent extends BaseSummaryComponentDirective<Environment> {
  constructor(store: EnvironmentComponentStore, apiService: EnvironmentApiService) {
    super('/environment', store, apiService);
  }
}
