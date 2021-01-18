import { Component, Input } from '@angular/core';
import { EpisodeStage } from 'src/app/models/episode';

@Component({
  selector: 'app-episode-stage',
  templateUrl: './episode-stage.component.html'
})
export class EpisodeStageComponent {
    @Input()
    public episodeStages: EpisodeStage[];
}
