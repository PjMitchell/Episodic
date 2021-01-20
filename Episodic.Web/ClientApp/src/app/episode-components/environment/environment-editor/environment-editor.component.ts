import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Environment } from 'src/app/models/episode';
import { EnvironmentApiService } from 'src/app/services/environment-api.service';
import { ComponentEditorBaseDirective } from '../../common/component-editor/component-editor.base';
import { EnvironmentComponentStore } from '../environment-component.store';

@Component({
    templateUrl: './environment-editor.component.html',
  })
  export class EnvironmentEditorComponent extends ComponentEditorBaseDirective<Environment> {
    constructor(
      store: EnvironmentComponentStore,
      formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: EnvironmentApiService,
      router: Router) {
      super('/environment', environmentFormBuilder(formBuilder), store, apiService, route, router);
    }
}

function environmentFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required)
  });
}
