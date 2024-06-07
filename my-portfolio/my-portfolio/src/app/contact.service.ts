import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private apiUrl = 'http://localhost:3000/send-email'; // URL of the backend endpoint

  constructor(private http: HttpClient) { }

  sendEmail(email: string, subject: string, message: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { email, subject, message };
    return this.http.post<any>(this.apiUrl, body, { headers });
  }
}
