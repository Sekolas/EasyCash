# EasyCash Banka Web Projesi
## Projenin Genel Amacı

###
EasyCash; banka web siteleri mantığında işleyen gerçek dünya senaryolarına uygun hazırlanmış bir web projesidir. Bu sitede Admin, Müşteri ve Ana Sayfa için ayrı paneller hazırlanmış olup Identity ile oturum işlemleri gerçekleştirilmiştir. 
Kayıt Ol sayfası aracılığıyla kayıt olan kullanıcı Müşteri Paneli'ne yönlendirilmektedir. Kullanıcı bu panelde tüm hesaplarını (Dolar, Euro, TL) görebilir, kredi/banka kartı başvurusunda bulunabilir, sistemde kayıtlı
olan bir IBAN'a para transferi gerçekleştirebilir, elektrik faturası ödeme işlemi gerçekleştirebilir vb.

ASP.NET Core 6.0 MVC kullanarak geliştirdiğim projemde dinamik veritabanı işlemleri için Entity Framework Code First kullanılmıştır.
###

# Kullanılan Teknolojiler
- Asp.Net Core 6.0 MVC
- Katmanlı Mimari
- MSSQL Server
- Entity Framework Code First
- Identity
- Html, Css
- JavaScript
- AJAX
- Bootstrap
- Sweet Alert
- QRCode Generator
- Döviz Kurları Apisi
- AutoMapper
  
# Projenin Öne Çıkan Özellikleri
- Müşteri paneli ekranında(Dashboard) güncel döviz kuru bilgilerini grafikte görüntüleyebilme
- Veritabanı işlemleri için Entity Framework Code First kullanımı
- Müşteri Paneli
- Identity ile Giriş ve Kayıt Olma işlemleri
- Profil ayarları sayfası
- Giriş yapan kişinin hesaplarını görüntüleyebilmesi
- Giriş yapan kişinin kendi hesabının IBAN'ını kopyalayabilmesi işlemi
- Kredi/Banka kartı başvurusunda bulunabilme
- Sistemde kayıtlı IBAN'a para transferi yapabilme
- Elektrik Faturası ödeyebilme işlemleri
- QR Kodu oluşturabilme ekranı
- Kayıt olunan email'e kod gönderme yaparak Email onaylama işlemi gerçekleştirme


# Projenin Görselleri

### Ana Sayfa 
![Ana ekran](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/home.png)

### İletişim Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/contact.png)

### Giriş Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/login.png)

### Müşteri Paneli - Dashboard
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/dashboard.png)

### Müşteri Paneli - Profil Ayarları Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/profileUpdate.png)

### Müşteri Paneli - Son İşlemler Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/sonIslemler.png)

### Müşteri Paneli - QR Kod Oluşturma Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/QRcode.png)

### Müşteri Paneli - Hesaplar ve IBAN Kopyalama
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/IBAN.png)

### Müşteri Paneli - Giriş Yapan Kişinin Tüm Hesapları
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/loginCustomerAccount.png)

### Müşteri Paneli - Yeni Hesap Açma Talebi Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/newAccount.png)

### Müşteri Paneli - Para Transferi Sayfası
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/paraTransfer.png)

### Müşteri Paneli - Elektrik Faturası Ödeme Sayfası (Adım 1)
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/BorcSorgula.png)

### Müşteri Paneli - Elektrik Faturası Ödeme Sayfası (Borç Yoksa)
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/BorcSorgula2-1.png)

### Müşteri Paneli - Elektrik Faturası Ödeme Sayfası (Borç Varsa Adım 2)
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/BorcSorgula2.png)

### Müşteri Paneli - Elektrik Faturası Ödeme Sayfası (Adım 3)
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/BorcSorgula3.png)

### Müşteri Paneli - Elektrik Faturası Ödeme Sayfası (Adım 4)
![Ana sayfa](https://github.com/busraozdemir0/EasyCashProject/blob/master/EasyCashProject.PresentationLayer/wwwroot/ProjectScreeenshots/BorcSorgula4.png)
