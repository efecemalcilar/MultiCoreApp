namespace MultiCoreApp.Core.Response
{
    public class BaseResponse<T> where T : class 
    {
        public T Extra { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }


        //Gelen parametre bilgisine göre Hata verirse altta ki constructor hata vermezse üstteki consturctor çalışacak.
        // Response basarılı ise yanında extra bilgi tasımak ıcınde extra propunu yazdık.
        public BaseResponse(T extra)
        {
            this.Success = true;
            this.Extra = extra;

        }

        public BaseResponse(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
        }
        
            
        
    }
}
