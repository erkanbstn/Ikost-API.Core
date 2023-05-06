# IkostProje-API.Core
Including .Net Core 6.0, MVC, API, Code First, Entity Framework Core Transactions.



1- IkostProjeMVC İçin Bağlantı Dizesini Kendi Bağlantınıza Göre Models.AppContext.Context Class ındaki "OnConfiguring" Methodunda
   Revize Ettikten Sonra PowerShell Üzerinden "Update Database" Komutunu Kullanmanız Yeterli.
   
2- IkostSipayAPI İçin API Token i Otomatik Olarak Oluşturan Kodları Çalıştırdığımda API Üzerinden Hata Aldığım İçin
   Manuel Olarak Token Oluşturup Back-End Tarafında da Revize Etmek Zorunda Kaldım. 
   Siz de IkostSipayController İçerisindeki "GetAuthorizationToken" Methodunu Kendi Tokeninize Göre Revize Etmelisiniz.
