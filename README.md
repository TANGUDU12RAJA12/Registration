🔐 Registration & Login System with OTP APIs (.NET Framework)
📌 Project Overview

This project is a Registration and Login System developed using C# (.NET Framework).
It initially started as a console-based authentication application and was later enhanced with Web APIs for OTP generation and verification.

The project demonstrates secure authentication practices, OTP-based password reset, and real-world backend challenges such as API hosting, database connectivity, SSL/TLS issues, and error handling.

🚀 Features
🔐 User Registration

Prevents duplicate usernames

Stores passwords using SHA256 hashing

Saves user data securely in SQL Server

🔑 User Login

Validates username and hashed password from the database

🔁 Forgot Password (OTP-Based)

Generates a 6-digit OTP

Stores OTP with:

Creation time

Expiry time

One-time usage flag (IsUsed)

Allows password reset only after successful OTP verification

🌐 New Enhancements (Added Later)
✅ OTP Web APIs

Instead of handling OTP only inside the console application, separate Web APIs were created for better scalability and testing.

🔹 OTP Generation API

Generates OTP

Stores OTP in the database

Sends OTP to the registered email

🔹 OTP Verification API

Validates OTP

Checks expiry time

Ensures OTP is used only once

✅ Hosting

Hosted Web API on MonsterASP

Hosted SQL Server database on MonsterASP

Faced and resolved real hosting-related issues such as database connectivity and service unavailability

✅ API Testing

Used Postman to:

Test OTP generation API

Test OTP verification API

Validate request/response flow and error handling

🧠 Technologies Used

C# (.NET Framework)

ASP.NET Web API

SQL Server (LocalDB → Hosted SQL Server)

ADO.NET (SqlConnection, SqlCommand)

SHA256 Password Hashing

SMTP (Gmail App Password)

Postman (API Testing)

🗂 Project Structure
RegistrationLogin
│
├── Services
│   ├── UserService.cs        // Registration & Login logic
│   ├── PasswordService.cs    // Hashing & password reset logic
│   └── EmailService.cs       // OTP email sending
│
├── WebApi
│   ├── OTPController.cs      // OTP generation & verification APIs
│
├── Program.cs                // Console application flow
├── App.config                // Database connection string
└── README.md

⚠️ Challenges Faced & Solutions
❌ Database Connection Errors

Problems:

SQL connection failures after hosting

Named Pipes Provider, error: 40

HTTP 503 Service Unavailable

Solutions:

Learned shared hosting limitations

Fixed connection strings

Understood SQL Server remote access configuration

❌ SSL / TLS Authentication Errors

Problem:

Authentication failed because the remote party closed the transport stream

Solution:

Configured proper TLS support

Ensured HTTPS requests were handled correctly

❌ OTP API Internal Server Errors (500)

Problem:

API returned 500 Internal Server Error during OTP generation

Solution:

Added proper exception handling

Debugged APIs using Postman

Verified database tables and SMTP configuration

❌ Free Hosting Limitations

Problems:

Database creation failed with HTTP 503

SQL services temporarily unavailable

Solutions:

Understood free hosting limitations

Used retry strategy and off-peak testing

Tested logic locally before deployment

🔒 Security Concepts Implemented

SHA256 password hashing

OTP expiry validation

One-time OTP usage

Secure email authentication using Gmail App Password

Separation of concerns using service layers

API-level validation

🎯 Learning Outcomes

Built a complete authentication system from scratch

Converted console-based logic into Web APIs

Gained experience with real-world hosting challenges

Improved debugging skills for production-level errors

Learned API testing using Postman

Strengthened understanding of backend security concepts

📌 Note

This project is built for learning and practice purposes.

For production-level systems:

Use salted hashing (bcrypt / PBKDF2)

Implement JWT or OAuth-based authentication

Use secure secrets management

Prefer paid or dedicated cloud hosting

👤 Author

Tangudu Raja
Computer Science & Engineering Student

⭐ If you found this project useful, feel free to star the repository!