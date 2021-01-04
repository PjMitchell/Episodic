import { Component, Input, TemplateRef, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-component-editor-shell',
    templateUrl: './component-editor-shell.component.html',
  })
  export class ComponentEditorShellComponent {
    @Input()
    id: string;
    @Input()
    isNew: Observable<boolean>;
    @Input()
    formTemplate: TemplateRef<ComponentEditorFormTemplate>;
    @Input()
    componentForm: FormGroup;
    @Output()
    saveClicked = new EventEmitter<void>();
    @Output()
    backClicked = new EventEmitter<void>();

    constructor() {
    }

    save() {
      this.saveClicked.emit();
    }

    back() {
      this.backClicked.emit();
    }
}

export interface ComponentEditorFormTemplate {
  form: FormGroup;
}
