# YMH219 - Key Event Logger (Eğitsel Klavye Olay İzleyici)

## Proje Açıklaması
Nesne Tabanlı Programlama (YMH 219) dersi kapsamında geliştirilmiş, yalnızca kendi uygulama penceresi aktifken (odaktayken) gerçekleşen `KeyDown` ve `KeyUp` olaylarını zaman damgasıyla listeleyen eğitsel bir Windows Forms uygulamasıdır.

> **Güvenlik Sınırı:** Bu proje kesinlikle sistem geneli (global hook) bir keylogger değildir. Arka planda çalışmaz, başka uygulamalardan veri toplamaz ve ağ üzerinden veri göndermez.

## Kullanılan Teknoloji ve Paketler
- C# / .NET 8.0 (Windows Forms)
- `System.IO` (`StreamWriter`) ile yerel `.txt` dışa aktarma

## Kurulum ve Çalıştırma Adımları
1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/255541002AsimGokalp/YMH219-KeyEventLogger.git
   ```
2. `YMH219-KeyEventLogger.sln` dosyasını Visual Studio 2022 ile açın ve `F5` ile çalıştırın.

## Uygulamanın Temel Özellikleri
- `KeyPreview = true` ile yalnızca aktif form içindeki klavye olaylarını yakalama
- Başlat / Durdur / Temizle butonları ve anlık durum göstergesi
- Her tuş olayını milisaniye hassasiyetinde zaman damgasıyla listeleme
- Toplam olay sayısı ve en sık basılan tuş istatistiği
- Kayıtları `.txt` dosyasına kaydetme

## Ekran Görüntüleri
![Kayıt Aktif Ekranı](screenshots/screenshot1.png)
![Dosyaya Kaydetme Ekranı](screenshots/screenshot2.png)

## Bilinen Sınırlamalar / Geliştirme Notları
- Yalnızca uygulama penceresi odaktayken olay yakalar; güvenlik gereği global hook içermez.

## Öğrenci Bilgileri
- **Ad-Soyad:** Asım Gökalp
- **Öğrenci Numarası:** 255541002
