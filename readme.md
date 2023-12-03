Student API:

Create Student:
Endpoint: POST /students
Payload: Student details (name, roll number, etc.)
Edit Student:
Endpoint: PUT /students/{student_id}
Payload: Updated student details
Delete Student:
Endpoint: DELETE /students/{student_id}
Subject API:

Add Subject:
Endpoint: POST /subjects
Payload: Subject details (name, code, etc.)
Edit Subject:
Endpoint: PUT /subjects/{subject_id}
Payload: Updated subject details
Delete Subject:
Endpoint: DELETE /subjects/{subject_id}
Student-Subject Assignment API:

Assign Subject to Student:
Endpoint: POST /student-subjects
Payload: { "student_id": 1, "subject_id": 101 }
Edit Assignment:
Endpoint: PUT /student-subjects/{assignment_id}
Payload: Updated assignment details
Delete Assignment:
Endpoint: DELETE /student-subjects/{assignment_id}
Marks API:

Record Marks:
Endpoint: POST /marks
Payload: { "student_id": 1, "subject_id": 101, "marks": 85 }
Edit Marks:
Endpoint: PUT /marks/{marks_id}
Payload: Updated marks details
Delete Marks:


Get Student Information:

Endpoint: GET /students/{student_id}
Response: Student details (name, roll number, etc.)
Get All Students:

Endpoint: GET /students
Response: List of all students
Get Subject Information:

Endpoint: GET /subjects/{subject_id}
Response: Subject details (name, code, etc.)
Get All Subjects:

Endpoint: GET /subjects
Response: List of all subjects
Get Student's Subjects:

Endpoint: GET /students/{student_id}/subjects
Response: List of subjects assigned to the student
Get Marks for a Subject:

Endpoint: GET /students/{student_id}/subjects/{subject_id}/marks
Response: Marks obtained by the student in the specified subject
Get All Marks for a Student:

Endpoint: GET /students/{student_id}/marks
Response: List of marks for all subjects of the student
Get GPA for a Student:

Endpoint: GET /students/{student_id}/gpa
Response: Current GPA of the student