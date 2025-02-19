namespace WTECHIN.Tutorial.Authors;
using Volo.Abp;
public class AuthorAlreadyExistsException:BusinessException
{
    //BusinessExpection sınıfı iş mantığı hatalarını yönetmek için kullanılır.
    public AuthorAlreadyExistsException(string name) : base(TutorialDomainErrorCodes.AuthorAlreadyExists)
    {
        //base ile BusinessException sınıfının kurucu metoduna TutorialDomainErrorCodes.AuthorAlreadyExists değerini gönderiyoruz.
        WithData("name", name); //WithData("name", name) fonksiyonu, hata nesnesine ekstra veri eklemeye yarar.
    }
    
    
}