using System.Text;

namespace RailCipherMVC.Services
{
    public static class RailFenceCipher
    {
        public static string Encrypt(string text, int rails, out char[,] fence)
        {
            int len = text.Length;
            fence = new char[rails, len];

            if (rails <= 1) return text;

            int row = 0;
            bool directionDown = true;

            for (int col = 0; col < len; col++)
            {
                fence[row, col] = text[col];

                row += directionDown ? 1 : -1;

                if (row == rails - 1 || row == 0)
                    directionDown = !directionDown;
            }

            StringBuilder encrypted = new StringBuilder();
            for (int r = 0; r < rails; r++)
                for (int c = 0; c < len; c++)
                    if (fence[r, c] != '\0')
                        encrypted.Append(fence[r, c]);

            return encrypted.ToString();
        }

        public static string Decrypt(string cipher, int rails)
        {
            if (rails <= 1) return cipher;

            int len = cipher.Length;
            char[,] fence = new char[rails, len];
            bool[,] mark = new bool[rails, len];

            int row = 0;
            bool directionDown = true;

            for (int col = 0; col < len; col++)
            {
                mark[row, col] = true;

                row += directionDown ? 1 : -1;

                if (row == rails - 1 || row == 0)
                    directionDown = !directionDown;
            }

            int idx = 0;
            for (int r = 0; r < rails; r++)
            {
                for (int c = 0; c < len; c++)
                {
                    if (mark[r, c])
                        fence[r, c] = cipher[idx++];
                }
            }

            StringBuilder result = new StringBuilder();
            row = 0;
            directionDown = true;

            for (int col = 0; col < len; col++)
            {
                result.Append(fence[row, col]);

                row += directionDown ? 1 : -1;

                if (row == rails - 1 || row == 0)
                    directionDown = !directionDown;
            }

            return result.ToString();
        }
    }
}

