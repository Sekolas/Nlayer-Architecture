# N-Layer Architecture

Bu doküman, **N Katmanlı Mimari (N-Layer Architecture)** konseptine dayalı bir yazılım projesi için temel bilgileri sağlar. N Katmanlı Mimari, uygulamayı birden fazla katmana ayırarak bağımsız geliştirme, test edilebilirlik ve ölçeklenebilirlik sağlamayı hedefleyen bir mimari yaklaşımdır.

---

## **Mimari Katmanlar**

1. **Presentation Layer (Sunum Katmanı):**
   - Kullanıcı arayüzü (UI) ve kullanıcı etkileşimlerinin yer aldığı katmandır.
   - Amaç: Veriyi kullanıcıya sunmak ve kullanıcıdan gelen girdileri toplamak.
   - Örnek Teknolojiler: HTML/CSS, JavaScript, React, Angular, ASP.NET Razor Pages.

2. **Application Layer (Uygulama Katmanı):**
   - İş kurallarını yöneten ve uygulamanın genel işleyişini kontrol eden katmandır.
   - Sunum katmanı ile iş kurallarını (domain) birbirinden izole eder.
   - Örnek: Servisler, Use-Case Implementations.
   - Örnek Teknolojiler: ASP.NET Core Services, Spring Boot Services.

3. **Domain/Business Logic Layer (İş Kuralları Katmanı):**
   - Uygulamanın temel iş mantığının bulunduğu katmandır.
   - Uygulama için gerekli olan iş kuralları ve mantık bu katmanda tanımlanır.
   - Veriler üzerinde yapılan işlemler burada gerçekleştirilir.
   - Örnek Teknolojiler: C#, Java, Python.

4. **Data Access Layer (Veri Erişim Katmanı):**
   - Veritabanı işlemlerini (CRUD) yöneten katmandır.
   - Veriyi alır, yazar ve bu işlemleri iş mantığı katmanına iletir.
   - Örnek Teknolojiler: Entity Framework, Dapper, Hibernate.

5. **Infrastructure Layer (Alt Yapı Katmanı):**
   - Harici sistemler, dosya sistemi, mesajlaşma kuyrukları gibi altyapı ile ilgili bileşenlerin yönetildiği katmandır.
   - Genellikle çapraz kesen (cross-cutting concerns) işlevleri içerir.
   - Örnek Teknolojiler: RabbitMQ, Redis, Azure Blob Storage.

---

## **Mimari Avantajları**
- **Bağımsızlık:** Her katman diğerlerinden bağımsız geliştirilebilir, test edilebilir ve değiştirilebilir.
- **Test Edilebilirlik:** Birim testlerin kolayca yazılmasını sağlar.
- **Bakım Kolaylığı:** Katmanlar arasında net ayrımlar olduğundan bakım ve genişletme kolaylaşır.
- **Yeniden Kullanılabilirlik:** İş mantığı ve veri erişim kodları, farklı sunum katmanları ile yeniden kullanılabilir.

---

## **Katmanlar Arası İletişim**
- Katmanlar, yalnızca bir alt katmanla iletişim kurar.
- Örneğin:
  - Sunum katmanı yalnızca Uygulama katmanıyla iletişim kurar.
  - İş Mantığı katmanı, yalnızca Veri Erişim katmanıyla iletişim kurar.
  
Katmanlar arası bağımlılığı minimumda tutmak için **dependency injection (bağımlılık enjeksiyonu)** ve **interface segregation** uygulanır.

---

## **Tipik Proje Yapısı**
Aşağıda bir C# projesi için örnek bir dosya yapısı verilmiştir:

---

## **Katmanların Detaylı Açıklaması**
### **1. Presentation Layer**
- Kullanıcı ile doğrudan etkileşim sağlar.
- İş mantığı ile direkt iletişim kurmamalıdır. Tüm işlemleri Application Layer'a yönlendirmelidir.
- **Görev:** Girdileri toplamak ve çıktıları kullanıcıya sunmak.

### **2. Application Layer**
- Kullanıcı isteklerini alır, doğrular ve iş mantığı katmanına iletir.
- **Görev:** İş kurallarını uygular ve sonuçları geri döndürür.

### **3. Domain/Business Logic Layer**
- İş kurallarının bulunduğu çekirdek katmandır.
- **Görev:** İş mantığını uygulamak.

### **4. Data Access Layer**
- Veri tabanı ile etkileşime geçer.
- ORM araçları veya SQL sorgularıyla veriye erişimi sağlar.
- **Görev:** Veri işlemleri yapmak (örneğin: Get, Insert, Update, Delete).

### **5. Infrastructure Layer**
- Harici kaynaklara erişimi yönetir.
- Cross-cutting concerns (ör. logging, caching) ele alınır.
- **Görev:** Alt yapı ile ilgili işlemleri soyutlamak.

---

## **Uygulama Akışı**
1. **Kullanıcı** bir işlem başlatır (örneğin, bir butona tıklar).
2. Sunum Katmanı, isteği Uygulama Katmanına iletir.
3. Uygulama Katmanı, gerekli iş mantığını çalıştırmak için Domain Katmanına istekte bulunur.
4. Domain Katmanı, veri tabanı erişimi gerekirse Data Access Katmanına istekte bulunur.
5. Sonuç, katmanlar arasında yukarı doğru iletilerek Sunum Katmanına ve ardından kullanıcıya döndürülür.

---

## **Best Practices**
- Katmanlar arasında doğrudan bağımlılık olmamalıdır; **dependency injection** kullanılmalıdır.
- Her katman, kendi amacına odaklanmalı ve başka bir katmanın işlevini yapmamalıdır.
- **Interface segregation** ile bağımlılıklar soyutlanmalıdır.
- Test edilebilirlik için her katmanda birim testler yazılmalıdır.

---

## **Kaynaklar**
- [Microsoft Docs: Layered Architecture](https://learn.microsoft.com)
- [Clean Architecture by Robert C. Martin](https://cleancoder.com)


