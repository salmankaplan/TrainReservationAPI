**Train Reservation API**

Genel Bilgiler Bir tren rezervasyonu uygulaması için, istenilen rezervasyonunun yapılıp yapılamayacağını ve yapılabiliyorsa hangi vagon için rezervasyon onaylanabileceğini belirleyen bir HTTP API geliştirilecektir.
API, HTTP Post isteklerine yanıt verecektir.

HTTP API'a tren bilgileri ve kaç kişilik rezervasyon istenildiği gönderilecek, geliştirilecek algoritma rezervasyon yapılıp yapılamayacağı bilgisini dönecektir.

**Gereksinimler**

Bir tren içinde birden fazla vagon bulunabilir.
Her vagonun farklı kişi kapasitesi olabilir.
Online rezervasyonlarda, bir vagonun doluluk kapasitesi %70'i geçmemelidir. Yani vagon kapasitesi 100 ise ve 70 koltuk dolu ise, o vagona rezervasyon yapılamaz.
Bir rezervasyon isteği içinde birden fazla kişi olabilir.
Rezervasyon isteği yapılırken, kişilerin farklı vagonlara yerleşip yerleştirilemeyeceği belirtilir. Bazı rezervasyonlarda tüm yolcuların aynı vagonda olması istenilirken, bazılarında farklı vagonlar da kabul edilebilir.
Rezervasyon yapılabilir durumdaysa, API hangi vagonlara kaçar kişi yerleşeceği bilgisini dönecektir.


**Train List**

![Screenshot_10](https://user-images.githubusercontent.com/105590511/196028521-d988aa64-4833-4f25-846b-f30f89a8eacd.png)

**Post İşlemi**
Tren seçimi yapılabilir ve bu trene ait seçilen vagonların isimleri girilmelidir. Vagonun kapasite ve dolu koltuk sayısının girilmesine gerek yoktur çünkü vagon isminden doğru veriler gelmektedir. Kişi sayısının girilmesi zorunludur. Farklı vagonda olma durumu aktif olduğunda istenilen vagonların isimleri liste halinde girilmelidir. 
