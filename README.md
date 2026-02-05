# 🧱 Layered Console App (C#)

Clean Architecture prensiplerini console uygulaması üzerinden
uygulamalı olarak göstermek amacıyla geliştirilmiş bir C# projesidir.

Bu proje, UI, Application, Infrastructure ve Domain katmanlarının
birbirinden **net şekilde ayrıldığı** bir mimari örneğidir.

---

## 🎯 Amaç
- Katmanlı mimariyi gerçek bir örnek üzerinden anlamak
- Bağımlılıkların yönünü kontrol etmek
- İş mantığını UI ve veri erişiminden ayırmak
- API projeleri için sağlam bir temel oluşturmak

---

## 🧱 Mimari Yapı
Domain/
└── TaskItem.cs -> Saf domain modeli

Application/
└── TaskService.cs -> İş kuralları

Infrastructure/
└── TaskRepository.cs -> Veri erişimi (in-memory)

Presentation/
└── ConsoleUI.cs -> Console kullanıcı arayüzü

Program.cs -> Composition Root

---

## 🔄 Katmanlar Arası Akış
ConsoleUI
↓
TaskService
↓
TaskRepository
↓
TaskItem

---

Bağımlılıklar **tek yönlüdür** ve tersine dönmez.

---

## 🛠️ Kullanılan Teknolojiler
- C#
- .NET Console Application
- Clean / Layered Architecture yaklaşımı
- Dependency Injection (manuel)
- LINQ

---

## ▶️ Çalıştırma
```bash
dotnet run
