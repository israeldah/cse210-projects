using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var videos = new List<Video>();

        // Video 1
        var v1 = new Video("10 C# Tips You Didn't Know", "CodeWithMosh", 742);
        v1.AddComment(new Comment("Alice", "This changed how I write loops completely!"));
        v1.AddComment(new Comment("Bob", "Tip #7 blew my mind. Thanks!"));
        v1.AddComment(new Comment("Carlos", "Could you do a follow-up on async/await?"));
        v1.AddComment(new Comment("Dana", "Subscribed after watching this. Great content."));

        // Video 2
        var v2 = new Video("How Products Are Made: Chocolate", "FactoryInsider", 518);
        v2.AddComment(new Comment("Emma", "I will never look at a chocolate bar the same way."));
        v2.AddComment(new Comment("Frank", "Fascinating process. Very well explained."));
        v2.AddComment(new Comment("Grace", "Does this apply to dark chocolate too?"));

        // Video 3
        var v3 = new Video("Learn Git in 15 Minutes", "TechBrief", 903);
        v3.AddComment(new Comment("Hank", "Finally a git tutorial that makes sense!"));
        v3.AddComment(new Comment("Isla", "The rebase explanation was super clear."));
        v3.AddComment(new Comment("Jake", "Been using git for years and still learned something."));
        v3.AddComment(new Comment("Kara", "Please make one on GitHub Actions next."));

        // Video 4
        var v4 = new Video("Top 5 Healthy Breakfast Ideas", "NutriLife", 367);
        v4.AddComment(new Comment("Leo", "Made the overnight oats this morning. Delicious!"));
        v4.AddComment(new Comment("Mia", "Simple and affordable. Exactly what I needed."));
        v4.AddComment(new Comment("Noah", "Do these work for meal prep?"));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);
        videos.Add(v4);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title:    {video.Title}");
            Console.WriteLine($"Author:   {video.Author}");
            Console.WriteLine($"Length:   {video.Length}s");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");

            Console.WriteLine();
        }
    }
}
