# Registration & Login Console Application (.NET Framework)

## 📌 Project Overview

This project is a **console-based Registration and Login system** built using **C# (.NET Framework)** with **SQL Server (LocalDB)** as the database. It demonstrates core backend concepts such as **user authentication, password hashing, OTP-based password reset, and database operations using ADO.NET**.

The application is designed for learning and practice purposes, focusing on **secure authentication logic** in a simple and understandable way.

---

## 🚀 Features

* 🔐 **User Registration**

  * Prevents duplicate usernames
  * Stores passwords using **SHA256 hashing**

* 🔑 **User Login**

  * Validates username and hashed password from database

* 🔁 **Forgot Password Mechanism**

  * Generates a **6-digit OTP**
  * Stores OTP with timestamp and usage status
  * Sends OTP to registered email using **SMTP (Gmail)**
  * Verifies OTP before allowing password reset

* ⏱ **OTP Security**

  * OTP has expiry time
  * OTP can be used only once (`IsUsed` flag)

* 🗄 **Database Integration**

  * SQL Server LocalDB
  * Uses **ADO.NET** (`SqlConnection`, `SqlCommand`)

---

## 🧠 Technologies Used

* C# (.NET Framework)
* SQL Server (LocalDB)
* ADO.NET
* SHA256 Password Hashing
* SMTP (Gmail App Password)

---

## 🗂 Project Structure

```
RegistrationLogin
│
├── Services
│   ├── UserService.cs        // Registration & Login logic
│   ├── PasswordService.cs    // Hashing & reset password logic
│   └── EmailService.cs       // OTP email sending
│
├── Program.cs                // Main console flow
├── App.config                // Connection string
└── README.md
```

---

## 🔒 Security Concepts Implemented

* Password hashing (SHA256)
* OTP verification with expiry
* One-time OTP usage
* Secure email authentication using Gmail App Password

---

## 🎯 Learning Outcomes

* Understanding authentication flow
* Implementing secure password storage
* Working with SQL Server using ADO.NET
* Using SMTP for email services
* Structuring a console application with service layers

---

## 📌 Note

This project is intended for **learning and practice**. For production use, advanced security measures like **salted hashing, token-based authentication, and encryption** should be applied.

---

## 👤 Author

**Tangudu Raja**
Computer Science & Engineering Student

---

⭐ If you found this project useful, feel free to star the repository!
