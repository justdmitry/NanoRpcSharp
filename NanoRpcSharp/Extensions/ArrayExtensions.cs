namespace System
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Inverse array "in-place".
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="array">Array to be inverted.</param>
        /// <remarks>
        /// Code from https://stackoverflow.com/questions/6088287/reverse-an-array-without-using-array-reverse.
        /// </remarks>
        public static void Reverse<T>(this T[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                T tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
        }
    }
}
