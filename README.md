# ECommerce Website

An ASP.NET Core MVC web application that simulates an online shopping platform with product management, filtering, pagination, and detailed product views.

## 📋 Features

### 🛍 Product Management
- Product listing with pagination  
- Filter products by category  
- Filter products by supplier  
- Product details page  
- Related products suggestion  

### 🔐 Authentication & Authorization
- User registration and login  
- Role-based authorization (Admin / User)  
- Secure password hashing  
- Google OAuth login integration  

### 💳 Payment Integration
- VNPay payment gateway integration  
- Order checkout and payment processing  

### 🏗 Architecture & Design
- Clean layered architecture (Controller – Service – Repository)  
- Repository pattern implementation  
- Unit of Work pattern  
- Separation of concerns  


## 🛠 Technologies Used

- C#  
- ASP.NET Core MVC  
- SQL Server  
- Razor Views  

## 🚀 How to Run the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/leduckien25/ECommerce-Website.git

2. Open SQL Server Management Studio (SSMS).
3. Run the database script located in:
    ```bash
    ECommerceDB.sql
    ```
    This will create the database and required tables.

4. Open the solution in Visual Studio.

5. Configure your connection string and API keys in appsettings.json
   ```bash
   appsettings.json
   ```
6. Run the application.
