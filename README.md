# Projede Git hatalari var eger tam haline erismek istiyorsaniz lutfen iletisime gecin 🚗 Rent A Car — .NET Core + CQRS (Gemini & RapidAPI Entegre)

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

<summary><b>--</b></summary>

<img width="2560" height="1440" alt="Screenshot 2025-09-10 220003" src="https://github.com/user-attachments/assets/2205e72f-529c-4574-a21a-98d80b291be7" />
<img width="2560" height="1440" alt="Screenshot 2025-09-10 220025" src="https://github.com/user-attachments/assets/c74eaa91-c79a-4671-8cdb-6b66e5128a1c" />

<img width="2560" height="1440" alt="333" src="https://github.com/user-attachments/assets/3912eb5e-3015-44c6-bd94-88c988109231" />

<img width="2560" height="1440" alt="444" src="https://github.com/user-attachments/assets/52d0e773-cddb-49c9-b8d0-d9fbbe005cae" />
<img width="2560" height="1440" alt="555" src="https://github.com/user-attachments/assets/6a7d48e1-da22-4919-b936-379c6eb66ea5" />
<img width="2560" height="1440" alt="666" src="https://github.com/user-attachments/assets/d47b7e44-c707-43e3-8354-7b5d7675c861" />
<img width="2560" height="1440" alt="666" src="https://github.com/user-attachments/assets/d1770032-e4cd-435f-ae45-d456a6df5438" />
<img width="2560" height="1440" alt="777" src="https://github.com/user-attachments/assets/f82fa62d-450c-4bf6-b2d3-fb3f52a3308b" />
<img width="2560" height="1440" alt="888" src="https://github.com/user-attachments/assets/bfc9e1be-be58-4fa3-b38b-25644cb11856" />
<img width="2560" height="1440" alt="999" src="https://github.com/user-attachments/assets/663ed525-35fe-4ad5-8cbe-b3003ecff164" />
<img width="2560" height="1440" alt="1000" src="https://github.com/user-attachments/assets/715693fe-3344-4df9-b540-61808b54d8f7" />

