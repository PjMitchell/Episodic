import { RequestState } from '../helpers/api-request-helper';
import { Episode } from '../models/episode';
import { ActionReducerMap, Action } from '@ngrx/store';
import { currentEpisodeReducer } from './app.reducer';

export interface AdventureState {
    currentEpisode: RequestState<Episode>;
}


export function buildReducer(): ActionReducerMap<AdventureState, Action> {
    return {
        currentEpisode: currentEpisodeReducer
    };
}
