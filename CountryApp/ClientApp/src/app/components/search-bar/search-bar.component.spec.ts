import { EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import { SearchBarComponent } from './search-bar.component';

describe('SearchBarComponent', () => {
  let component: SearchBarComponent;

  beforeEach(() => {
    component = new SearchBarComponent();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.searchTerm).toEqual('');
    expect(component.searchSubject instanceof Subject).toBe(true);
    expect(component.searchEmitter instanceof EventEmitter).toBe(true);
  });

  it('clearSearch should emit empty string and reset searchTerm', () => {
    const emitSpy = spyOn(component.searchEmitter, 'emit');

    component.searchTerm = 'test';
    component.clearSearch();

    expect(emitSpy).toHaveBeenCalledWith('');
    expect(component.searchTerm).toEqual('');
  });

  it('onSearchChange should emit searchTerm', () => {
    const searchTerm = 'test';
    const emitSpy = spyOn(component.searchEmitter, 'emit');

    component.searchTerm = searchTerm;
    component.onSearchChange();

    expect(emitSpy).toHaveBeenCalledWith(searchTerm);
  });
});
