# 🧼 Halı Yıkama Otomasyonu (Carpet Cleaning Automation)

**Halı Yıkama Otomasyonu**, C# ve Windows Forms kullanılarak geliştirilmiş, küçük ve orta ölçekli işletmeler için tasarlanmış bir müşteri ve sipariş takip sistemidir. Proje, Nesne Yönelimli Programlama (OOP) prensipleri kullanılarak, siparişlerin alınmasından teslim edilmesine kadar olan süreci dijitalleştirir.

## 🚀 Proje Hakkında

Bu proje, bir halı yıkama firmasının günlük operasyonlarını (müşteri kaydı, halı kabulü, fiyat hesaplama ve teslimat durumu) yönetmek amacıyla geliştirilmiştir. Veriler, çalışma zamanında (Runtime) dinamik **Generic List** yapıları üzerinde tutularak, bellek içi (In-Memory) veri yönetimi simüle edilmiştir.

## 🛠️ Teknolojiler ve Mimari

* **Dil:** C#
* **Platform:** .NET (Windows Forms)
* **Veri Yapıları:** `List<T>` koleksiyonları ile ilişkisel veri takibi.
* **Mimari:** Event-Driven (Olay Güdümlü) Mimari.

## ⚙️ Temel Özellikler

### 👥 Müşteri Yönetimi
* Ad, Soyad, Telefon ve Adres bilgileri ile yeni müşteri kaydı.
* Müşterilerin ComboBox üzerinde dinamik listelenmesi.

### 🧺 Sipariş ve Halı Takibi
* **İlişkisel Kayıt:** Halılar doğrudan seçilen müşteriye nesne olarak (`Musteri.Halilar.Add()`) bağlanır.
* **Otomatik Fiyatlandırma:** Girilen metrekareye göre tutar, sınıf içindeki *Read-Only Property* ile anlık hesaplanır.
* **Tarih Yönetimi:** Alım tarihi ve tahmini teslim tarihi takibi.

### ✅ Durum Yönetimi (Workflow)
Sistemde iki aşamalı bir durum makinesi (state machine) bulunur:
1.  **Yıkamada:** Yeni eklenen halılar "Yıkamada Olan Halılar" listesine düşer.
2.  **Teslim Edildi:** İşlemi biten halılar "Teslim Et" butonu ile statü değiştirerek (boolean flag) "Teslim Edilenler" listesine taşınır.

## 📂 Sınıf Yapısı (Code Structure)

Proje, nesneler arası ilişkiyi (Association) temel alır:

* **`Musteri` Sınıfı:** Müşteri bilgilerini ve o müşteriye ait halıları tutan bir `List<Hali>` koleksiyonunu barındırır (1-to-Many İlişki).
* **`Hali` Sınıfı:** Metrekare, tarih bilgileri ve teslimat durumunu (`bool teslimEdildi`) tutar.
* **`Form1`:** Kullanıcı arayüzü olaylarını ve listeler arası veri akışını yönetir.

## 📷 Ekran Görüntüsü

<img src="https://github.com/user-attachments/assets/9d7ed5c3-5461-4a3f-8f2c-5db130353cb6" width="100%">


---
Developed by **Firdevs Kara** | Computer Engineering Student 💻
