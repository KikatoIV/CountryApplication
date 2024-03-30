import { Component } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-info-panel',
  templateUrl: './info-panel.component.html',
  styleUrls: ['./info-panel.component.css'],
  animations: [
    trigger('fadeInOut', [
      state('visible', style({ opacity: 1 })),
      state('hidden', style({ opacity: 0 })),
      transition('visible <=> hidden', animate('1s ease-in-out')),
    ]),
  ],
})

export class InfoPanelComponent {
  isPanelVisible = true;

  togglePanel() {
    this.isPanelVisible = !this.isPanelVisible;
  }
}
