# 🧩 GenerateSVG - SVG Oluşturma ve Matris Yerleştirme Aracı

Bu proje, kullanıcıların basit SVG şekilleri oluşturmasına ve bu SVG’leri matris hücrelerine entegre ederek görsel test benzeri yapılar tasarlamasına olanak tanıyan bir ASP.NET Core uygulamasıdır.

---

## 🚀 Özellikler

- Farklı şekil, renk, doluluk ve dönüş açısıyla SVG üretimi
- SVG'lerin fiziksel olarak `wwwroot/svgs` klasörüne kaydedilmesi
- Aynı SVG birden fazla kez üretilmez, tekrar edenler filtrelenir
- Oluşturulan SVG'ler listelenir ve kullanıcı seçim yapabilir
- Matris (2x2 veya 3x3) yapısı oluşturularak SVG'ler hücrelere yerleştirilir
- Responsive, kullanıcı dostu bir arayüz

---

## 🛠️ Kurulum

### Gereksinimler
- .NET 8.0 SDK
- Visual Studio veya Rider
- SQLite

### Adımlar

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/kullaniciadi/GenerateSVG.git
