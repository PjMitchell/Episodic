import { OnInit, OnDestroy, Directive } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Observable, Subscription, SubscriptionLike } from 'rxjs';
import { filter, map, shareReplay } from 'rxjs/operators';
import { generateGuid } from 'src/app/helpers/guid-generator';
import { ComponentApiService } from 'src/app/services/component-api.service';
import { EpisodeComponentStore } from '../../episode-component.store';


@Directive()
export class ComponentEditorBaseDirective<T> implements OnInit, OnDestroy {
    id$: Observable<string>;
    isNew$: Observable<boolean>;
    isLoading$: Observable<boolean>;
    subscriptions = new Subscription();


  constructor(
    private summaryurl: string,
    public form: FormGroup,
    private store: EpisodeComponentStore<T>,
    private apiService: ComponentApiService<T>,
    private route: ActivatedRoute,
    private router: Router) {
    }

    ngOnInit() {
      this.id$ = this.route.paramMap.pipe(map(v => {
        return this.onIdUpdated(v);
      }),
        shareReplay(1)
      );

      this.isNew$ = this.route.paramMap.pipe(
        map(v => !v.has('id')),
        shareReplay(1)
      );

      this.isLoading$ = this.store.select(s => s.openComponent.isLoading);

      this.subscriptions.add(this.store.select(s => s.openComponent.value).pipe(
        filter(v => v ? true : false)
      ).subscribe(v => this.setFormValue(v)));
    }

    setFormValue(v: T) {
      this.form.setValue(v);
    }

    save() {
      let subscription: SubscriptionLike;
      subscription = this.apiService.update$(this.form.value).subscribe(v => {
        subscription.unsubscribe();
        if (v.isSuccess) {
          this.back();
        }
      });
    }

    back() {
      this.router.navigateByUrl(this.summaryurl);
    }

    ngOnDestroy() {
      this.subscriptions.unsubscribe();
    }

    private onIdUpdated(v: ParamMap) {
      let result;
      if (v.has('id')) {
        result = v.get('id');
        this.store.getExisting(result);
      } else {
        result = generateGuid();
        this.store.getNew(result);
      }
      return result;
    }
}
