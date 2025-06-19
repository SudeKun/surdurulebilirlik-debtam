import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.component.html'
})
export class AppComponent {
  consumes: any;

  constructor(private http: HttpClient) {}

  loadConsumes() {
    this.http.get('https://localhost:7097/api/Consume')
      .subscribe(data => {
        this.consumes = data;
        console.log('Consumes loaded:', data);
      });
  }
}
