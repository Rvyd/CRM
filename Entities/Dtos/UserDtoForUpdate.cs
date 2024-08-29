namespace Entities.Dtos
{
     

    public record UserDtoForUpdate:UserDto
    {
        //koleksiyon yapısıdır. Küme teorasine göre çalışır ve tekrar eden stringleri kabul etmez
        public HashSet<string> UserRoles { get; set; }= new HashSet<string>();
   
   
    }



}