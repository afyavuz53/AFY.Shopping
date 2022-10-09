namespace Afy.Shopping.WebAPI.Models
{
    ///<summary>
    ///İstek
    ///</summary>
    public class RequestDto
    {
        ///<summary>Sayfa numarası</summary>
        public int page { get; set; }
        ///<summary>Sayfa büyüklüğü</summary>
        public int size { get; set; }
    }
}
