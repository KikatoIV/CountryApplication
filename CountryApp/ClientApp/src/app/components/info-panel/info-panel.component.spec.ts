import { EventEmitter } from '@angular/core';
import { InfoPanelComponent } from './info-panel.component';

describe('InfoPanelComponent', () => {
  let component: InfoPanelComponent;

  beforeEach(() => {
    component = new InfoPanelComponent();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.isPanelVisible).toBe(false);
    expect(component.countryInformation).toBeUndefined();
    expect(component.panelClosed instanceof EventEmitter).toBe(true);
  });

  it('togglePanel should toggle isPanelVisible and emit panelClosed if panel is being closed', () => {
    const emitSpy = spyOn(component.panelClosed, 'emit');

    component.togglePanel();
    expect(component.isPanelVisible).toBe(true);
    expect(emitSpy).not.toHaveBeenCalled();

    component.togglePanel();
    expect(component.isPanelVisible).toBe(false);
    expect(emitSpy).toHaveBeenCalled();
  });
});
