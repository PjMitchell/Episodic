import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { EpisodeShellComponent } from './episode-shell.component';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { AdventureState } from '../store/app.store';
import { returnedRequest } from '../helpers/api-request-helper';
import { Action } from '@ngrx/store';
import { SubscriptionLike } from 'rxjs';
import { requestNewCurrentEpisode } from '../store/app.actions';
import { By } from '@angular/platform-browser';

describe('EpisodeShellComponent', () => {
  let component: EpisodeShellComponent;
  let fixture: ComponentFixture<EpisodeShellComponent>;
  let initialState: AdventureState;
  let store: MockStore<AdventureState>;
  let actions = new Array<Action>();
  let actionSubscription: SubscriptionLike;
  beforeEach(waitForAsync(() => {
    initialState = {
        currentEpisode: returnedRequest({
            description: 'description',
            macGuffin: {
                id: '1234',
                name: 'The one ring',
                description: 'The one ring'
            },
            stages: []
        })
    };
    TestBed.configureTestingModule({
      declarations: [ EpisodeShellComponent ],
      providers: [
        provideMockStore({ initialState }),
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    actions = [];
    fixture = TestBed.createComponent(EpisodeShellComponent);
    store = TestBed.inject<MockStore<AdventureState>>(MockStore);
    actionSubscription = store.scannedActions$.subscribe(r => actions.push(r));
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  afterEach(() => {
    if (actionSubscription) {
        actionSubscription.unsubscribe();
    }
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('after Init', () => {
      beforeEach(() => {
        actions = [];
        component.ngOnInit();
        fixture.detectChanges();
      });
      it('Should Update Episode', () => {
        expect(actions.length).toEqual(1);
        expect(actions[0].type).toEqual(requestNewCurrentEpisode.type);
      });

      it('On Go clicked raises new episode request', () => {
        actions = [];
        const goButton: HTMLElement = fixture.debugElement.query(By.css('.episode-go-btn')).nativeElement;
        expect(actions.length).toEqual(0);
        goButton.click();
        expect(actions.length).toEqual(1);
        expect(actions[0].type).toEqual(requestNewCurrentEpisode.type);
      });
  });


});
