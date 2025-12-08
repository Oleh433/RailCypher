namespace RailCipherMVC.Models
{
    public class RailFenceModel
    {
        public string InputText { get; set; }
        public int Rails { get; set; } = 3;

        public string EncryptedText { get; set; }
        public string DecryptedText { get; set; }

        public char[,] FenceArray { get; set; }
    }
}
