import { Component, EventEmitter, Input, Output } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Country } from 'src/Models/country.model';

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
  @Input() isPanelVisible = false;
  @Input() countryInformation: Country | undefined;
  @Output() panelClosed = new EventEmitter<void>();

  togglePanel() {
    this.isPanelVisible = !this.isPanelVisible;
    if (!this.isPanelVisible) {
      this.panelClosed.emit();
    }
  }
}
