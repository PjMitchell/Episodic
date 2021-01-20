import { OnInit, Directive } from '@angular/core';
import { Observable, SubscriptionLike } from 'rxjs';
import { ComponentSummary } from 'src/app/models/episode';
import { ComponentApiService } from 'src/app/services/component-api.service';
import { EpisodeComponentStore } from '../../episode-component.store';

@Directive()
export class BaseSummaryComponentDirective<T> implements OnInit {
    summaries$: Observable<ComponentSummary[]>;
    isLoading$: Observable<boolean>;

    constructor(public readonly baseLink, private store: EpisodeComponentStore<T>, private apiService: ComponentApiService<T>) {
      this.summaries$ = this.store.select(s => s.summaries.value);
      this.isLoading$ = this.store.select(s => s.summaries.isLoading);
    }
    ngOnInit(): void {
      this.store.getSummaries();
    }

    onDelete(item: ComponentSummary) {
      let subscription: SubscriptionLike;
      subscription = this.apiService.delete$(item.id).subscribe(v => {
        subscription.unsubscribe();
        if (v.isSuccess) {
          this.store.getSummaries();
        }
      });
    }
}
