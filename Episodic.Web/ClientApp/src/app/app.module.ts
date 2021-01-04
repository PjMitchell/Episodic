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
import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatProgressBarModule, MatSelectModule, MatTooltipModule } from '@angular/material';
import { MacGuffinEditorComponent } from './episode-components/macguffin/macguffin-editor/macguffin-editor.component';
import { ComponentEditorShellComponent } from './episode-components/common/component-editor/component-editor-shell.component';
import { EpisodeTemplateManagerShellComponent } from './episode-components/episode-template/episode-template-manager-shell.component';
import { EpisodeTemplateEditorComponent } from './episode-components/episode-template/episode-template-editor/episode-template-editor.component';
import { EpisodeTemplateSummaryComponent } from './episode-components/episode-template/episode-template-summary/episode-template-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EpisodeShellComponent,
    MacGuffinManagerShellComponent,
    MacGuffinSummaryComponent,
    MacGuffinEditorComponent,
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
    StoreModule.forRoot<AdventureState>(buildReducer()),
    EffectsModule.forRoot([AppEffects]),
    RouterModule.forRoot(buildRoutes()),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
