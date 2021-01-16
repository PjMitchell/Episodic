import { Component } from '@angular/core';
import { EnvironmentComponentStore } from './environment-component.store';

@Component({
    templateUrl: './environment-manager-shell.component.html',
    providers: [EnvironmentComponentStore]
  })
export class EnvironmentManagerShellComponent {
}
