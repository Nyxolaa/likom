Bu proje bir .NET 8 uygulamasıdır. Proje, çeşitli iş mantığı ve veri erişim katmanları içerir.

## Başlangıç

### Gereksinimler

- .NET 8 SDK
- SQL Server

### Port Ayarları

Varsayılan olarak, uygulama `https://localhost:7288` adresinde çalışacak şekilde yapılandırılmıştır. Portu değiştirmek isterseniz, `Program.cs` dosyasındaki `builder.WebHost.UseUrls("https://localhost:7288");` satırını güncelleyebilirsiniz.

### Migration ve Veritabanı Ayarları

Veritabanı migration işlemleri için aşağıdaki adımları izleyin:

1. **Migration Oluşturma:**
   ```package manager console
   Add-Migration InitialCreate

1. **Veritabanını Güncelleme:**
    ```package manager console
    Update-Database

### Yapılandırma
Uygulamanın yapılandırması appsettings.json dosyasında bulunur. Varsayılan ayarlar şu şekildedir:
    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=localhost;Initial Catalog=likomDb;Integrated Security=True;Trust Server Certificate=True"
    },
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
    }

### CORS (Cross-Origin Resource Sharing) Ayarları
Proje, tüm kaynaklardan gelen istekleri kabul edecek şekilde CORS yapılandırmasına sahiptir. Bu ayarları Program.cs dosyasında bulabilirsiniz:
    ```csharp
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });

### Swagger UI
Swagger UI, uygulamanın geliştirme ortamında test edilmesini sağlar. Geliştirme ortamında Swagger UI'yi etkinleştirmek için Program.cs dosyasındaki şu kodu kullanabilirsiniz:
    ```csharp
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

### Açıklamalar:
Proje Yapısı
- Controllers: API controller'larını içerir.
- Models: Veri modellerini içerir.
- Services: İş mantığı ve hizmetleri içerir.
- Repositories: Veri erişim katmanını içerir.
