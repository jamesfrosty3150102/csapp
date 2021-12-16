using System;

namespace StartsWith
{
    class StartsWithTest
    {
        static void Main(string[] args)
        {
            string[] strSource = { "<b>This is bold text</b>", "<H1>This is large Text</H1>",
                "<b><i><font color=green>This has multiple tags</font></i></b>",
                "<b>This has <i>embedded</i> tags.</b>",
                "<This line simply begins with a lesser than symbol, it should not be modified" };
            // Display the initial string array.
            Console.WriteLine("The original strings:");
            Console.WriteLine("---------------------");
            foreach (var s in strSource)
                Console.WriteLine(s);
            Console.WriteLine();

            Console.WriteLine("Strings after starting tags have been stripped:");
            Console.WriteLine("-----------------------------------------------");

            // Display the strings with starting tags removed.
            foreach (var s in strSource)
                Console.WriteLine(StripStartTags(s));
        }
        private static string StripStartTags(string item)
        {
            // Determine whether a tag begins the string.
            if (item.Trim().StartsWith("<"))
            {
                // Find the closing tag.
                int lastLocation = item.IndexOf(">");
                // Remove the tag.
                if (lastLocation >= 0)
                {
                    item = item.Substring(lastLocation + 1);

                    // Remove any additional starting tags.
                    item = StripStartTags(item);
                }
            }

            return item;
        }
    }
}
