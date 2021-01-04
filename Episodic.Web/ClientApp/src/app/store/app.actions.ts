import { createRequestActionCollection } from '../helpers/api-request-helper';
import { Episode } from '../models/episode';
import { createAction } from '@ngrx/store';

export const requestNewCurrentEpisode = createAction('[Episodic] Request new current episode');
export const currentEpisodeRequestActions = createRequestActionCollection<Episode>('[Episodic] current episode');
