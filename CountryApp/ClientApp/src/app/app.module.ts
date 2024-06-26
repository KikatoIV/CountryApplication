import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CountryService } from './service/country-service/countries.service';
import { CountryGridComponent } from 'src/app/components/country-grid/country-grid.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { InfoPanelComponent } from './components/info-panel/info-panel.component';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ThemeToggleComponent } from './components/theme-toggle/theme-toggle.component';
import { ThemeService } from './service/theme-service/theme.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CountryGridComponent,
    SearchBarComponent,
    InfoPanelComponent,
    ThemeToggleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule
  ],
  providers: [CountryService, ThemeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
