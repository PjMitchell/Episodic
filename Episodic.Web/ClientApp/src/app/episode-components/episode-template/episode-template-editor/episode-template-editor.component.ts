import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EpisodeTemplate } from 'src/app/models/episode';
import { EpisodeTemplateApiService } from 'src/app/services/episode-template-api.service';
import { ComponentEditorBase } from '../../common/component-editor/component-editor.base';
import { EpisodeTemplateComponentStore } from '../episode-template-component.store';

@Component({
    templateUrl: './episode-template-editor.component.html',
  })
  export class EpisodeTemplateEditorComponent extends ComponentEditorBase<EpisodeTemplate> {
    availableOptions = getAllComponentOptions();
    constructor(
      store: EpisodeTemplateComponentStore,
      formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: EpisodeTemplateApiService,
      router: Router) {
      super('/episodeTemplate', episodeTemplateFormBuilder(formBuilder), store, apiService, route, router);
    }
}

function episodeTemplateFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required),
    descriptionTemplate: formBuilder.control('', Validators.required),
    requiredComponents: formBuilder.control([]),

  });
}

interface ComponentOption {
  value: string;
  description: string;
}

function getAllComponentOptions(): ComponentOption[] {
  return [
    { value: 'MacGuffin', description: 'MacGuffin'},
    { value: 'Faction', description: 'Faction'}
  ];
}
