import { Component } from '@angular/core';
import { LocationComponentStore } from './location-component.store';

@Component({
    templateUrl: './location-manager-shell.component.html',
    providers: [LocationComponentStore]
  })
export class LocationManagerShellComponent {
}
