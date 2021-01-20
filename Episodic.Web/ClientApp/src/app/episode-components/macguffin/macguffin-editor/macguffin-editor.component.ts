import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MacGuffin } from 'src/app/models/episode';
import { MacGuffinApiService } from 'src/app/services/macguffin-api.service';
import { ComponentEditorBaseDirective } from '../../common/component-editor/component-editor.base';
import { MacGuffinComponentStore } from '../macguffin-component.store';

@Component({
    templateUrl: './macguffin-editor.component.html',
  })
  export class MacGuffinEditorComponent extends ComponentEditorBaseDirective<MacGuffin> {
    constructor(
      store: MacGuffinComponentStore,
      formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: MacGuffinApiService,
      router: Router) {
      super('/macGuffin', macGuffinFormBuilder(formBuilder), store, apiService, route, router);
    }
}

function macGuffinFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required)
  });
}
