import { Component } from '@angular/core';
import { EpisodeTemplateComponentStore } from './episode-template-component.store';

@Component({
    templateUrl: './episode-template-manager-shell.component.html',
    providers: [EpisodeTemplateComponentStore]
  })
export class EpisodeTemplateManagerShellComponent {
}
