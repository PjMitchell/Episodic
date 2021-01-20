import { Component } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EpisodeStageTemplate, EpisodeTemplate } from 'src/app/models/episode';
import { EpisodeTemplateApiService } from 'src/app/services/episode-template-api.service';
import { ComponentEditorBaseDirective } from '../../common/component-editor/component-editor.base';
import { EpisodeTemplateComponentStore } from '../episode-template-component.store';

@Component({
    templateUrl: './episode-template-editor.component.html',
  })
  export class EpisodeTemplateEditorComponent extends ComponentEditorBaseDirective<EpisodeTemplate> {
    availableOptions = getAllComponentOptions();
    constructor(
      store: EpisodeTemplateComponentStore,
      private formBuilder: FormBuilder,
      route: ActivatedRoute,
      apiService: EpisodeTemplateApiService,
      router: Router) {
      super('/episodeTemplate', episodeTemplateFormBuilder(formBuilder), store, apiService, route, router);
    }

    add() {
      const controlArray = this.form.controls.stages as FormArray;
      const newStage = this.formBuilder.group({
        name: this.formBuilder.control('', Validators.required),
        descriptionTemplate: this.formBuilder.control('', Validators.required)
      });
      controlArray.push(newStage);
    }

    remove(i: number) {
      const controlArray = this.form.controls.stages as FormArray;
      controlArray.removeAt(i);
    }

    setFormValue(v: EpisodeTemplate) {
      const controlArray = this.form.controls.stages as FormArray;
      controlArray.clear();
      v.stages.forEach((stage, i) => {
        controlArray.setControl(i, this.buildStageControl(stage));
      });
      super.setFormValue(v);
    }

    buildStageControl(v: EpisodeStageTemplate) {
      return this.formBuilder.group({
        name: this.formBuilder.control(v.name, Validators.required),
        descriptionTemplate: this.formBuilder.control(v.description, Validators.required)
      });
    }
}

function episodeTemplateFormBuilder(formBuilder: FormBuilder) {
  return formBuilder.group({
    id: formBuilder.control('', Validators.required),
    name: formBuilder.control('', Validators.required),
    description: formBuilder.control('', Validators.required),
    descriptionTemplate: formBuilder.control('', Validators.required),
    requiredComponents: formBuilder.control([]),
    stages: formBuilder.array([])
  });
}

interface ComponentOption {
  value: string;
  description: string;
}

function getAllComponentOptions(): ComponentOption[] {
  return [
    { value: 'MacGuffin', description: 'MacGuffin'},
    { value: 'Faction', description: 'Faction'},
    { value: 'Location', description: 'Location'},
    { value: 'Environment', description: 'Environment'},
  ];
}
