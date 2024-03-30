import { Component } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})

export class SearchBarComponent {
  searchTerm: string = '';

  performSearch() {
      console.log('Performing search for:', this.searchTerm);
  }
}
