// Course details received from .NET API
export interface Course {
  courseId: number;
  courseName: string;
}

// Student registration details
export interface Registration {
  studentName: string;
  email: string;
  phone: string;
  courseId: number;
}

// Response received after registration
export interface RegistrationResponse {
  message: string;
  registrationId: number;
}