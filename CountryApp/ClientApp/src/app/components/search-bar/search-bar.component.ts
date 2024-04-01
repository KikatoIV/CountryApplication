import { Component,  Output, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})

export class SearchBarComponent {
  searchTerm: string = '';
  searchSubject: Subject<string> = new Subject<string>();
  @Output() searchEmitter: EventEmitter<string> = new EventEmitter<string>();

  clearSearch(){
    this.searchEmitter.emit('');
  }

  onSearchChange(): void {
    this.searchEmitter.emit(this.searchTerm);
}
}
