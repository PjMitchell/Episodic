import { Type } from '@angular/core';
import { Route, Routes } from '@angular/router';
import { EpisodeTemplateEditorComponent } from './episode-components/episode-template/episode-template-editor/episode-template-editor.component';
import { EpisodeTemplateManagerShellComponent } from './episode-components/episode-template/episode-template-manager-shell.component';
import { EpisodeTemplateSummaryComponent } from './episode-components/episode-template/episode-template-summary/episode-template-summary.component';
import { MacGuffinEditorComponent } from './episode-components/macguffin/macguffin-editor/macguffin-editor.component';
import { MacGuffinManagerShellComponent } from './episode-components/macguffin/macguffin-manager-shell.component';
import { MacGuffinSummaryComponent } from './episode-components/macguffin/macguffin-summary/macguffin-summary.component';
import { EpisodeShellComponent } from './episode/episode-shell.component';
import { HomeComponent } from './home/home.component';

export function buildRoutes(): Routes {
    return [
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'episode', component: EpisodeShellComponent },
        buildManagerRoute('macGuffin',
          MacGuffinManagerShellComponent,
          MacGuffinSummaryComponent,
          MacGuffinEditorComponent),
        buildManagerRoute('episodeTemplate',
          EpisodeTemplateManagerShellComponent,
          EpisodeTemplateSummaryComponent,
          EpisodeTemplateEditorComponent)
      ];
}

export function buildManagerRoute(route: string, shell: Type<any>, summary: Type<any>, edit: Type<any>): Route {
  return { path: route, component: shell, children: [
    { path: '', component: summary, pathMatch: 'full'},
    { path: 'edit/:id', component: edit },
    { path: 'create', component: edit }
  ]};
}
