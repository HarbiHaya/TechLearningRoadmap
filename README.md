
# **Tech Learning Roadmap Console Application**  

## **📌 Project Overview**  
The **Tech Learning Roadmap** is a **console-based application** designed to help users create, manage, and track their learning journey in programming.  
Users can **select their preferred programming language** (C#, Java, Python) and **learning level** (Beginner, Intermediate, Advanced).  
The system generates a **personalized learning roadmap** based on these selections and provides an interactive experience for users to **track progress and update their learning paths**.  

Administrators have the ability to **manage users, track learning progress, and handle system operations**.

---

## **📂 Project Structure**  
```
📦 TechLearningRoadmap  
 ┣ 📂 Data  
 ┃ ┣ 📜 IDataManager.cs  
 ┃ ┣ 📜 DataManager.cs  
 ┣ 📂 Models  
 ┃ ┣ 📜 Account.cs  
 ┃ ┣ 📜 AdminAccount.cs  
 ┃ ┣ 📜 UserAccount.cs  
 ┃ ┣ 📜 LanguageLevel.cs  
 ┃ ┣ 📜 JavaLevel.cs  
 ┃ ┣ 📜 PythonLevel.cs  
 ┃ ┣ 📜 CSharpLevel.cs  
 ┃ ┣ 📜 Enums.cs  
 ┣ 📂 Services  
 ┃ ┣ 📜 AuthService.cs  
 ┃ ┣ 📜 RoadmapService.cs  
 ┣ 📂 Utilities  
 ┃ ┣ 📜 HashUtility.cs  
 ┃ ┣ 📜 InputHelper.cs  
 ┣ 📂 UI  
 ┃ ┣ 📜 Menu.cs  
 ┣ 📜 Program.cs  
```

### **🔹 Key Components**
- **Data Layer (`Data/`)**  
  - Handles **storage and management of user/admin data**.  
- **Models (`Models/`)**  
  - Contains **account and roadmap classes** representing users, admins, and learning paths.  
- **Services (`Services/`)**  
  - Manages **authentication and learning roadmap generation**.  
- **Utilities (`Utilities/`)**  
  - Provides **helper methods** for secure password hashing (`HashUtility`) and masked password input (`InputHelper`).  
- **User Interface (`UI/`)**  
  - Manages **menu navigation and user interactions**.  
- **Program (`Program.cs`)**  
  - **Entry point** of the application.

---

## **🚀 Features**  

### **👤 User Features**  
✅ **Register & Login** (Users & Admins)  
✅ **Choose Programming Language & Level**  
✅ **View Personalized Learning Roadmap**  
✅ **Update Learning Preferences**  
✅ **Secure Password Handling (SHA-256 Hashing)**  

### **🛠 Admin Features**  
✅ **Admin Login with Predefined Credentials**  
✅ **View All Registered Users**  
✅ **Manage (Add/Remove) User Accounts**  

### **🔒 Security & Validation**  
✅ **Passwords are securely hashed using SHA-256**  
✅ **Masked password entry (displays `*` instead of characters)**  
✅ **Input validation prevents invalid user inputs**  

---

## **📌 How It Works**

### **1️⃣ Main Menu**
When the program starts, the user sees:
```
=== Welcome to Tech Learning Roadmap ===
1. Register
2. Login
3. Exit
```
- **New users** → **Register** and create an account.  
- **Returning users** → **Login** with username and password.  
- **Admins** → Login with **predefined credentials**.

---

### **2️⃣ User Dashboard**
After logging in, users can:
```
=== User Dashboard ===
1. View My Roadmap
2. Create or Change Learning Path
3. Logout
```
- If **first time logging in**, users **select their programming language & experience level**.  
- A **learning roadmap is assigned automatically**.  
- Users can **update their roadmap** anytime.

---

### **3️⃣ Admin Panel**
Admins have access to:
```
=== Admin Panel ===
1. View All Users
2. Manage Users
3. Logout
```
- **View all registered users**  
- **Add or remove users**  

---

## **🔑 Authentication System**
- User credentials are **validated** before login.  
- **Passwords are stored as SHA-256 hashes** to ensure security.  
- Admin login uses **predefined credentials**:  
  - **Username:** `haya`  
  - **Password:** `HayaA123@`  

---

## **⚡ Input Validation & Error Handling**
- **Passwords must meet security requirements** (8+ characters, uppercase, lowercase, number, special character).  
- **Invalid selections display clear error messages**.  
- **Admins cannot delete themselves**.  
- **Users cannot change passwords to weak ones**.  

---

## **📌 How to Run**
1️⃣ **Open Visual Studio Code**  
2️⃣ **Clone the Repository** (if using GitHub)  
3️⃣ Open the **TechLearningRoadmap** project  
4️⃣ **Run the application**  
   - In VS Code, **press F5** or **run `dotnet run`** in the terminal.  
5️⃣ **Follow the on-screen instructions**  

---

## **🌟 Future Enhancements**
- **GUI Version**: Convert the console application to a **WinForms** or **WPF-based** desktop app.  
- **Database Storage**: Implement **SQLite or MySQL** instead of using in-memory data.  
- **Progress Tracking**: Add features for users to **mark completed tasks**.  
- **Multi-User Support**: Improve admin controls for **bulk user management**.  



