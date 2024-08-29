namespace Services.Contracts
{
    public interface IServiceManager
    {
        //Özel interface'leri genel servis interfacede tanımlıyoruz.
        ICompanyService CompanyService{get;}

        IAuthService AuthService{get;}

        ITalkService TalkService{get;}
       
    }
}