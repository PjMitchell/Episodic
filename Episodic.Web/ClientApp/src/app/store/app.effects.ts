import { Actions, createEffect } from '@ngrx/effects';
import { EpisodeProvider } from '../services/episode-provider.service';
import { buildRequestEffectPipeline } from '../helpers/api-request-helper';
import { requestNewCurrentEpisode, currentEpisodeRequestActions } from './app.actions';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AppEffects {
    constructor(private actions: Actions, private provider: EpisodeProvider) {}

    currentAdventures$ = createEffect(() => buildRequestEffectPipeline(this.actions,
        requestNewCurrentEpisode,
        () => this.provider.getAdventure$(),
        currentEpisodeRequestActions));
}
