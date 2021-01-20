import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EpisodeShellComponent } from './episode/episode-shell.component';
import { StoreModule } from '@ngrx/store';
import { AdventureState, buildReducer } from './store/app.store';
import { EffectsModule } from '@ngrx/effects';
import { AppEffects } from './store/app.effects';
import { MacGuffinManagerShellComponent } from './episode-components/macguffin/macguffin-manager-shell.component';
import { ComponentSummaryListComponent } from './episode-components/common/component-summary-list/component-summary-list.component';
import { MacGuffinSummaryComponent } from './episode-components/macguffin/macguffin-summary/macguffin-summary.component';
import { buildRoutes } from './app.route';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MacGuffinEditorComponent } from './episode-components/macguffin/macguffin-editor/macguffin-editor.component';
import { ComponentEditorShellComponent } from './episode-components/common/component-editor/component-editor-shell.component';
import { EpisodeTemplateManagerShellComponent } from './episode-components/episode-template/episode-template-manager-shell.component';
import { EpisodeTemplateEditorComponent } from './episode-components/episode-template/episode-template-editor/episode-template-editor.component';
import { EpisodeTemplateSummaryComponent } from './episode-components/episode-template/episode-template-summary/episode-template-summary.component';
import { FactionManagerShellComponent } from './episode-components/faction/faction-manager-shell.component';
import { FactionSummaryComponent } from './episode-components/faction/faction-summary/faction-summary.component';
import { FactionEditorComponent } from './episode-components/faction/faction-editor/faction-editor.component';
import { NPCInputComponent } from './episode-components/common/npc-input/npc-input.component';
import { EnvironmentManagerShellComponent } from './episode-components/environment/environment-manager-shell.component';
import { EnvironmentSummaryComponent } from './episode-components/environment/environment-summary/environment-summary.component';
import { EnvironmentEditorComponent } from './episode-components/environment/environment-editor/environment-editor.component';
import { LocationManagerShellComponent } from './episode-components/location/location-manager-shell.component';
import { LocationSummaryComponent } from './episode-components/location/location-summary/location-summary.component';
import { LocationEditorComponent } from './episode-components/location/location-editor/location-editor.component';
import { EpisodeStageComponent } from './episode/episode-stage/episode-stage.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EpisodeShellComponent,
    EpisodeStageComponent,
    MacGuffinManagerShellComponent,
    MacGuffinSummaryComponent,
    MacGuffinEditorComponent,
    NPCInputComponent,
    FactionManagerShellComponent,
    FactionSummaryComponent,
    FactionEditorComponent,
    EnvironmentManagerShellComponent,
    EnvironmentSummaryComponent,
    EnvironmentEditorComponent,
    LocationManagerShellComponent,
    LocationSummaryComponent,
    LocationEditorComponent,
    EpisodeTemplateManagerShellComponent,
    EpisodeTemplateSummaryComponent,
    EpisodeTemplateEditorComponent,
    ComponentSummaryListComponent,
    ComponentEditorShellComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressBarModule,
    MatSelectModule,
    MatTabsModule,
    StoreModule.forRoot<AdventureState>(buildReducer()),
    EffectsModule.forRoot([AppEffects]),
    RouterModule.forRoot(buildRoutes(), { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
