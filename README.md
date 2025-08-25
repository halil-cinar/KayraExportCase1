# KayraExport Case 1 – Backend Developer Task

Bu proje, **KayraExport** şirketi için **1. aşama backend case** çalışmasıdır.  
Amaç: temel backend geliştirme prensiplerini, servis yapısını, REST API oluşturma becerisini ve veritabanı işlemlerini göstermek.

---

## 🚀 Proje Özeti
- **Teknolojiler:**
  - .NET 8 (ASP.NET Core Web API)
  - C#
  - PostgreSQL
  - Entity Framework Core
- **Mimari:** Katmanlı yapı (Domain-DataAccess-Business-API)
- **Özellikler:**
  - Ürün ekleme (POST)
  - Ürün listeleme (GET, sayfalı)
  - Ürün detay (GET by Id)
  - Ürün silme (DELETE)
- **Dokümantasyon:** Swagger UI üzerinden otomatik olarak erişilebilir.

---

## ⚙️ Kurulum ve Çalıştırma

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/kayraexport/case1-backend.git
   cd case1-backend
   ```

2. **Bağımlılıkları yükleyin:**
   ```bash
   dotnet restore
   ```

3. **Veritabanı bağlantısını ayarlayın:**
   - Proje online PostgreSQL sunucusu kullanmaktadır.
   - Eğer çalışmazsa, `appsettings.json` içindeki **DefaultConnection** alanını kendi PostgreSQL bağlantı string’inizle güncelleyin:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=KayraExportDb;Username=postgres;Password=yourpassword"
     }
     ```

4. **Migration çalıştırın (eğer connection string değiştiyse):**
   ```bash
   dotnet ef database update
   ```
   yada paket yönetici konsolunda 
   ```bash
   Update-Database
   ```

5. **Projeyi başlatın:**
   ```bash
   dotnet run
   ```

6. **Swagger dokümantasyonuna erişin:**
   - Tarayıcıda açın:  
     👉 [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 📑 API Endpointleri

| HTTP Method | Endpoint              | Açıklama               |
|-------------|----------------------|------------------------|
| POST        | `/api/product`       | Yeni ürün ekler        |
| GET         | `/api/product`       | Ürünleri listeler      |
| GET         | `/api/product/{id}`  | Ürün detay döner       |
| DELETE      | `/api/product/{id}`  | Ürün siler             |

---



## 📝 Notlar
- Proje **case çalışması** niteliğindedir.
- Çalıştırmak için `dotnet run` komutu yeterlidir.
- PostgreSQL bağlantısı çalışmazsa `appsettings.json` üzerinden kendi bağlantınızı tanımlayın.
- Projeye başlama zamanı *11:00* | Proje bitiş zamanı *13:30*
