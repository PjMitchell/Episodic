import { Type } from '@angular/core';
import { Route, Routes } from '@angular/router';
import { EnvironmentEditorComponent } from './episode-components/environment/environment-editor/environment-editor.component';
import { EnvironmentManagerShellComponent } from './episode-components/environment/environment-manager-shell.component';
import { EnvironmentSummaryComponent } from './episode-components/environment/environment-summary/environment-summary.component';
import { EpisodeTemplateEditorComponent } from './episode-components/episode-template/episode-template-editor/episode-template-editor.component';
import { EpisodeTemplateManagerShellComponent } from './episode-components/episode-template/episode-template-manager-shell.component';
import { EpisodeTemplateSummaryComponent } from './episode-components/episode-template/episode-template-summary/episode-template-summary.component';
import { FactionEditorComponent } from './episode-components/faction/faction-editor/faction-editor.component';
import { FactionManagerShellComponent } from './episode-components/faction/faction-manager-shell.component';
import { FactionSummaryComponent } from './episode-components/faction/faction-summary/faction-summary.component';
import { LocationEditorComponent } from './episode-components/location/location-editor/location-editor.component';
import { LocationManagerShellComponent } from './episode-components/location/location-manager-shell.component';
import { LocationSummaryComponent } from './episode-components/location/location-summary/location-summary.component';
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
          EpisodeTemplateEditorComponent),
        buildManagerRoute('faction',
          FactionManagerShellComponent,
          FactionSummaryComponent,
          FactionEditorComponent),
        buildManagerRoute('environment',
          EnvironmentManagerShellComponent,
          EnvironmentSummaryComponent,
          EnvironmentEditorComponent),
        buildManagerRoute('location',
          LocationManagerShellComponent,
          LocationSummaryComponent,
          LocationEditorComponent)
      ];
}

export function buildManagerRoute(route: string, shell: Type<any>, summary: Type<any>, edit: Type<any>): Route {
  return { path: route, component: shell, children: [
    { path: '', component: summary, pathMatch: 'full'},
    { path: 'edit/:id', component: edit },
    { path: 'create', component: edit }
  ]};
}
