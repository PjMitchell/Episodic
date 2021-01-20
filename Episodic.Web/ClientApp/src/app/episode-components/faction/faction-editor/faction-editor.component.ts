import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Faction } from 'src/app/models/episode';
import { FactionApiService } from 'src/app/services/faction-api.service';
import { ComponentEditorBaseDirective } from '../../common/component-editor/component-editor.base';
import { FactionComponentStore } from '../faction-component.store';

@Component({
    templateUrl: './faction-editor.component.html',
  })
  export class FactionEditorComponent extends ComponentEditorBaseDirective<Faction> {
    constructor(
      store: FactionComponentStore,
      formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: FactionApiService,
      router: Router) {
      super('/faction', factionFormBuilder(formBuilder), store, apiService, route, router);
    }
}

function factionFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required),
    boss: formBuilder.group({
      name: formBuilder.control('', Validators.required),
      description: formBuilder.control('', Validators.required),
    })
  });
}
