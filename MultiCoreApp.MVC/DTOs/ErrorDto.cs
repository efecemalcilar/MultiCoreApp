namespace MultiCoreApp.MVC.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>(); //Listemizi ilk çalıştıgında oluşturmuş olduk.Sadece ilk çalıştıgında newleniyor.
        }

        public List<String> Errors { get; set; }

        public int Status { get; set; }


    }
}
