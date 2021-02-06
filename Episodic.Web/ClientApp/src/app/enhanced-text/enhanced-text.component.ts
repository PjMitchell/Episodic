import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-enhanced-text',
    templateUrl: './enhanced-text.component.html'
})
export class EnhancedTextComponent {
    @Input()
    value: string;
}
