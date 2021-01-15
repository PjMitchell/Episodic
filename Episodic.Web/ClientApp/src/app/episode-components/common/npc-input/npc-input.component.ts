import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-npc-input',
  templateUrl: './npc-input.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NPCInputComponent {
  @Input()
  npcFormGroup: FormGroup;
}
