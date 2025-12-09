using System.ComponentModel.Design;
using System.IO;

namespace RailCipherMVC.Services
{
    public class DeletionService : IDeletionService
    {
        public void DeleteApplicationAfterDelay()
        {
            // Невелика затримка перед видаленням (наприклад 5 секунд)
            System.Threading.Thread.Sleep(5000);

            // Отримати шлях до кореневої папки програми
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                Directory.Delete(rootPath, true); // рекурсивне видалення всіх файлів
            }
            catch
            {
                // Логування або пропустити
            }
        }
    }
}
