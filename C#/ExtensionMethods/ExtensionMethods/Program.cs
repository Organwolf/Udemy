namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "long blog post of cool stuff that I don't want to read";
            var shortenedPost = post.Shorten(5);

            System.Console.WriteLine(shortenedPost);
        }
    }
}
