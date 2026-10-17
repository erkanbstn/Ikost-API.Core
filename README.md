# Ikost

Bayi ve sipariş ekranları olan web uygulaması ile ödeme API'si.

## Ne var

MVC tarafında bayi ve sipariş controller'ları, API tarafında ödeme uçları vardır. Bağlantı dizesi `OnConfiguring` içindedir; kendi sunucunuza göre değiştirin.

## Çalıştırma

Çözümdeki web veya API projesinde şu komutu çalıştırın:

```powershell
dotnet run
```

Veritabanı kullanan projelerde bağlantı dizesini kendi ortamınıza göre güncelleyin.

## Yığın

.NET 6, ASP.NET Core MVC, Entity Framework Core ve SQL Server.