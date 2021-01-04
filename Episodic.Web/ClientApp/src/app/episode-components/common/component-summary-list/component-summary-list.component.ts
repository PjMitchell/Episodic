import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ComponentSummary } from 'src/app/models/episode';

@Component({
    selector: 'app-component-summary-list',
    templateUrl: './component-summary-list.component.html',
    styleUrls: ['./component-summary-list.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
  })
export class ComponentSummaryListComponent {
    @Input()
    items: ComponentSummary[];
    @Input()
    baseLink: string;
    isLoading$ = new BehaviorSubject<boolean>(false);
    @Input()
    get isLoading() { return this.isLoading$.value; }
    set isLoading(value) { this.isLoading$.next(value); }
    @Output()
    deleteClicked = new EventEmitter<ComponentSummary>();
}
