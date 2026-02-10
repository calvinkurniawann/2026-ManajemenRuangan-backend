# Sistem Manajemen Peminjaman Ruangan – Backend

## Deskripsi
Backend API untuk Sistem Manajemen Peminjaman Ruangan Kampus.
Aplikasi ini digunakan untuk mengelola data ruangan dan peminjaman ruangan, termasuk pencatatan, pembaruan status peminjaman, pencarian data, serta penyimpanan histori peminjaman.

Backend dikembangkan menggunakan ASP.NET Core Web API.

---

## Teknologi
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- C#

---

## Instalasi

1. Clone Repository
git clone https://github.com/<username>/2026-ManajemenRuangan-backend.git
cd 2026-ManajemenRuangan-backend

2. Restore Dependency
dotnet restore

---

## Environment Configuration
Aplikasi ini menggunakan konfigurasi bawaan ASP.NET Core.

Tidak diperlukan file .env.
Database SQLite akan dibuat otomatis saat migration dijalankan.

---

## Panduan Menjalankan Aplikasi

1. Jalankan Migration
dotnet ef database update

2. Jalankan Aplikasi
dotnet run

3. Akses API
Buka browser dan akses Swagger UI:
http://localhost:5xxx/swagger

Swagger digunakan untuk mencoba dan menguji seluruh endpoint API.
