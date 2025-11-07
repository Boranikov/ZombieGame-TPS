PROJE RAPORU: Nuclear Countdown: Last 5 Minutes

Ders: 2025-2026 Güz Dönemi Yazılım Geliştirme Laboratuvarı - I
Proje Adı: Nuclear Countdown: Last 5 Minutes
GitHub Reposu: https://github.com/Boranikov/ZombieGame-TPS

Ekip Üyeleri ve Görev Dağılımı

Nuh Regaib Ünsal: NPC Yapay Zeka (AI) Sistemleri (FSM, NavMesh)
Muhammed Emir Karaman: Oyuncu Kontrol Sistemleri (Hareket, Silah, Hasar)
Boran Sert: Harita Tasarımı ve Çevre (Level Design, 3B Model Yerleşimi)

1. Senaryo

Zombi kıyameti sonrası dünya yok olmanın eşiğine gelmiştir. Kontrolünü kaybetmiş deneysel bir nükleer araştırma tesisi, son 5 dakika içerisinde kendini imha moduna girmiştir. Bu patlama gerçekleşirse bölge tamamen yok olacak ve radyasyonla insanlığın kalan son yaşameritleri de sona erecektir.

Oyuncu; hayatta kalmayı başarmış 3 kişilik direniş ekibinden bir ajanı kontrol eder. Görev: 5 dakika içerisinde tesis koridorlarında devriye gezen zombileri atlatarak veya çatışarak "Kontrol Odası'na" ulaşmak ve son boss olarak mutasyona uğramış Alpha Zombie ile savaşarak sistemi durdurmaktır. Başarısız olunursa insanlık tamamen yok olur.

2. Oyun Türü ve Platform

Tür: TPS (Third Person Shooter)
Platform: PC
Oyun Motoru: Unity 6.2
Grafik Yaklaşımı: Low-poly optimize edilmiş nükleer tesis / askeri tarzı çevre.
Kamera: TPS kamera (arkadan üçüncü şahıs görünümlü).

3. Oyun Mekanikleri

Proje, temel TPS mekaniklerini karşılamaya odaklanmıştır:

Silah: Assault Rifle
Hasar: Kurşun çarpma hasar sistemi ve düşman sağlık sistemi.
Oyuncu: Oyuncu hasar alma sistemi ve hareket mekaniği.
Siper (Cover): Haritada siper kullanılabilecek alanlar mevcuttur ve bunlar oyuncuya avantaj sağlar.
Harita: Tek level'lik temel bir harita (nükleer tesis). Harita; Giriş, Koridor ve Kontrol Odası bölümlerinden oluşur.

4. Literatür Taraması ve Karşılaştırma

Projemiz, kapsamlı oyunlar yerine temel mekaniklere odaklanan basit bir yaklaşım benimsemiştir.

Resident Evil 2 Remake (Referans): Bu oyundaki zombi davranışları incelenmiştir.
	Karşılaştırma: RE2'nin karmaşık zombi yapay zekası (uzuv parçalanması, dinamik korku tepkileri) yerine, bizim projemiz FSM tabanlı temel "oyuncuyu görünce kovala ve saldır" mekaniklerine odaklanmıştır.
The Division (Referans): Bu oyundan TPS çatışma hissi ve siper mekaniği için ilham alınmıştır.
	Karşılaştırma: "The Division" oyunundaki gibi gelişmiş, taktiksel siper alma (cover-based combat) sistemleri yerine, bizim oyunumuz daha direkt bir "koş ve ateş et" (run-and-gun) aksiyonu sunar. Haritadaki siper alanları, oyuncuya sadece basit bir koruma avantajı sağlar, taktiksel bir zorunluluk değildir.

5. Sistem Mimarisi ve Tasarımı

5.1. Sistem Şeması (Akışı)

Oyunun temel çalışma akışı şu bileşenler üzerinden ilerler:

`Player Input` → `Player Controller` (Hareket/Nişan Alma) → `Camera TPS Controller` (Kamera Takibi) → `Weapon System` (Ateş Etme) → `Bullet Damage Check` (Mermi Kontrolü) → `Enemy FSM` (Düşman Tepkisi) → `Attack Result` (Hasar Alma/Verme)

5.2. Yapay Zeka (NPC) Davranışı

NPC'ler (Zombiler) için Sonlu Durum Makinesi (FSM AI) kullanılmıştır.

Durumlar: NPC'ler 4 temel duruma sahiptir:
    1.  Idle (Boşta): Oyuncu menzilde değilken.
    2.  Patrol (Devriye): Belirlenen noktalarda gezerken.
    3.  Chase (Kovalama): Oyuncuyu tespit ettiğinde.
    4.  Attack (Saldırı): Oyuncu saldırı menziline girdiğinde.
Yol Bulma (Pathfinding): NPC'lerin haritada gezinmesi ve oyuncuyu kovalaması için Unity NavMesh + NavMesh Agent sistemi kullanılmıştır.

5.3. Tasarlanan Ekranlar (Arayüz)

Projede Giriş Ekranı Oyun Durdurma Ekranı ve Oyun Sonu ekranı bulunmaktadır

Oyun İçi Arayüz (HUD): Oyun ekranı üzerinde oyuncunun hayatta kalması için kritik olan bilgiler yer alır:
    Nükleer patlama için 5 dakikalık geri sayım sayacı.
    Oyuncu can durumu.
    Mermi ve şarjör bilgisi.

6. Kullanılan Yazılımsal Mimariler ve Teknikler

Projenin basit yapısına uygun olarak temel teknikler kullanılmıştır:

Blender: Harita tasarımı hazır asset olarak alınmamış blender ile elle tasarlanmıştır.
Object-Oriented Programming (OOP): Temel OOP prensipleri uygulanmıştır. 'PlayerController', 'EnemyAI' ve 'WeaponSystem' gibi ana bileşenler ayrı sınıflar olarak yönetilerek kodun modüler ve yönetilebilir kalması sağlanmıştır.
State Machine Pattern: NPC yapay zekası için 'State Machine Pattern' kullanılmıştır. Düşmanlar, 'Idle', 'Patrol', 'Chase' ve 'Attack' durumları arasında geçiş yapar. Bu geçişler, oyuncunun mesafesi ve görüş alanı gibi basit tetikleyicilerle (triggers) yönetilmiştir.
NavMesh Agent AI Navigation: Zombilerin haritada yol bulması için Unity'nin NavMesh sistemi kullanılmıştır.
Diğer Teknikler: Event Trigger Based Shooting ve Unity Animator state blend.

7. Karşılaşılan Zorluklar ve Çözümler

Zorluk: Unreal Engine ve Unity arasında karar verme.
    Çözüm: Ekip aşinalığı ve hızlı geliştirme imkanı nedeniyle Unity 6.2 seçildi.
Zorluk: Kaynakların çoğunlukla İngilizce olması.
    Çözüm: Dökümantasyon okumaları ve örnek kod parçalarının analizi ile sorun aşıldı.
Zorluk: Unity animasyon 'rigging' (iskelet sistemi) karmaşıklığı.
    Çözüm: 'Blend' parametreleri sadeleştirilerek ve temel animasyonlara odaklanılarak çözüldü.
