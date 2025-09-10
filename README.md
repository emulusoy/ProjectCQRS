# 🚗 Rent A Car — .NET Core + CQRS (Gemini & RapidAPI Entegre)

Araç kiralama akışını uçtan uca gösteren örnek proje.  
Kullanıcı tarafında **şehir/araç seçimi → özet** (Gemini ile mesafe/süre/yakıt + **yakıt TL maliyeti** + **toplam tutar**),  
yönetim tarafında ise **modal tabanlı CRUD** ve **Dashboard** (Avrupa yakıt fiyatları, son yorumlar, öne çıkan araçlar) bulunur.  
İletişim formu **DB’ye kaydolur** ve **Gemini destekli otomatik e-posta** yanıtı gönderilir.

---

## 🔎 Kullanıcı Akışı
- 🔍 **Akıllı seçim kutuları** (aranabilir/kaydırılabilir) ile **Araç & Şehir** seçimi

### 🧾 Reservation/Summary
- 🤖 **Gemini** ile tahmini **mesafe (km)**, **süre (saat)** ve **yakıt tüketimi (L/100km)**
- ⛽ **2025 Eylül Türkiye benzin fiyatına** (konfigürasyondan) göre **yakıt TL maliyeti**
- 📅 **Gün sayısı × günlük fiyat** → **kiralama tutarı** ve **toplam maliyet**
- ⭐ Araç detayında **kullanıcı yorumları** ve **ortalama puan**

---

## 🛠️ Yönetim (Admin)
- 🧩 **Modal tabanlı CRUD** (ör: Kategori, Araç)

### 📊 Dashboard
- 🌍 RapidAPI’den **Avrupa yakıt fiyatları**
- 💬 **Son yorumlar** listesi
- 🚘 **Öne çıkan araçlar** (büyük kartlar)
- 📈 **Mini istatistikler** (araç sayısı, aktif rezervasyon, ortalama puan)

---

## ✉️ İletişim & Otomatik Yanıt
- 🗃️ İletişim formu gönderimleri **veritabanına** kaydolur
- 🤖 **Gemini** ile içeriğe uygun **otomatik e-posta** yanıtı (**Gmail SMTP**)

---

## 🧰 Teknolojiler
- .NET Core / ASP.NET MVC
- EF Core, CQRS (Command/Query/Handler)
- Google Gemini API
- RapidAPI — `gas-price.p.rapidapi.com`
- Gmail SMTP (Uygulama şifresiyle)
- Bootstrap 5, Font Awesome

---

## 🖥️ Ekranlar
- **Home** → Header rezervasyon kutusu (Car/City seçimleri, tarih)
- **Car/Index** → Araç kartları grid
- **Reservation/Summary** → Gemini tahminleri + yakıt TL, kiralama ve toplam
- **Admin/Dashboard** → Gas price kartları, yorumlar, öne çıkanlar
- **Admin/*List** → Modal CRUD sayfaları (Kategori, Araç, vs.)
- **Contact** → Form gönderimi → DB + otomatik e-posta

---

## 🖼️ Projeye Ait Fotoğraflar

<details>
<summary><b>Görselleri göster (10)</b></summary>

<p align="center">
  <img src="https://github.com/user-attachments/assets/dade5051-17bb-40ca-925d-7fe866bd2caf" alt="SS 1000" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/7db2c774-bad7-4e1f-88de-34406ea04c42" alt="SS 999" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/862fbbf7-d814-41c4-a5f9-444939c1ab87" alt="SS 888" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/e14b7180-82de-4567-b8ee-773c5a37adb8" alt="SS 777" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/9e1c78a3-455e-4f5e-822c-2f0d1da63262" alt="SS 666" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/3958b39e-46c6-4053-9b69-c49cb9ec1aff" alt="SS 555" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/bc5fa9d6-83ed-4ee7-879e-e887a38e50e0" alt="SS 444" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/c1d5402c-8d6c-43f8-804a-408c20808415" alt="SS 333" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/efe316d7-a4d1-4fca-850f-578e9c161a3a" alt="SS 222" width="800" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/f51ad09b-ad53-4c8a-bbd7-cc7ddcabf455" alt="SS 111" width="800" />
</p>

</details>
