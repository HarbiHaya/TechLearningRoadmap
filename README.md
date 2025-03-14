# **Tech Learning Roadmap - Console Application**  

## **Overview**  
The **Tech Learning Roadmap System** is a console-based application that allows users to **select a programming language and experience level** to generate a structured **learning roadmap**. The system includes **authentication, user account management, and an admin panel for overseeing users**.  

This project was developed using **C#** with a structured **object-oriented approach**, incorporating **data handling, authentication, input validation, and roadmap generation**.  

---

## **Features**  

### **User Features**  
✔ **Register and Login (with password validation and hashing)**  
✔ **Select a Programming Language & Experience Level**  
✔ **Receive a Personalized Learning Roadmap**  
✔ **Modify Learning Preferences**  
✔ **Secure Password Handling with SHA-256 Hashing**  

### **Admin Features**  
✔ **Predefined Admin Login Credentials**  
   - **Username:** `admin`  
   - **Password:** `Admin123@`  
✔ **View All Registered Users**
✔ **Manage User Accounts (Add/Remove Users)**  

### **Additional Features**  
✔ **Structured Console Menus for Easy Navigation**  
✔ **Strong Input Validation & Error Handling**  
✔ **Generic Data Management Using `DataManager<T>`**  

---

## **How It Works**  

### **1️⃣ Main Menu**  
When the program starts, users and admins see the following options:  
```
=== Welcome to Tech Learning Roadmap ===
1. Register
2. User Login
3. Admin Login
4. Exit
```
- **New users** can register.  
- **Existing users** can log in.  
- **Admins** log in using predefined credentials.  
- **Users can exit the program**.  

---

### **2️⃣ User Dashboard**  
Once logged in, users can access their learning roadmap options:  
```
=== User Dashboard ===
1. Create My Roadmap
2. View My Roadmap
3. Change Learning Path
4. Logout
```
- If a user **has not set a roadmap**, they will be prompted to:  
  - **Choose a programming language** (C#, Java, Python).  
  - **Select an experience level** (Beginner, Intermediate, Advanced).  
- The system will **assign a learning roadmap** based on their selections.  
- Users can **modify their roadmap** anytime.  

---

### **3️⃣ Admin Panel**  
Admins have account management privileges:  
```
=== Admin Panel ===
1. View All Users
2. Manage Users
3. Logout
```
- **View all registered users**.  
- **Add or remove users**.  
- **Logout** when done managing users.  

---

## **Project Structure**  
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
 ┣ 📂 UI  
 ┃ ┣ 📜 Menu.cs  
 ┃ ┣ 📜 InputValidation.cs  
 ┣ 📜 Program.cs  
```

---

## **Input Validation & Security**  
✔ **Passwords must meet security criteria:**  
   - At least **8 characters**  
   - Contains **uppercase & lowercase letters**  
   - Includes **at least one digit**  
   - Contains **a special character**  
✔ **Passwords are hashed using SHA-256**  
✔ **Invalid inputs are rejected with clear messages**  

---

## **How to Run**  
1️⃣ Open **Visual Studio Code**  
2️⃣ Open the **TechLearningRoadmap** project  
3️⃣ Run the application (`dotnet run`)  
4️⃣ Follow the menu prompts  

---

## **Future Enhancements**  
✔ **Database Integration** - Store user progress permanently.  
✔ **Graphical User Interface (GUI)** - Using **WinForms** for a better user experience.  
✔ **Expand Learning Resources** - Fetch more dynamic content from APIs.  

---

## **Conclusion**  
This project started as a **simple learning roadmap system** and evolved into a **structured, secure, and fully functional** application. By implementing authentication, password hashing, and strong input validation, we ensured a **safe and user-friendly** experience. The system is modular, making it easy to expand in the future.
