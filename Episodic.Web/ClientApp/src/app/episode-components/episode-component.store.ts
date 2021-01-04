import { ComponentStore } from '@ngrx/component-store';
import { Observable } from 'rxjs';
import { switchMap, map, startWith, tap,  } from 'rxjs/operators';
import { initialRequest, loadingRequest, RequestState, returnedRequest } from '../helpers/api-request-helper';
import { CommandResult, ComponentSummary } from '../models/episode';
import { ComponentApiService } from '../services/component-api.service';

export abstract class EpisodeComponentStore<T> extends ComponentStore<EpisodeComponent<T>> {
    constructor(private service: ComponentApiService<T>) {
        super({
            summaries: initialRequest<ComponentSummary[]>([]),
            openComponent: initialRequest<T>(null)
        });
    }

    readonly getSummaries = this.effect((trigger$: Observable<void>) => {
        return trigger$.pipe(
          switchMap(() => this.service.getAll$().pipe(
              map(r => returnedRequest(r)),
              startWith(loadingRequest<ComponentSummary[]>()),
              tap<RequestState<ComponentSummary[]>>(v => this.updateSummaries(v))
        )));
    });

    readonly getExisting = this.effect((trigger$: Observable<string>) => {
        return trigger$.pipe(
          switchMap(id => this.service.getById$(id).pipe(
              map(r => returnedRequest(r)),
              startWith(loadingRequest<T>()),
              tap<RequestState<T>>(v => this.updateOpenComponent(v))
        )));
    });

    readonly getNew = this.effect((trigger$: Observable<string>) => {
        return trigger$.pipe(
            tap<string>(v => this.updateOpenComponent(returnedRequest(this.createEmptyComponent(v))))
        );
    });

    private readonly updateSummaries = this.updater((state, summaries: RequestState<ComponentSummary[]>) => ({
        ...state,
        summaries,
    }));

    private readonly updateOpenComponent = this.updater((state, openComponent: RequestState<T>) => ({
        ...state,
        openComponent,
    }));

    protected abstract createEmptyComponent(id: string): T;

}

export interface EpisodeComponent<T> {
    summaries: RequestState<ComponentSummary[]>;
    openComponent: RequestState<T>;
}
