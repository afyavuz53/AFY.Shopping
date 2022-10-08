namespace Afy.Shopping.WebAPI.Models
{
    ///<summary>
    ///İstek model
    ///</summary>
    public class RequestDto
    {
        ///<summary>Sayfa numarası</summary>
        public int page { get; set; }
        ///<summary>Sayfa büyüklüğü</summary>
        public int size { get; set; }
    }
}
