import { createRequestReducer, RequestState } from '../helpers/api-request-helper';
import { currentEpisodeRequestActions } from './app.actions';
import { Episode } from '../models/episode';
import { Action } from '@ngrx/store';

const _currentEpisodeReducer = createRequestReducer(null, currentEpisodeRequestActions);

export function currentEpisodeReducer(state: RequestState<Episode>, action: Action) {
    return _currentEpisodeReducer(state, action);
}
