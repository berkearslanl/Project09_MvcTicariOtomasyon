# MvcTicariOtomasyon - Kurumsal Ölçekli Ticari Otomasyon ve Cari Yönetim Sistemi 📊💼

Bu proje, **M&Y Yazılım Eğitim Akademi Danışmanlık** bünyesinde, **Murat Yücedağ** hocamızın rehberliğinde gerçekleştirilen yoğun yazılım geliştirme bootcamp sürecinin **9. projesi** olarak geliştirilmiştir. Bir işletmenin tüm operasyonel faaliyetlerini (Stok, Satış, Cari, Fatura, Personel, Kargo, Grafiksel Raporlama, Şirket İçi İletişim) dijitalleştirmek amacıyla tasarlanmış modern bir web otomasyon sistemidir.

---

## 🚀 Öne Çıkan Teknik Özellikler & Mimari Yapı

### 1. Veritabanı Mimarisi ve Veri Yönetimi
* **Entity Framework Code First:** Veritabanı tabloları, ilişkileri ve kısıtlamaları tamamen C# sınıfları üzerinden ayağa kaldırılmış, `Migrations` mekanizması aktif olarak kullanılmıştır.
* **İlişkisel Veritabanı Optimizasyonu:** Sınıflar arası One-to-Many ilişkiler `virtual` property'ler ve `DbContext` üzerinde `DbSet` tanımlamalarıyla optimize edilmiştir.
* **SQL Triggers (Veritabanı Tetikleyicileri):** Satış yapıldığında ürün stokunun otomatik düşmesi ve fatura kalemlerinde değişiklik yapıldığında toplam fatura tutarının otomatik hesaplanması gibi kritik işlemler veritabanı seviyesinde asenkron tetikleyicilerle çözülmüştür.

### 2. Gelişmiş İstatistik ve İş Zekası (Dashboard)
* **Derinlemesine LINQ Sorguları:** İşletme performansını ölçmek amacıyla `Group By`, alt sorgular (Subqueries) ve `Distinct` fonksiyonları içeren karmaşık LINQ sorguları kurgulanmıştır.
* **Google Charts & Chart.js Entegrasyonu:** Veritabanından dinamik olarak çekilen veriler; Pie Chart, Line Chart ve Column Chart türleriyle görselleştirilmiştir.
* **Dinamik Raporlama:** `DataTable` entegrasyonu sayesinde sistemdeki tüm ticari listeler tek tıkla **PDF** ve **Excel** formatlarına export edilebilmektedir.

### 3. İnteraktif UI/UX ve Dinamik Formlar
* **Dinamik Fatura Girişi:** Javascript ve Ajax teknolojileri kullanılarak, kullanıcının sayfa yenilemeden tek bir ekranda alt alta sınırsız fatura kalemi ekleyebileceği gelişmiş arayüz mimarisi.
* **Cascading Dropdown:** Kategori seçimine bağlı olarak ürün listesinin dinamik olarak güncellenmesini sağlayan iç içe betikler.
* **Sweet Alert & Popups:** Kullanıcı etkileşimlerini (silme, güncelleme, uyarı) modern hale getiren interaktif popup pencereleri.
* **File Upload:** Personel kartlarında görsellerin dinamik olarak sunucuya yüklenmesi ve güncellenmesi süreçleri.

### 4. Güvenlik, Kimlik Doğrulama ve Rolleme
* **Forms Authentication & Oturum Yönetimi:** `Session` tabanlı kullanıcı takibi ve güvenli `LogOut` mekanizması.
* **Role-Based Authorization (Rol Bazlı Yetkilendirme):** Hem **Admin** hem de **Cari (Müşteri)** için iki ayrı panel. Admin tarafında kullanıcı rollerine göre dinamik menü gizleme ve sayfa bazlı (`Authorize`) kısıtlama mimarisi.

### 5. Entegre Alt Modüller
* **Kargo Takip Sistemi:** Algoritmik olarak benzersiz kargo takip kodları üreten ve bu kodlarla müşterilerin kargo detaylarına ve hareketlerine ulaşmasını sağlayan bağımsız modül.
* **Şirket İçi Mesajlaşma (Mail UI):** Gelen/Giden mesaj kutuları, okunma durumları ve anlık mesaj sayaçları ile zenginleştirilmiş mini-posta istemcisi.
* **QR Code Entegrasyonu:** Ticari verilerin veya kargo kodlarının hızlı takibi için sistem içerisinde dinamik QR Code DLL üretimi.

---

## 🛠️ Kullanılan Teknolojiler

* **Backend:** C#, ASP.NET MVC 5, .NET Framework 4.8
* **ORM:** Entity Framework 6 (Code First)
* **Veritabanı:** Microsoft SQL Server
* **Frontend:** HTML5, CSS3, Bootstrap, Font Awesome, JavaScript, jQuery
* **Kütüphaneler & Araçlar:** DataTable Extensions, QR Code DLL, SweetAlert, PagedList, Google Charts

---

## 📂 Proje Modülleri

* **Ürün & Kategori Yönetimi:** Stok takibi, kritik seviye kontrolleri, kategorilere göre filtreleme.
* **Cari (Müşteri) Paneli:** Müşterinin kendi satın alma geçmişini, profil bilgilerini, şirket duyurularını ve mesajlarını görebileceği özel alan.
* **Departman & Personel Yönetimi:** Şirket içi hiyerarşi, personele bağlı satış performans analizleri.
* **Fatura Modülü:** Dinamik kalem girişli kurumsal fatura kesme ve detaylandırma süreçleri.
* **Yapılacaklar (To-Do List):** Admin için anlık ajanda ve görev takip kartları.

---

## 🙏 Teşekkür

Bu projenin hayata geçmesindeki değerli eğitimleri, sektörel tecrübeleri ve bizlere kazandırdığı harika vizyon için kıymetli eğitmenimiz **Murat Yücedağ**'a ve **M&Y Yazılım Eğitim Akademi Danışmanlık** ailesine teşekkürlerimi sunarım.

---

## 📸 Ekran Görüntüleri
<img width="1920" height="912" alt="girisyap" src="https://github.com/user-attachments/assets/1220b7c5-96b0-4458-86ed-43b1b993e0de" />
<img width="1892" height="913" alt="ürünler" src="https://github.com/user-attachments/assets/b96c56ba-d3a9-4fbd-ac07-78138cc43f8d" />
<img width="1897" height="910" alt="üründetay" src="https://github.com/user-attachments/assets/203767be-eca6-4f86-b721-ea2b45bb71e7" />
<img width="1915" height="911" alt="satis" src="https://github.com/user-attachments/assets/ff59585d-e506-4adc-ad2d-4b9fdbd4f775" />
<img width="1908" height="907" alt="galeri" src="https://github.com/user-attachments/assets/ae650720-d05e-4099-bcf6-9d245d08c8db" />
<img width="1910" height="907" alt="faturalar" src="https://github.com/user-attachments/assets/4fe85220-d248-41cc-b9a8-301cb2fee471" />
<img width="1907" height="898" alt="yapilacaklar" src="https://github.com/user-attachments/assets/eab2bdfc-9507-4072-bc84-03b7fefac1f0" />
<img width="1907" height="901" alt="istatistik" src="https://github.com/user-attachments/assets/d93e79a4-52b1-410e-b4c9-40ef9b3af865" />
<img width="1890" height="902" alt="profilim" src="https://github.com/user-attachments/assets/babf5a8e-10ee-4def-a820-950193fbf454" />
<img width="1900" height="907" alt="mesajlar" src="https://github.com/user-attachments/assets/f99c5990-4e35-4ba4-b1fe-86c0443b0c6d" />
<img width="1907" height="907" alt="kargotakip" src="https://github.com/user-attachments/assets/dbe8d7f4-9c8f-4373-bdff-3486cdaed8c3" />
<img width="1905" height="907" alt="hatasayfasi" src="https://github.com/user-attachments/assets/9f60d2d9-eae7-496e-b51b-32109f6452f7" />
<img width="1600" height="1190" alt="sertifika" src="https://github.com/user-attachments/assets/0254771b-4460-44b9-a1c4-8cb3720f5284" />
