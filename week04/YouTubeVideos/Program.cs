namespace YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        
        Video video1 = new Video("How to Program in C#", "Katlego Kgwetiane", 120);
        Video video2 = new Video("How to catchup 3 weeks of work in 3 days", "Katlego Kgwetiane", 150);
        Video video3 = new Video("How to pass CSE210", "Katlego Khwetiane", 200);
       
        Comment comment1 = new Comment("Rumbi", "Great tutorial!");
        Comment comment2 = new Comment("Kairo", "Thanks for the tips.");
        Comment comment3 = new Comment("Narumi", "This was very helpful.");
        Comment comment4 = new Comment("Zema", "Excellent video!");
        Comment comment5 = new Comment("Mila", "I learned so much.");
        Comment comment6 = new Comment("Kganya", "Great examples.");
        Comment comment7 = new Comment("Keneilwe", "Wow! That's impressive.");
        Comment comment8 = new Comment("Kholo", "I would just give up!");
        Comment comment9 = new Comment("Bobo", "Excellent work!");
        
        // Add comments to videos
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);
        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);
        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);
        
        List<Video> videos = new List<Video> { video1, video2, video3 };
        
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}