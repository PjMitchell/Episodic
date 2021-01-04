import { Observable } from 'rxjs';
import { map, startWith, mergeMap } from 'rxjs/operators';
import { ActionCreator, createAction, props, createReducer, on } from '@ngrx/store';
import { Actions, ofType } from '@ngrx/effects';

import { TypedAction, Creator, Action } from '@ngrx/store/src/models';

export interface RequestPipe<TOutput, TInput = void> {
    request$: Observable<RequestState<TOutput>>;
    next: (input: TInput) => void;
}

export type requestStatus = 'LOADING' | 'OK' | 'INITIAL';

export interface RequestState<T> {
    isLoading: boolean;
    value?: T;
    status: requestStatus;
}

export function returnedRequest<T>(state: T): RequestState<T> {
    return {
        isLoading: false,
        value: state,
        status: 'OK'
    };
}

export function loadingRequest<T>(): RequestState<T> {
    return {
        isLoading: true,
        status: 'LOADING'
    };
}

export function initialRequest<T>(state: T): RequestState<T> {
    return {
        isLoading: false,
        value: state,
        status: 'INITIAL'
    };
}

export interface RequestActionCollection<TOutput> {
    requested: ActionCreator<string, () => TypedAction<string>>;
    returned: ActionCreator<string, (props: Payload<TOutput>) => Payload<TOutput> & TypedAction<string>>;
}

export function createRequestActionCollection<T>(prefix: string):  RequestActionCollection<T> {
    return {
        requested: createAction(prefix + ' requested'),
        returned: createAction(prefix + ' returned', props<Payload<T>>())
    };
}

export function buildRequestEffectPipeline<TOutput, TInitialAction extends ActionCreator<string, Creator>>(
    actions$: Actions,
    triggerAction: TInitialAction,
    apiFunc: (initialAction: ReturnType<TInitialAction>) => Observable<TOutput>,
    actions: RequestActionCollection<TOutput>): Observable<Action> {
        return actions$.pipe(
            ofType(triggerAction),
            mergeMap(v => apiFunc(v).pipe(
                map(i => actions.returned({ payload: i})),
                startWith(actions.requested())
        )));
}

export function createRequestReducer<T>(initialState: T, actionCollection: RequestActionCollection<T>) {
    return createReducer<RequestState<T>>(
        initialRequest(initialState),
        on(actionCollection.requested, s => loadingRequest<T>()),
        on(actionCollection.returned, (s, a) => returnedRequest(a.payload))
    );
}

export interface Payload<T> {
    payload: T;
}
