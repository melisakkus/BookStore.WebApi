using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    [NotMapped]
    public class MailModel
    {
        public string ToEmail { get; set; }  
        public string Subject = "🎉 BookSaw Aboneliğiniz Başladı! En Yeni Kitaplardan İlk Siz Haberdar Olun!"; 
        public string Body = @"
        <p>Merhaba,</p>
        <p>BookSaw bültenimize abone olduğunuz için teşekkür ederiz! 🎉 Artık yeni çıkan kitaplardan, özel indirimlerden ve önerilerimizden ilk siz haberdar olacaksınız.</p>
        <p>📌 <strong>Sizi Neler Bekliyor?</strong></p>
        <ul>
            <li> Yeni çıkan kitaplar hakkında ilk siz bilgi alacaksınız.</li>
            <li> Özel indirim ve kampanyalardan haberdar olacaksınız.</li>
            <li> Okuma önerileri ve çok satanlar listesi düzenli olarak e-postanıza gelecek.</li>
        </ul>
        <p>🔖 Şimdi keşfetmek için sitemizi ziyaret edin.</p>
        <p>Keyifli okumalar dileriz! 📚✨</p>";
    }
}

