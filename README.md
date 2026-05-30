# Restoran Sipariş Otomasyon Sistemi

Bu proje, Nesne Yönelimli Programlama (OOP) prensiplerinin gerçek hayat senaryosuna uyarlandığı bir C# konsol uygulamasıdır. Kullanıcıların (garsonların) menüden dinamik olarak ürün ekleyip çıkarabildiği, siparişin toplam fiyatını ve hazırlık süresini hesaplayarak detaylı bir adisyon (fiş) üreten bir sistemdir.

## Projenin Amacı ve Öğrenim Çıktıları

Bu uygulamanın temel amacı çalışan bir kod yazmanın ötesinde; temiz, genişletilebilir ve modüler bir yazılım mimarisi kurgulamaktır. Sistem tasarlanırken OOP'nin 4 temel taşı aktif olarak kullanılmıştır:

* **Abstraction (Soyutlama):** Siparişin temel kurallarını belirleyen `IOrder` arayüzü (interface) ve ürünlerin iskeletini oluşturan `abstract Product` sınıfı kullanıldı.
* **Inheritance (Kalıtım):** `Food` (Yemek), `Drink` (İçecek) ve `Dessert` (Tatlı) sınıfları temel `Product` sınıfından miras alınarak türetildi.
* **Polymorphism (Çok Biçimlilik):** Türetilen sınıflar, temel sınıftaki boş metotları (`CalculatePreparationTime` vb.) `override` ederek ezdi ve her ürün grubu kendi hazırlık süresi algoritmasını çalıştırdı.
* **Encapsulation (Kapsülleme):** `Order` sınıfı içerisindeki ürünler listesi (`private List<Product> _products`) dış müdahalelere kapatılarak sadece ilgili metotlar üzerinden erişime açıldı.

## Temel Özellikler

- **Dinamik Sipariş Yönetimi:** Siparişe anlık olarak ürün eklenebilir veya çıkarılabilir.
- **Akıllı Süre Hesaplama:** Seçilen ürünlerin kategorisine (yemek, tatlı, içecek vb.) göre servis/süsleme payları otomatik hesaplanıp tahmini hazırlık süresi müşteriye sunulur.
- **Hata Yönetimi:** Kullanıcının (garsonun) yanlış veri girmesini (örn: sayı yerine harf tuşlanması) engelleyen `TryParse` veri doğrulama güvenlik önlemleri içerir.
- **Detaylı Fiş (Receipt) Çıktısı:** Sipariş tamamlandığında konsola ürün bazlı ve genel toplamlı bir adisyon yazdırılır.

## Teknolojiler

* C#
* .NET Core / .NET Framework
* Visual Studio
