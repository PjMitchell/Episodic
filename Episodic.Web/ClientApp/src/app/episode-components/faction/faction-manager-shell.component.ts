import { Component } from '@angular/core';
import { FactionComponentStore } from './faction-component.store';

@Component({
    templateUrl: './faction-manager-shell.component.html',
    providers: [FactionComponentStore]
  })
export class FactionManagerShellComponent {
}
