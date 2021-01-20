import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from 'src/app/models/episode';
import { LocationApiService } from 'src/app/services/location-api.service';
import { ComponentEditorBaseDirective } from '../../common/component-editor/component-editor.base';
import { LocationComponentStore } from '../location-component.store';

@Component({
    templateUrl: './location-editor.component.html',
  })
  export class LocationEditorComponent extends ComponentEditorBaseDirective<Location> {
    constructor(
      store: LocationComponentStore,
      formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: LocationApiService,
      router: Router) {
      super('/location', locationFormBuilder(formBuilder), store, apiService, route, router);
    }
}

function locationFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required)
  });
}
