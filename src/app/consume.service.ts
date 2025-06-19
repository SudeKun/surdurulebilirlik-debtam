import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ConsumeService {
  private apiUrl = 'http://localhost:5000/api/Consume';

  constructor(private http: HttpClient) {}

  getConsumes(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  addConsume(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
}
