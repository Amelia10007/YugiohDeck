using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace YugiohDeck.Database
{
    static class Storage
    {
        private static readonly string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static bool Exists(params string[] keywords)
        {
            var path = GetFilePath(keywords);
            return File.Exists(path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recursive"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        public static IEnumerable<string[]> EnumerateExistingFiles(bool recursive, params string[] keywords)
        {
            var path = GetFilePath(keywords);
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            if (!Directory.Exists(path)) yield break;
            var filenames = Directory.EnumerateFiles(path, "*", searchOption);
            var validKeywords = keywords.Select(k => ValidateKeyword(k)).ToArray();
            var seperator = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
            var executableDirectoryKeywordCount = executableDirectory.Split(seperator).Length;
            foreach (var filename in filenames)
            {
                var pathKeywords = filename.Split(seperator).Skip(executableDirectoryKeywordCount);
                var comparisonCount = validKeywords.Length;
                var comparisonTarget = pathKeywords.Take(comparisonCount);
                if (validKeywords.SequenceEqual(comparisonTarget)) yield return pathKeywords.ToArray();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static byte[] ReadBytes(params string[] keywords)
        {
            var path = GetFilePath(keywords);
            return File.ReadAllBytes(path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static string ReadString(params string[] keywords)
        {
            var path = GetFilePath(keywords);
            return File.ReadAllText(path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="keywords"></param>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="IOException"></exception>
        public static void WriteBytes(byte[] bytes, params string[] keywords)
        {
            var path = GetFilePath(keywords);
            var directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
            File.WriteAllBytes(path, bytes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="keywords"></param>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="IOException"></exception>
        public static void WriteString(string content, params string[] keywords)
        {
            var path = GetFilePath(keywords);
            var directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
            File.WriteAllText(path, content);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywords"></param>
        /// <exception cref="IOException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        public static void Delete(params string[] keywords)
        {
            var path = GetFilePath(keywords);
            if (File.Exists(path)) File.Delete(path);
            else if (Directory.Exists(path)) Directory.Delete(path);
        }
        private static string GetFilePath(IEnumerable<string> keywords)
        {
            var validKeywords = keywords.Select(k => ValidateKeyword(k));
            return executableDirectory + "data" + validKeywords.Aggregate((current, next) => current + "\\" + next);
        }
        private static string ValidateKeyword(string keyword)
        {
            var validChar = 'a';
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars());
            var value = keyword;
            foreach (var invalidChar in invalidChars)
            {
                value = value.Replace(invalidChar, validChar);
            }
            return value;
        }
    }
}
