import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ComponentSummaryListComponent } from './component-summary-list.component';
import { MatButtonModule, MatCardModule, MatProgressBarModule } from '@angular/material';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';

describe('ComponentSummaryListComponent', () => {
  let component: ComponentSummaryListComponent;
  let fixture: ComponentFixture<ComponentSummaryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComponentSummaryListComponent ],
      imports: [
        MatCardModule,
        MatProgressBarModule,
        MatButtonModule,
        RouterTestingModule.withRoutes([])
      ],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComponentSummaryListComponent);
    component = fixture.componentInstance;
    component.baseLink = '/test';
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  describe('when is loading', () => {
    beforeEach(() => {
      component.isLoading = true;
      fixture.detectChanges();
    });
    it('shows loading message', () => {
      const loadingSection = fixture.debugElement.queryAll(By.css('.summary-loading-section'));
      expect(loadingSection.length).toBe(1);
    });
    it('hides summaryContents', () => {
      const summaryContainer = fixture.debugElement.queryAll(By.css('.component-summary-container'));
      expect(summaryContainer.length).toBe(0);
    });
  });
  describe('when has items', () => {
    beforeEach(() => {
      component.isLoading = false;
      component.items = [
        { id: '1234', name: 'Item one', description: 'Description for Item One'}
      ];
      fixture.detectChanges();
    });
    it('hides loading message', () => {
      const loadingSection = fixture.debugElement.queryAll(By.css('.summary-loading-section'));
      expect(loadingSection.length).toBe(0);
    });
    it('shows summaryContents', () => {
      const summaryContainer = fixture.debugElement.queryAll(By.css('.component-summary-container'));
      expect(summaryContainer.length).toBe(1);
    });

    it('shows card for item', () => {
      const card = fixture.debugElement.query(By.css('.component-summary-container')).queryAll(By.css('.component-summary'));
      expect(card.length).toBe(1);
    });
  });

});
