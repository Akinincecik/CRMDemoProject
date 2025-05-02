# CRMDemoProject

## 📘 Proje Açıklaması

**CRMDemoProject**, öğrenci kayıt süreçlerini etkin bir şekilde yönetmek amacıyla geliştirilmiş, modüler ve ölçeklenebilir bir CRM uygulamasıdır. Proje, veri bütünlüğünü sağlamak ve sistem performansını artırmak için **Stored Procedures**, **Utility sınıfları** ve **katmanlı mimari** gibi gelişmiş teknikler kullanılarak tasarlanmıştır.

## 🎯 Proje Amacı

- Öğrenci kayıt işlemlerini güvenli ve hatasız bir şekilde gerçekleştirmek.
- Kayıt verilerini e-posta gönderimine uygun formatta veritabanında saklamak.
- Veritabanı işlemlerini optimize etmek için Stored Procedures kullanmak.
- Kod tekrarını önlemek ve bakım kolaylığı sağlamak için yardımcı sınıflar (Utils) oluşturmak.
- Uygulamanın farklı bileşenleri arasında net bir ayrım sağlayarak modüler bir yapı oluşturmak.

## 🧱 Proje Mimarisi

Proje, aşağıdaki katmanlardan oluşmaktadır:

- **Presentation Layer**: Kullanıcı arayüzü ve kullanıcı etkileşimlerinin yönetildiği katman.
- **Business Logic Layer (BLL)**: Uygulama iş kurallarının ve iş mantığının tanımlandığı katman.
- **Data Access Layer (DAL)**: Veritabanı işlemlerinin gerçekleştirildiği katman.
- **Utilities**: Ortak işlemler için yardımcı sınıfların bulunduğu katman.

## 🗂️ Önemli Klasörler ve Bileşenler

### 📁 `Utils` Klasörü

Bu klasör, uygulama genelinde kullanılan yardımcı sınıfları içerir. Örneğin:

- **SQLUtils.cs**: Stored Procedure çağrılarını ve SQL işlemlerini yöneten sınıf.
- **EmailHelper.cs**: E-posta gönderim işlemlerini kolaylaştıran yardımcı sınıf.
- **Logger.cs**: Uygulama içi loglama işlemlerini yöneten sınıf.

### 📁 `SQLUtils` Yapısı

`SQLUtils` sınıfı, veritabanı işlemlerini merkezi bir noktadan yönetmek için tasarlanmıştır. Bu yapı sayesinde:

- Stored Procedure çağrıları standart hale getirilir.
- SQL bağlantı yönetimi merkezi olarak kontrol edilir.
- Hata yönetimi ve loglama işlemleri entegre bir şekilde gerçekleştirilir.

### 🗃️ Veritabanı Yapısı

Veritabanı, aşağıdaki önemli bileşenleri içerir:

- **Tablolar**: Öğrenci bilgileri, kayıt detayları ve e-posta gönderim verilerini saklayan tablolar.
- **Stored Procedures**: Veri ekleme, güncelleme, silme ve sorgulama işlemlerini gerçekleştiren prosedürler.
- **Triggerlar**: Belirli veritabanı olaylarına tepki olarak çalışan tetikleyiciler (varsa).

### 📧 E-posta Entegrasyonu

Kayıt işlemleri sonrasında, ilgili veriler e-posta gönderimine uygun formatta veritabanında saklanır. Bu sayede:

- E-posta gönderim işlemleri asenkron olarak gerçekleştirilebilir.
- E-posta içerikleri dinamik olarak oluşturulabilir.
- Gönderim geçmişi ve durumu takip edilebilir.

## 🛠️ Kullanılan Teknolojiler

- **.NET Framework / .NET Core**: Uygulama geliştirme platformu.
- **C#**: Uygulama programlama dili.
- **SQL Server**: Veritabanı yönetim sistemi.
- **Stored Procedures**: Veritabanı işlemlerini optimize etmek için kullanılan prosedürler.
- **Entity Framework / ADO.NET**: Veritabanı erişim teknolojileri.
- **IIS**: Uygulamanın barındırıldığı web sunucusu.
- **SMTP**: E-posta gönderim protokolü.

## 🚀 Kurulum ve Çalıştırma

1. **Projeyi Klonlayın**:
   ```bash
   git clone https://github.com/Akinincecik/CRMDemoProject.git
------------------------------------------------------------------------------

# CRMDemoProject

## 📘 Project Description

**CRMDemoProject** is a modular and scalable CRM application developed to efficiently manage student registration processes. The project is designed using advanced techniques such as **Stored Procedures**, **Utility classes**, and **layered architecture** to ensure data integrity and improve system performance.

## 🎯 Project Goals

- To perform student registration operations securely and accurately.
- To store registration data in the database in a format suitable for email delivery.
- To optimize database operations using stored procedures.
- To reduce code duplication and provide easy maintenance with utility classes (Utils).
- To create a modular structure by separating different components of the application.

## 🧱 Project Architecture

The project is composed of the following layers:

- **Presentation Layer**: Handles the user interface and interactions.
- **Business Logic Layer (BLL)**: Contains the business rules and application logic.
- **Data Access Layer (DAL)**: Responsible for interacting with the database.
- **Utilities**: Contains shared helper classes used across the application.

## 🗂️ Key Folders and Components

### 📁 `Utils` Folder

This folder includes helper classes used throughout the application. For example:

- **SQLUtils.cs**: Manages SQL operations and stored procedure calls.
- **EmailHelper.cs**: Simplifies email sending operations.
- **Logger.cs**: Handles in-app logging and error tracking.

### 📁 `SQLUtils` Structure

The `SQLUtils` class is designed to manage all database operations from a central point. This structure provides:

- Standardized stored procedure calls.
- Centralized SQL connection management.
- Integrated error handling and logging.

### 🗃️ Database Structure

The database includes the following core components:

- **Tables**: Store student information, registration details, and email delivery data.
- **Stored Procedures**: Handle insert, update, delete, and fetch operations efficiently.
- **Triggers**: Respond to specific database events (if implemented).

### 📧 Email Integration

After the registration process, related data is stored in the database in a format suitable for email transmission. This enables:

- Asynchronous email sending.
- Dynamic email content generation.
- Email history and status tracking.

## 🛠️ Technologies Used

- **.NET Framework / .NET Core**: Application development platform.
- **C#**: Programming language.
- **SQL Server**: Database management system.
- **Stored Procedures**: Used for optimizing database transactions.
- **Entity Framework / ADO.NET**: Data access technologies.
- **IIS**: Web server for hosting the application.
- **SMTP**: Protocol for sending emails.

## 🚀 Installation and Running the Project

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Akinincecik/CRMDemoProject.git
