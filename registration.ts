import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import {
  Course,
  Registration,
  RegistrationResponse
} 
from '../registration/Model/registration.model';
@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private apiUrl = 'https://localhost:7158/api/Register';

  constructor(private http: HttpClient) {}

  // Get all courses from database
  getCourses(): Observable<Course[]> {

    return this.http.get<Course[]>(
      `${this.apiUrl}/courses`
    );

  }

  // Save student registration
  registerStudent(
    student: Registration
  ): Observable<RegistrationResponse> {

    return this.http.post<RegistrationResponse>(
      `${this.apiUrl}/register`,
      student
    );

  }

}