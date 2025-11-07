Nuclear Countdown: Last 5 Minutes

Bu proje, Kocaeli Üniversitesi 2025-2026 Güz Dönemi Yazılım Geliştirme Laboratuvarı - I Dersi için geliştirilmiş, yapay zeka destekli bir TPS (Third Person Shooter) oyunudur.

Projenin Amacı

"Nuclear Countdown", oyuncuyu zombi kıyametinin ortasında bir nükleer tesise götürür. Bir nükleer araştırma tesisi kontrolden çıkmış ve 5 dakika içinde kendini imha moduna girmiştir.

Oyuncu olarak göreviniz, bu 5 dakikalık süre dolmadan tesis koridorlarındaki zombileri aşarak "Kontrol Odası'na" ulaşmak ve sistemi durdurmaktır.

Temel Özellikler ve Mekanikler

TPS Kamera: Oyuncuyu arkadan takip eden üçüncü şahıs nişancı kamerası.

Yapay Zeka (FSM): Düşmanlar (Zombiler), oyuncuya tepki vermek için Sonlu Durum Makinesi (FSM) kullanır.

Idle: Boşta bekleme.

Patrol: Devriye gezme.

Chase: Oyuncuyu görünce kovalama.

Attack: Saldırı menziline girince saldırma.

Yol Bulma (Pathfinding): Zombiler, oyuncuyu bulmak ve haritada gezinmek için Unity NavMesh Agent sistemini kullanır.

Savaş Mekanikleri:

Oyuncu hareket, nişan alma ve hasar alma sistemleri.

Düşman sağlık ve hasar sistemi.

Siper (Cover) alanları (Basit koruma sağlar).

Oyun Arayüzü (HUD):

5 dakikalık kritik geri sayım sayacı.

Oyuncu can durumu.

Mermi ve şarjör bilgisi.

Kullanılan Teknolojiler

Oyun Motoru: Unity 6.2

3D Modelleme: Harita tasarımı (Nükleer Tesis) Blender kullanılarak elle tasarlanmıştır.

Programlama Dili: C#

Mimari ve Teknikler:

Object-Oriented Programming (OOP)

State Machine Pattern (Yapay Zeka için)

Unity NavMesh Agent

Unity Animator (Blend parametreleri ile)

Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1. Projeyi Klonlayın: git clone https://github.com/Boranikov/ZombieGame-TPS.git

2. Unity Hub ile Açın:

2.1 Unity Hub'ı açın.

2.2 "Add project from disk" (veya "Aç") seçeneğini kullanarak klonladığınız proje klasörünü seçin.

ÖNEMLİ: Projenin Unity 6.2 sürümü ile geliştirildiğinden emin olun. Gerekirse bu sürümü Unity Hub üzerinden yükleyin.

3. Projeyi Başlatın:

3.1 Proje Unity Editör'de açıldığında, "Assets" klasörü altındaki "Scenes" klasörüne gidin.

3.2 Oyunun ana sahnesini "SampleScene" açın.

3.3 Editör üzerinden 'Play' (Oynat) butonuna basarak oyunu başlatın.

Ekip Üyeleri

Nuh Regaib Ünsal: NPC Yapay Zeka (AI) Sistemleri (FSM, NavMesh)

Muhammed Emir Karaman: Oyuncu Kontrol Sistemleri (Hareket, Silah, Hasar)

Boran Sert: Harita Tasarımı ve Çevre (Level Design, 3B Model Yerleşimi)
