import { Component } from '@angular/core';
import { MacGuffinComponentStore } from './macguffin-component.store';
@Component({
    templateUrl: './macguffin-manager-shell.component.html',
    providers: [MacGuffinComponentStore]
  })
export class MacGuffinManagerShellComponent {
}
