#pragma warning disable SA1119 // Statement should not use unnecessary parenthesis
#pragma warning disable SA1311 // Static readonly fields should begin with upper-case letter
#pragma warning disable SA1121 // Use built-in type alias
#pragma warning disable SA1503 // Braces should not be omitted
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1303 // Const field names should begin with upper-case letter
#pragma warning disable SA1512 // Single-line comments should not be followed by blank line
namespace NanoRpcSharp.BitSharp
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Numerics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Source: https://github.com/vardthomas/Aggrex.RaiSharp/blob/develop/src/Aggrex.Common/BitSharp/ExtensionMethods.cs
    /// </summary>
    public static class ExtensionMethods
    {
        public static byte[] Concat(this byte[] first, byte[] second)
        {
            var buffer = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
            Buffer.BlockCopy(second, 0, buffer, first.Length, second.Length);
            return buffer;
        }

        public static byte[] Concat(this byte[] first, byte second)
        {
            var buffer = new byte[first.Length + 1];
            Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
            buffer[buffer.Length - 1] = second;
            return buffer;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, T second)
        {
            foreach (var item in first)
                yield return item;

            yield return second;
        }

        // ToHexNumberString    prints out hex bytes in reverse order, as they are internally little-endian but big-endian is what people use:
        //                      bytes 0xEE,0xFF would represent what a person would write down as 0xFFEE

        // ToHexNumberData      prints out hex bytes in order

        public static string ToHexNumberString(this byte[] value)
        {
            return Bits.ToString(value.Reverse().ToArray()).Replace("-", string.Empty).ToLower();
        }

        public static string ToHexNumberString(this UInt256 value)
        {
            return Bits.ToString(value.ToByteArrayBE()).Replace("-", string.Empty).ToLower();
        }

        public static string ToHexNumberString(this BigInteger value)
        {
            return ToHexNumberString(value.ToByteArray());
        }

        public static string ToHexDataString(this byte[] value)
        {
            return $"[{Bits.ToString(value).Replace("-", ",").ToLower()}]";
        }

        public static string ToHexDataString(this UInt256 value)
        {
            return ToHexDataString(value.ToByteArray());
        }

        public static string ToHexDataString(this BigInteger value)
        {
            return ToHexDataString(value.ToByteArray());
        }

        [DebuggerStepThrough]
        public static void Do(this SemaphoreSlim semaphore, Action action)
        {
            semaphore.Wait();
            try
            {
                action();
            }
            finally
            {
                semaphore.Release();
            }
        }

        [DebuggerStepThrough]
        public static T Do<T>(this SemaphoreSlim semaphore, Func<T> func)
        {
            semaphore.Wait();
            try
            {
                return func();
            }
            finally
            {
                semaphore.Release();
            }
        }

        [DebuggerStepThrough]
        public static async Task DoAsync(this SemaphoreSlim semaphore, Func<Task> action)
        {
            await semaphore.WaitAsync();
            try
            {
                await action();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static int ToIntChecked(this UInt32 value)
        {
            checked
            {
                return (int)value;
            }
        }

        public static int ToIntChecked(this UInt64 value)
        {
            checked
            {
                return (int)value;
            }
        }

        public static int ToIntChecked(this long value)
        {
            checked
            {
                return (int)value;
            }
        }

        public static uint ToUIntChecked(this int value)
        {
            checked
            {
                return (uint)value;
            }
        }

        public static byte[] NextBytes(this Random random, long length)
        {
            var buffer = (byte[])Array.CreateInstance(typeof(byte), length);
            random.NextBytes(buffer);
            return buffer;
        }

        public static void Forget(this Task task)
        {
        }

        [DebuggerStepThrough]
        public static void DoRead(this ReaderWriterLockSlim rwLock, Action action)
        {
            rwLock.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        [DebuggerStepThrough]
        public static T DoRead<T>(this ReaderWriterLockSlim rwLock, Func<T> func)
        {
            rwLock.EnterReadLock();
            try
            {
                return func();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        [DebuggerStepThrough]
        public static void DoWrite(this ReaderWriterLockSlim rwLock, Action action)
        {
            rwLock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        [DebuggerStepThrough]
        public static T DoWrite<T>(this ReaderWriterLockSlim rwLock, Func<T> func)
        {
            rwLock.EnterWriteLock();
            try
            {
                return func();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public static int THOUSAND(this int value)
        {
            return value * 1000;
        }

        public static int MILLION(this int value)
        {
            return value * 1000 * 1000;
        }

        public static long BILLION(this int value)
        {
            return (long)value * 1000 * 1000 * 1000;
        }

        public static long THOUSAND(this long value)
        {
            return value * 1000;
        }

        public static long MILLION(this long value)
        {
            return value * 1000 * 1000;
        }

        public static long BILLION(this long value)
        {
            return value * 1000 * 1000 * 1000;
        }

        public static decimal THOUSAND(this decimal value)
        {
            return value * 1000;
        }

        public static decimal MILLION(this decimal value)
        {
            return value * 1000 * 1000;
        }

        public static decimal BILLION(this decimal value)
        {
            return value * 1000 * 1000 * 1000;
        }

        public static int KIBIBYTE(this int value)
        {
            return value * 1024;
        }

        public static int MEBIBYTE(this int value)
        {
            return value * 1024 * 1024;
        }

        public static long GIBIBYTE(this int value)
        {
            return value * 1024 * 1024 * 1024;
        }

        public static void DisposeList(this IEnumerable<IDisposable> disposables)
        {
            foreach (var item in disposables.Where(x => x != null))
                item.Dispose();
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> keyPairs)
        {
            return keyPairs.ToDictionary(x => x.Key, x => x.Value);
        }

        public static List<T> SafeToList<T>(this ICollection<T> collection)
        {
            var list = new List<T>(collection.Count);
            foreach (var item in collection)
                list.Add(item);

            return list;
        }

        public static byte[] HexToByteArray(this string value)
        {
            if (value.Length % 2 != 0)
                throw new ArgumentOutOfRangeException();

            var bytes = new byte[value.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Byte.Parse(value.Substring(i * 2, 2), NumberStyles.HexNumber);
            }

            return bytes;
        }

        public static UInt32 NextUInt32(this Random random)
        {
            return (UInt32)random.Next(int.MinValue, int.MaxValue);
        }

        public static UInt64 NextUInt64(this Random random)
        {
            return (random.NextUInt32() << 32) + random.NextUInt32();
        }

        public static Int64 NextInt64(this Random random)
        {
            return unchecked((long)random.NextUInt64());
        }

        public static UInt256 NextUInt256(this Random random)
        {
            return new UInt256(
                (new BigInteger(random.NextUInt32()) << 96) +
                (new BigInteger(random.NextUInt32()) << 64) +
                (new BigInteger(random.NextUInt32()) << 32) +
                new BigInteger(random.NextUInt32()));
        }

        public static BigInteger NextUBigIntegerBytes(this Random random, int byteCount)
        {
            var bytes = random.NextBytes(byteCount).Concat(new byte[1]);
            return new BigInteger(bytes);
        }

        public static bool NextBool(this Random random)
        {
            return random.Next(2) == 0;
        }

        public static void RemoveWhere<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            foreach (var item in dictionary)
            {
                if (predicate(item))
                {
                    TValue ignore;
                    dictionary.TryRemove(item.Key, out ignore);
                }
            }
        }

        public static IEnumerable<KeyValuePair<TKey, TValue>> TakeAndRemoveWhere<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            foreach (var item in dictionary)
            {
                if (predicate(item))
                {
                    TValue value;
                    if (dictionary.TryRemove(item.Key, out value))
                    {
                        yield return new KeyValuePair<TKey, TValue>(item.Key, value);
                    }
                }
            }
        }

        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentException();

            var range = maxValue - minValue;
            return (random.NextDouble() * range) + minValue;
        }

        public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector)
        {
            checked
            {
                var sum = 0UL;
                foreach (var item in source)
                    sum += selector(item);

                return sum;
            }
        }

        public static BigInteger Sum<T>(this IEnumerable<T> source, Func<T, BigInteger> selector)
        {
            checked
            {
                var sum = default(BigInteger);
                foreach (var item in source)
                    sum += selector(item);

                return sum;
            }
        }

        public static IEnumerable<TResult> DequeueSelect<T, TResult>(this ConcurrentQueue<T> queue, Func<T, TResult> selector)
        {
            T result;
            while (queue.TryDequeue(out result))
                yield return selector(result);
        }

        [DebuggerStepThrough]
        public static void Time(this Stopwatch stopwatch, Action action)
        {
            if (stopwatch.IsRunning)
                throw new InvalidOperationException();

            stopwatch.Start();
            try
            {
                action();
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        [DebuggerStepThrough]
        public static async Task TimeAsync(this Stopwatch stopwatch, Task task)
        {
            if (stopwatch.IsRunning)
                throw new InvalidOperationException();

            stopwatch.Start();
            try
            {
                await task;
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        [DebuggerStepThrough]
        public static async Task TimeAsync(this Stopwatch stopwatch, Func<Task> action)
        {
            if (stopwatch.IsRunning)
                throw new InvalidOperationException();

            stopwatch.Start();
            try
            {
                await action();
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public static IEnumerable<T> UsingAsEnumerable<T>(this IEnumerator<T> enumerator)
        {
            using (enumerator)
            {
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
        }

        public static bool AnyDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.GroupBy(keySelector)
                .Where(x => x.Skip(1).Any())
                .Any();
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var random = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
#pragma warning restore SA1119 // Statement should not use unnecessary parenthesis
#pragma warning restore SA1311 // Static readonly fields should begin with upper-case letter
#pragma warning restore SA1121 // Use built-in type alias
#pragma warning restore SA1503 // Braces should not be omitted
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1303 // Const field names should begin with upper-case letter
#pragma warning restore SA1512 // Single-line comments should not be followed by blank line
