namespace SASSTS2.Domain.Entities
{
    public enum Roles
    {
        Admin = 1,
        User = 2,
        RequestPerson = 3, //sadece talep oluşturabilecek kullanıcı
        OfferRecipient = 4, //teklif toplama ve alım yapabilecek kullanıcı
        MinApprove = 5, //min belirli tutara kadar onaylayan yetkili
        BetweenApprove = 6, //belirli tutarlar arasını onaylayabilen yetkili
        MaxApprove = 7, //max tutarı onaylayabilen yetkili
        Accounting = 8 //muhasebe
    }

    public enum Status
    {
        Created = 1, // oluşturuldu
        Waiting = 2, // bekliyor
        Approved = 3 // onaylandı
    }

    public enum Gender
    {
        Male = 1,
        Famale = 2
    }
}
