import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestState } from '../helpers/api-request-helper';
import { Episode } from '../models/episode';
import { AdventureState } from '../store/app.store';
import { Store } from '@ngrx/store';
import { requestNewCurrentEpisode } from '../store/app.actions';

@Component({
  selector: 'app-episode-shell',
  templateUrl: './episode-shell.component.html'
})
export class EpisodeShellComponent implements OnInit {
  public episode$: Observable<RequestState<Episode>>;

  constructor(private store: Store<AdventureState>) {
    this.episode$ = this.store.select(s => s.currentEpisode);
  }

  ngOnInit()  {
    this.go();
  }

  go() {
    this.store.dispatch(requestNewCurrentEpisode());
  }
}


