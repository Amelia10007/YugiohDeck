using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace YugiohDeck.Database
{
    static class Storage
    {
        private static readonly string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static bool Exists(IEnumerable<string> keywords)
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
        public static IEnumerable<string[]> EnumerateExistingFiles(bool recursive, IEnumerable<string> keywords)
        {
            var path = GetFilePath(keywords);
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            if (!Directory.Exists(path)) yield break;
            var filenames = Directory.EnumerateFiles(path, "*", searchOption);
            var seperator = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
            var executableDirectoryKeywordCount = executableDirectory.Split(seperator).Length;
            foreach (var filename in filenames)
            {
                var pathKeywords = filename.Split(seperator).Skip(executableDirectoryKeywordCount);
                var comparisonCount = keywords.Count();
                var comparisonTarget = pathKeywords.Take(comparisonCount);
                if (keywords.SequenceEqual(comparisonTarget)) yield return pathKeywords.ToArray();
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
        public static string ReadString(IEnumerable<string> keywords)
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
        public static void WriteString(string content, IEnumerable<string> keywords)
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
        public static void Delete(IEnumerable<string> keywords)
        {
            var path = GetFilePath(keywords);
            if (File.Exists(path)) File.Delete(path);
            else if (Directory.Exists(path)) Directory.Delete(path);
        }
        private static string GetFilePath(IEnumerable<string> keywords)
        {
            return executableDirectory + "data\\" + keywords.Aggregate((current, next) => current + "\\" + next);
        }
    }
}
