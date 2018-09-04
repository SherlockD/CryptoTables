namespace CryptoTables
{
    public static class CryptoTables
    {
        public static string Encrypt(this string owner)
        {
            int arraySize = Properties.Settings.Default.arraySize;

            var cryptoArray = new char[arraySize, arraySize];
            string resultString = "";
            int charNumber = 0;

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    cryptoArray[i, j] = owner[charNumber];
                    charNumber++;
                    if (charNumber >= owner.Length) break;
                }
                if (charNumber >= owner.Length) break;
            }

            for (int j = 0; j < arraySize; j++)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    resultString += cryptoArray[i, j];
                }
            }

            return resultString;
        }

        public static string Decrypt(this string owner)
        {
            int arraySize = Properties.Settings.Default.arraySize;

            var cryptoArray = new char[arraySize, arraySize];
            string resultString = "";
            int charNumber = 0;

            for (int j = 0; j < arraySize; j++)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    cryptoArray[i, j] = owner[charNumber];
                    charNumber++;
                    if (charNumber >= owner.Length) break;
                }
                if (charNumber >= owner.Length) break;
            }

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    resultString += cryptoArray[i, j];
                }
            }

            return resultString;
        }
    }
}
